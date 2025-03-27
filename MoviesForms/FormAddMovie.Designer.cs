namespace MoviesForms
{
	partial class FormAddMovie
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelNameMovie = new System.Windows.Forms.Label();
			this.textBoxNameMovie = new System.Windows.Forms.TextBox();
			this.labelNameDirector = new System.Windows.Forms.Label();
			this.labelReleaseDate = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.comboBoxDirector = new System.Windows.Forms.ComboBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelNameMovie
			// 
			this.labelNameMovie.AutoSize = true;
			this.labelNameMovie.Location = new System.Drawing.Point(12, 42);
			this.labelNameMovie.Name = "labelNameMovie";
			this.labelNameMovie.Size = new System.Drawing.Size(67, 13);
			this.labelNameMovie.TabIndex = 0;
			this.labelNameMovie.Text = "Name Movie";
			// 
			// textBoxNameMovie
			// 
			this.textBoxNameMovie.Location = new System.Drawing.Point(111, 35);
			this.textBoxNameMovie.Name = "textBoxNameMovie";
			this.textBoxNameMovie.Size = new System.Drawing.Size(197, 20);
			this.textBoxNameMovie.TabIndex = 1;
			// 
			// labelNameDirector
			// 
			this.labelNameDirector.AutoSize = true;
			this.labelNameDirector.Location = new System.Drawing.Point(13, 81);
			this.labelNameDirector.Name = "labelNameDirector";
			this.labelNameDirector.Size = new System.Drawing.Size(44, 13);
			this.labelNameDirector.TabIndex = 2;
			this.labelNameDirector.Text = "Director";
			// 
			// labelReleaseDate
			// 
			this.labelReleaseDate.AutoSize = true;
			this.labelReleaseDate.Location = new System.Drawing.Point(13, 122);
			this.labelReleaseDate.Name = "labelReleaseDate";
			this.labelReleaseDate.Size = new System.Drawing.Size(70, 13);
			this.labelReleaseDate.TabIndex = 3;
			this.labelReleaseDate.Text = "Release date";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker1.Location = new System.Drawing.Point(111, 116);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(79, 20);
			this.dateTimePicker1.TabIndex = 8;
			// 
			// comboBoxDirector
			// 
			this.comboBoxDirector.FormattingEnabled = true;
			this.comboBoxDirector.Location = new System.Drawing.Point(111, 73);
			this.comboBoxDirector.Name = "comboBoxDirector";
			this.comboBoxDirector.Size = new System.Drawing.Size(197, 21);
			this.comboBoxDirector.TabIndex = 9;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(97, 170);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 10;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonAdd
			// 
			this.buttonAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonAdd.Location = new System.Drawing.Point(244, 170);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonAdd.TabIndex = 11;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.UseVisualStyleBackColor = true;
			// 
			// FormAddMovie
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(343, 214);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.comboBoxDirector);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.labelReleaseDate);
			this.Controls.Add(this.labelNameDirector);
			this.Controls.Add(this.textBoxNameMovie);
			this.Controls.Add(this.labelNameMovie);
			this.Name = "FormAddMovie";
			this.Text = "FormAddMovie";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelNameMovie;
		private System.Windows.Forms.TextBox textBoxNameMovie;
		private System.Windows.Forms.Label labelNameDirector;
		private System.Windows.Forms.Label labelReleaseDate;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.ComboBox comboBoxDirector;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonAdd;
	}
}