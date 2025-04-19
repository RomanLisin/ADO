namespace AcademyDataSet
{
	partial class MainForm
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
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageStudents = new System.Windows.Forms.TabPage();
			this.labelSudentsGroup = new System.Windows.Forms.Label();
			this.cbStudentsGroups = new System.Windows.Forms.ComboBox();
			this.labelStudentsDirection = new System.Windows.Forms.Label();
			this.cbStudentsDirections = new System.Windows.Forms.ComboBox();
			this.dgvStudents = new System.Windows.Forms.DataGridView();
			this.tabPageGroups = new System.Windows.Forms.TabPage();
			this.labelGroupsDirection = new System.Windows.Forms.Label();
			this.cbGroupsDirections = new System.Windows.Forms.ComboBox();
			this.dgvGroups = new System.Windows.Forms.DataGridView();
			this.tabPageDirections = new System.Windows.Forms.TabPage();
			this.dgvDirections = new System.Windows.Forms.DataGridView();
			this.tabPageDisciplines = new System.Windows.Forms.TabPage();
			this.dgvDisciplines = new System.Windows.Forms.DataGridView();
			this.tabPageTeachers = new System.Windows.Forms.TabPage();
			this.dgvTeachers = new System.Windows.Forms.DataGridView();
			this.tabControl.SuspendLayout();
			this.tabPageStudents.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
			this.tabPageGroups.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
			this.tabPageDirections.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).BeginInit();
			this.tabPageDisciplines.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDisciplines)).BeginInit();
			this.tabPageTeachers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageStudents);
			this.tabControl.Controls.Add(this.tabPageGroups);
			this.tabControl.Controls.Add(this.tabPageDirections);
			this.tabControl.Controls.Add(this.tabPageDisciplines);
			this.tabControl.Controls.Add(this.tabPageTeachers);
			this.tabControl.Location = new System.Drawing.Point(-3, 2);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(806, 449);
			this.tabControl.TabIndex = 0;
			// 
			// tabPageStudents
			// 
			this.tabPageStudents.Controls.Add(this.labelSudentsGroup);
			this.tabPageStudents.Controls.Add(this.cbStudentsGroups);
			this.tabPageStudents.Controls.Add(this.labelStudentsDirection);
			this.tabPageStudents.Controls.Add(this.cbStudentsDirections);
			this.tabPageStudents.Controls.Add(this.dgvStudents);
			this.tabPageStudents.Location = new System.Drawing.Point(4, 22);
			this.tabPageStudents.Name = "tabPageStudents";
			this.tabPageStudents.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageStudents.Size = new System.Drawing.Size(798, 423);
			this.tabPageStudents.TabIndex = 0;
			this.tabPageStudents.Text = "Students";
			this.tabPageStudents.UseVisualStyleBackColor = true;
			// 
			// labelSudentsGroup
			// 
			this.labelSudentsGroup.AutoSize = true;
			this.labelSudentsGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSudentsGroup.Location = new System.Drawing.Point(88, 7);
			this.labelSudentsGroup.Name = "labelSudentsGroup";
			this.labelSudentsGroup.Size = new System.Drawing.Size(59, 20);
			this.labelSudentsGroup.TabIndex = 4;
			this.labelSudentsGroup.Text = "Group";
			// 
			// cbStudentsGroups
			// 
			this.cbStudentsGroups.FormattingEnabled = true;
			this.cbStudentsGroups.Location = new System.Drawing.Point(175, 6);
			this.cbStudentsGroups.Name = "cbStudentsGroups";
			this.cbStudentsGroups.Size = new System.Drawing.Size(150, 21);
			this.cbStudentsGroups.TabIndex = 3;
			// 
			// labelStudentsDirection
			// 
			this.labelStudentsDirection.AutoSize = true;
			this.labelStudentsDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelStudentsDirection.Location = new System.Drawing.Point(353, 7);
			this.labelStudentsDirection.Name = "labelStudentsDirection";
			this.labelStudentsDirection.Size = new System.Drawing.Size(81, 20);
			this.labelStudentsDirection.TabIndex = 2;
			this.labelStudentsDirection.Text = "Direction";
			// 
			// cbStudentsDirections
			// 
			this.cbStudentsDirections.FormattingEnabled = true;
			this.cbStudentsDirections.Location = new System.Drawing.Point(452, 6);
			this.cbStudentsDirections.Name = "cbStudentsDirections";
			this.cbStudentsDirections.Size = new System.Drawing.Size(323, 21);
			this.cbStudentsDirections.TabIndex = 1;
			this.cbStudentsDirections.SelectedIndexChanged += new System.EventHandler(this.cbStudentsDirections_SelectedIndexChanged);
			// 
			// dgvStudents
			// 
			this.dgvStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvStudents.Location = new System.Drawing.Point(-4, 33);
			this.dgvStudents.Name = "dgvStudents";
			this.dgvStudents.Size = new System.Drawing.Size(802, 394);
			this.dgvStudents.TabIndex = 0;
			// 
			// tabPageGroups
			// 
			this.tabPageGroups.Controls.Add(this.labelGroupsDirection);
			this.tabPageGroups.Controls.Add(this.cbGroupsDirections);
			this.tabPageGroups.Controls.Add(this.dgvGroups);
			this.tabPageGroups.Location = new System.Drawing.Point(4, 22);
			this.tabPageGroups.Name = "tabPageGroups";
			this.tabPageGroups.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGroups.Size = new System.Drawing.Size(798, 423);
			this.tabPageGroups.TabIndex = 1;
			this.tabPageGroups.Text = "Groups";
			this.tabPageGroups.UseVisualStyleBackColor = true;
			// 
			// labelGroupsDirection
			// 
			this.labelGroupsDirection.AutoSize = true;
			this.labelGroupsDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelGroupsDirection.Location = new System.Drawing.Point(353, 7);
			this.labelGroupsDirection.Name = "labelGroupsDirection";
			this.labelGroupsDirection.Size = new System.Drawing.Size(81, 20);
			this.labelGroupsDirection.TabIndex = 2;
			this.labelGroupsDirection.Text = "Direction";
			// 
			// cbGroupsDirections
			// 
			this.cbGroupsDirections.FormattingEnabled = true;
			this.cbGroupsDirections.Location = new System.Drawing.Point(452, 6);
			this.cbGroupsDirections.Name = "cbGroupsDirections";
			this.cbGroupsDirections.Size = new System.Drawing.Size(325, 21);
			this.cbGroupsDirections.TabIndex = 1;
			this.cbGroupsDirections.SelectedIndexChanged += new System.EventHandler(this.cbGroupsDirections_SelectedIndexChanged);
			// 
			// dgvGroups
			// 
			this.dgvGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGroups.Location = new System.Drawing.Point(0, 33);
			this.dgvGroups.Name = "dgvGroups";
			this.dgvGroups.Size = new System.Drawing.Size(798, 394);
			this.dgvGroups.TabIndex = 0;
			// 
			// tabPageDirections
			// 
			this.tabPageDirections.Controls.Add(this.dgvDirections);
			this.tabPageDirections.Location = new System.Drawing.Point(4, 22);
			this.tabPageDirections.Name = "tabPageDirections";
			this.tabPageDirections.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDirections.Size = new System.Drawing.Size(798, 423);
			this.tabPageDirections.TabIndex = 2;
			this.tabPageDirections.Text = "Directions";
			this.tabPageDirections.UseVisualStyleBackColor = true;
			// 
			// dgvDirections
			// 
			this.dgvDirections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvDirections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDirections.Location = new System.Drawing.Point(0, 32);
			this.dgvDirections.Name = "dgvDirections";
			this.dgvDirections.Size = new System.Drawing.Size(798, 395);
			this.dgvDirections.TabIndex = 0;
			// 
			// tabPageDisciplines
			// 
			this.tabPageDisciplines.Controls.Add(this.dgvDisciplines);
			this.tabPageDisciplines.Location = new System.Drawing.Point(4, 22);
			this.tabPageDisciplines.Name = "tabPageDisciplines";
			this.tabPageDisciplines.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDisciplines.Size = new System.Drawing.Size(798, 423);
			this.tabPageDisciplines.TabIndex = 3;
			this.tabPageDisciplines.Text = "Disciplines";
			this.tabPageDisciplines.UseVisualStyleBackColor = true;
			// 
			// dgvDisciplines
			// 
			this.dgvDisciplines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvDisciplines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDisciplines.Location = new System.Drawing.Point(-4, 34);
			this.dgvDisciplines.Name = "dgvDisciplines";
			this.dgvDisciplines.Size = new System.Drawing.Size(806, 393);
			this.dgvDisciplines.TabIndex = 0;
			// 
			// tabPageTeachers
			// 
			this.tabPageTeachers.Controls.Add(this.dgvTeachers);
			this.tabPageTeachers.Location = new System.Drawing.Point(4, 22);
			this.tabPageTeachers.Name = "tabPageTeachers";
			this.tabPageTeachers.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTeachers.Size = new System.Drawing.Size(798, 423);
			this.tabPageTeachers.TabIndex = 4;
			this.tabPageTeachers.Text = "Teachers";
			this.tabPageTeachers.UseVisualStyleBackColor = true;
			// 
			// dgvTeachers
			// 
			this.dgvTeachers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTeachers.Location = new System.Drawing.Point(0, 35);
			this.dgvTeachers.Name = "dgvTeachers";
			this.dgvTeachers.Size = new System.Drawing.Size(798, 392);
			this.dgvTeachers.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tabControl);
			this.Name = "MainForm";
			this.Text = "DataSet";
			this.tabControl.ResumeLayout(false);
			this.tabPageStudents.ResumeLayout(false);
			this.tabPageStudents.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
			this.tabPageGroups.ResumeLayout(false);
			this.tabPageGroups.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
			this.tabPageDirections.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).EndInit();
			this.tabPageDisciplines.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDisciplines)).EndInit();
			this.tabPageTeachers.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageStudents;
		private System.Windows.Forms.TabPage tabPageGroups;
		private System.Windows.Forms.TabPage tabPageDirections;
		private System.Windows.Forms.TabPage tabPageDisciplines;
		private System.Windows.Forms.TabPage tabPageTeachers;
		private System.Windows.Forms.DataGridView dgvStudents;
		private System.Windows.Forms.DataGridView dgvGroups;
		private System.Windows.Forms.DataGridView dgvDirections;
		private System.Windows.Forms.Label labelGroupsDirection;
		private System.Windows.Forms.ComboBox cbGroupsDirections;
		private System.Windows.Forms.DataGridView dgvDisciplines;
		private System.Windows.Forms.DataGridView dgvTeachers;
		private System.Windows.Forms.Label labelSudentsGroup;
		private System.Windows.Forms.ComboBox cbStudentsGroups;
		private System.Windows.Forms.Label labelStudentsDirection;
		private System.Windows.Forms.ComboBox cbStudentsDirections;
	}
}

