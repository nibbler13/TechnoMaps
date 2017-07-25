using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace TechnoMaps {
	public partial class FormMain : Form {
		string selectedFolder = "";
		bool isRecursive = false;
		IWin32Window owner = null;
		TextBox textBox = null;
		ProgressBar progressBarResult = null;
		List<string> uniqueValues = new List<string>();
		string columnToRead = "";
		bool CellsNotWhite = false;
		
		public FormMain() {
			InitializeComponent();

			if (IsDebug(Assembly.GetExecutingAssembly())) {
				textBoxFolder.Text = @"C:\_Projects C#\TechnoMaps\Examples\";
				EnableControls();
			}
		}

		private void buttonSelectFolder_Click(object sender, EventArgs e) {
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.Description = "Выберите папку, содержащую файлы с технокартами";
			dialog.ShowNewFolderButton = false;

			if (dialog.ShowDialog() != DialogResult.OK)
				return;

			if (string.IsNullOrWhiteSpace(dialog.SelectedPath))
				return;

			EnableControls();
			textBoxFolder.Text = dialog.SelectedPath;
			buttonCreatePivotTable.Select();
		}

		private void EnableControls() {
			List<Control> controls = new List<Control>() {
				checkBoxFolderRecursion,
				buttonCreatePivotTable,
				labelColumn,
				textBoxColumn,
				checkBoxNotWhite
			};

			foreach (Control control in controls)
				control.Enabled = true;
		}

		private void buttonCreatePivotTable_Click(object sender, EventArgs e) {
			columnToRead = textBoxColumn.Text;

			if (string.IsNullOrEmpty(columnToRead)) {
				MessageBox.Show(owner, "Ошибка", "Поле название колонки не может быть пустым",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			List<Control> controls = new List<Control>() {
				labelTitle,
				buttonSelectFolder,
				textBoxFolder,
				buttonCreatePivotTable,
				checkBoxFolderRecursion,
				labelColumn,
				textBoxColumn,
				checkBoxNotWhite
			};

			foreach (Control control in controls)
				control.Visible = false;

			textBoxResult.Visible = true;
			progressBarResult.Visible = true;

			selectedFolder = textBoxFolder.Text;
			isRecursive = checkBoxFolderRecursion.Checked;
			Cursor = Cursors.WaitCursor;
			owner = this;
			textBox = textBoxResult;
			progressBar = progressBarResult;
			CellsNotWhite = checkBoxNotWhite.Checked;

			backgroundWorker.RunWorkerAsync();
		}

		private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
			UpdateTextBox("Обработка файлов");

			SearchOption searchOption = isRecursive ?
					SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

			IEnumerable<string> files = Directory.EnumerateFiles(
				selectedFolder, "*.xls*", searchOption);

			if (files.Count() == 0) {
				MessageBox.Show(owner, "Ошибка", "Не найдено ни одного файла Excel",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Excel.Application xlApp = new Excel.Application();

			if (xlApp == null) {
				MessageBox.Show(owner, "Ошибка", "Не удалось запустить MS EXCEL. " +
					"Попробуйте обратиться в службу технической поддержки.",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			xlApp.Visible = false;
			xlApp.DisplayAlerts = false;

			float initialPercentage = 0.0f;
			float oneFilePercentage = 100.0f / files.Count();

			foreach (string file in files) {
				LoadDataFromFile(xlApp, file, oneFilePercentage);

				initialPercentage += oneFilePercentage;
				UpdateProgressBar((int)initialPercentage);
			}

			if (uniqueValues.Count == 0) {
				MessageBox.Show(owner, "Ошибка", "Список наименований пуст", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				xlApp.Quit();
			}

			uniqueValues.Sort();

			Excel.Workbook xlNewWb = xlApp.Workbooks.Add("");
			Excel.Worksheet xlActiveSheet = xlNewWb.ActiveSheet;

			xlActiveSheet.Range["A1"].Value = "Наименование";
			xlActiveSheet.Range["A1"].Font.Bold = true;

			int startRow = 2;
			foreach (string value in uniqueValues) {
				xlActiveSheet.Range["A" + startRow].Value = value;
				startRow++;
			}

			UpdateProgressBar(100);

			xlApp.Visible = true;
		}

		private void LoadDataFromFile(Excel.Application xlApp, string file, float percentage) {
			UpdateTextBox(file);

			Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(file, ReadOnly: true);
			if (xlWorkbook == null) {
				UpdateTextBox("Не удалось открыть книгу: " + file, true);
				return;
			}

			if (xlWorkbook.Sheets.Count == 0) {
				UpdateTextBox("Книга не содержит листов");
				return;
			}

			float initialPercentage = progressBar.Value;
			float oneSheetPercentage = percentage / xlWorkbook.Sheets.Count;

			foreach (Excel.Worksheet xlWorksheet in xlWorkbook.Sheets) {
				int rowsCount = xlWorksheet.UsedRange.Rows.Count;
				if (rowsCount == 0) {
					UpdateTextBox("Лист " + xlWorksheet.Name + " не содержит данных");
					continue;
				}

				for (int i = 1; i <= rowsCount; i++) {
					try {
						if (CellsNotWhite &&
							xlWorksheet.Range[columnToRead + i].Interior.ColorIndex == -4142)
							continue;
						
						string value = GetStringFromExcelRange(xlWorksheet, columnToRead, i);

						if (string.IsNullOrEmpty(value))
							continue;

						if (!uniqueValues.Contains(value))
							uniqueValues.Add(value);
					} catch (Exception e) {
						UpdateTextBox("Строка " + e + ", " + e.Message);
					}
				}

				initialPercentage += oneSheetPercentage;
				UpdateProgressBar((int)initialPercentage);
			}

			xlWorkbook.Close(false);


		}
		
		private string GetStringFromExcelRange(Excel.Worksheet xlWorksheet, string column, int row) {
			string value = xlWorksheet.Range[column + row].Text.ToString();
			value = value.Trim().TrimStart().TrimEnd();
			return string.IsNullOrWhiteSpace(value) ? "" : value;
		}





		private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			MessageBox.Show(this, "Операции завершены");
			Cursor = Cursors.Default;
		}

		public static bool IsDebug(Assembly assembly) {
			object[] attributes = assembly.GetCustomAttributes(typeof(DebuggableAttribute), true);
			if (attributes == null || attributes.Length == 0)
				return true;

			var d = (DebuggableAttribute)attributes[0];
			if (d.IsJITTrackingEnabled) return true;
			return false;
		}

		private void UpdateTextBox(string message, bool isError = false, bool isNewSection = false) {
			if (textBox == null) return;

			textBox.BeginInvoke((MethodInvoker)delegate {
				if (isError)
					message = "ОШИБКА! " + message + " Обработка прервана.";

				if (isNewSection)
					textBox.AppendText("-------------------------------" + Environment.NewLine);

				textBox.AppendText(DateTime.Now.ToString("HH:mm:ss") + ": " + message + Environment.NewLine);
			});
		}

		private void UpdateProgressBar(int percentage) {
			if (progressBar == null) return;
			progressBar.BeginInvoke((MethodInvoker)delegate {
				progressBar.Value = percentage;
			});
		}
	}
}
