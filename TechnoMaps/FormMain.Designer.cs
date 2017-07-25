namespace TechnoMaps {
	partial class FormMain {
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
			this.labelTitle = new System.Windows.Forms.Label();
			this.textBoxFolder = new System.Windows.Forms.TextBox();
			this.buttonSelectFolder = new System.Windows.Forms.Button();
			this.buttonCreatePivotTable = new System.Windows.Forms.Button();
			this.checkBoxFolderRecursion = new System.Windows.Forms.CheckBox();
			this.progressBarResult = new System.Windows.Forms.ProgressBar();
			this.textBoxResult = new System.Windows.Forms.TextBox();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.labelColumn = new System.Windows.Forms.Label();
			this.textBoxColumn = new System.Windows.Forms.TextBox();
			this.checkBoxNotWhite = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(12, 19);
			this.labelTitle.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(284, 13);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Выберите папку, содержащую файлы с технокартами:";
			// 
			// textBoxFolder
			// 
			this.textBoxFolder.Location = new System.Drawing.Point(12, 35);
			this.textBoxFolder.Name = "textBoxFolder";
			this.textBoxFolder.ReadOnly = true;
			this.textBoxFolder.Size = new System.Drawing.Size(328, 20);
			this.textBoxFolder.TabIndex = 2;
			// 
			// buttonSelectFolder
			// 
			this.buttonSelectFolder.AutoSize = true;
			this.buttonSelectFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonSelectFolder.Location = new System.Drawing.Point(346, 33);
			this.buttonSelectFolder.Name = "buttonSelectFolder";
			this.buttonSelectFolder.Size = new System.Drawing.Size(26, 23);
			this.buttonSelectFolder.TabIndex = 1;
			this.buttonSelectFolder.Text = "...";
			this.buttonSelectFolder.UseVisualStyleBackColor = true;
			this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
			// 
			// buttonCreatePivotTable
			// 
			this.buttonCreatePivotTable.Enabled = false;
			this.buttonCreatePivotTable.Location = new System.Drawing.Point(119, 218);
			this.buttonCreatePivotTable.Name = "buttonCreatePivotTable";
			this.buttonCreatePivotTable.Size = new System.Drawing.Size(147, 36);
			this.buttonCreatePivotTable.TabIndex = 3;
			this.buttonCreatePivotTable.Text = "Создать сводную таблицу по наименованиям";
			this.buttonCreatePivotTable.UseVisualStyleBackColor = true;
			this.buttonCreatePivotTable.Click += new System.EventHandler(this.buttonCreatePivotTable_Click);
			// 
			// checkBoxFolderRecursion
			// 
			this.checkBoxFolderRecursion.AutoSize = true;
			this.checkBoxFolderRecursion.Checked = true;
			this.checkBoxFolderRecursion.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxFolderRecursion.Enabled = false;
			this.checkBoxFolderRecursion.Location = new System.Drawing.Point(105, 61);
			this.checkBoxFolderRecursion.Name = "checkBoxFolderRecursion";
			this.checkBoxFolderRecursion.Size = new System.Drawing.Size(175, 17);
			this.checkBoxFolderRecursion.TabIndex = 4;
			this.checkBoxFolderRecursion.Text = "Учитывать вложенные папки";
			this.checkBoxFolderRecursion.UseVisualStyleBackColor = true;
			// 
			// progressBarResult
			// 
			this.progressBarResult.Location = new System.Drawing.Point(12, 325);
			this.progressBarResult.Name = "progressBarResult";
			this.progressBarResult.Size = new System.Drawing.Size(360, 23);
			this.progressBarResult.TabIndex = 5;
			this.progressBarResult.Visible = false;
			// 
			// textBoxResult
			// 
			this.textBoxResult.Location = new System.Drawing.Point(12, 12);
			this.textBoxResult.MaxLength = 3276700;
			this.textBoxResult.Multiline = true;
			this.textBoxResult.Name = "textBoxResult";
			this.textBoxResult.ReadOnly = true;
			this.textBoxResult.Size = new System.Drawing.Size(360, 308);
			this.textBoxResult.TabIndex = 6;
			this.textBoxResult.Visible = false;
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
			// 
			// labelColumn
			// 
			this.labelColumn.Enabled = false;
			this.labelColumn.Location = new System.Drawing.Point(12, 91);
			this.labelColumn.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
			this.labelColumn.Name = "labelColumn";
			this.labelColumn.Size = new System.Drawing.Size(360, 33);
			this.labelColumn.TabIndex = 7;
			this.labelColumn.Text = "Буквенное название колонки, содержащее наименование материала \\ медикамента в таб" +
    "лице Excel (например A или B или C):";
			// 
			// textBoxColumn
			// 
			this.textBoxColumn.Enabled = false;
			this.textBoxColumn.Location = new System.Drawing.Point(142, 127);
			this.textBoxColumn.Name = "textBoxColumn";
			this.textBoxColumn.Size = new System.Drawing.Size(100, 20);
			this.textBoxColumn.TabIndex = 8;
			this.textBoxColumn.Text = "B";
			this.textBoxColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// checkBoxNotWhite
			// 
			this.checkBoxNotWhite.AutoSize = true;
			this.checkBoxNotWhite.Checked = true;
			this.checkBoxNotWhite.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxNotWhite.Enabled = false;
			this.checkBoxNotWhite.Location = new System.Drawing.Point(96, 153);
			this.checkBoxNotWhite.Name = "checkBoxNotWhite";
			this.checkBoxNotWhite.Size = new System.Drawing.Size(193, 17);
			this.checkBoxNotWhite.TabIndex = 9;
			this.checkBoxNotWhite.Text = "Фон ячеек отличается от белого";
			this.checkBoxNotWhite.UseVisualStyleBackColor = true;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 361);
			this.Controls.Add(this.checkBoxNotWhite);
			this.Controls.Add(this.textBoxColumn);
			this.Controls.Add(this.labelColumn);
			this.Controls.Add(this.progressBarResult);
			this.Controls.Add(this.checkBoxFolderRecursion);
			this.Controls.Add(this.buttonCreatePivotTable);
			this.Controls.Add(this.buttonSelectFolder);
			this.Controls.Add(this.textBoxFolder);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.textBoxResult);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormMain";
			this.Text = "Сводная информация по технокартам";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TextBox textBoxFolder;
		private System.Windows.Forms.Button buttonSelectFolder;
		private System.Windows.Forms.Button buttonCreatePivotTable;
		private System.Windows.Forms.CheckBox checkBoxFolderRecursion;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.TextBox textBoxResult;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private System.Windows.Forms.Label labelColumn;
		private System.Windows.Forms.TextBox textBoxColumn;
		private System.Windows.Forms.CheckBox checkBoxNotWhite;
	}
}

