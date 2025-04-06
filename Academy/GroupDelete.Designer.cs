namespace Academy
{
	partial class GroupDelete
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
			this.buttonDeleteGroupOk = new System.Windows.Forms.Button();
			this.buttonDeleteGroupCancel = new System.Windows.Forms.Button();
			this.comboBoxSelectDirection = new System.Windows.Forms.ComboBox();
			this.comboBoxSelectGroup = new System.Windows.Forms.ComboBox();
			this.labelSelectDirection = new System.Windows.Forms.Label();
			this.labelSelectGroup = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonDeleteGroupOk
			// 
			this.buttonDeleteGroupOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonDeleteGroupOk.Location = new System.Drawing.Point(187, 177);
			this.buttonDeleteGroupOk.Name = "buttonDeleteGroupOk";
			this.buttonDeleteGroupOk.Size = new System.Drawing.Size(75, 23);
			this.buttonDeleteGroupOk.TabIndex = 0;
			this.buttonDeleteGroupOk.Text = "OK";
			this.buttonDeleteGroupOk.UseVisualStyleBackColor = true;
			this.buttonDeleteGroupOk.Click += new System.EventHandler(this.buttonDeleteGroupOk_Click);
			// 
			// buttonDeleteGroupCancel
			// 
			this.buttonDeleteGroupCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonDeleteGroupCancel.Location = new System.Drawing.Point(59, 177);
			this.buttonDeleteGroupCancel.Name = "buttonDeleteGroupCancel";
			this.buttonDeleteGroupCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonDeleteGroupCancel.TabIndex = 1;
			this.buttonDeleteGroupCancel.Text = "Cancel";
			this.buttonDeleteGroupCancel.UseVisualStyleBackColor = true;
			// 
			// comboBoxSelectDirection
			// 
			this.comboBoxSelectDirection.FormattingEnabled = true;
			this.comboBoxSelectDirection.Location = new System.Drawing.Point(59, 55);
			this.comboBoxSelectDirection.Name = "comboBoxSelectDirection";
			this.comboBoxSelectDirection.Size = new System.Drawing.Size(203, 21);
			this.comboBoxSelectDirection.TabIndex = 2;
			// 
			// comboBoxSelectGroup
			// 
			this.comboBoxSelectGroup.FormattingEnabled = true;
			this.comboBoxSelectGroup.Location = new System.Drawing.Point(59, 124);
			this.comboBoxSelectGroup.Name = "comboBoxSelectGroup";
			this.comboBoxSelectGroup.Size = new System.Drawing.Size(203, 21);
			this.comboBoxSelectGroup.TabIndex = 3;
			// 
			// labelSelectDirection
			// 
			this.labelSelectDirection.AutoSize = true;
			this.labelSelectDirection.Location = new System.Drawing.Point(59, 30);
			this.labelSelectDirection.Name = "labelSelectDirection";
			this.labelSelectDirection.Size = new System.Drawing.Size(80, 13);
			this.labelSelectDirection.TabIndex = 4;
			this.labelSelectDirection.Text = "Select direction";
			// 
			// labelSelectGroup
			// 
			this.labelSelectGroup.AutoSize = true;
			this.labelSelectGroup.Location = new System.Drawing.Point(59, 98);
			this.labelSelectGroup.Name = "labelSelectGroup";
			this.labelSelectGroup.Size = new System.Drawing.Size(67, 13);
			this.labelSelectGroup.TabIndex = 5;
			this.labelSelectGroup.Text = "Select group";
			// 
			// GroupDelete
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(340, 224);
			this.Controls.Add(this.labelSelectGroup);
			this.Controls.Add(this.labelSelectDirection);
			this.Controls.Add(this.comboBoxSelectGroup);
			this.Controls.Add(this.comboBoxSelectDirection);
			this.Controls.Add(this.buttonDeleteGroupCancel);
			this.Controls.Add(this.buttonDeleteGroupOk);
			this.Name = "GroupDelete";
			this.Text = "Delete group";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonDeleteGroupOk;
		private System.Windows.Forms.Button buttonDeleteGroupCancel;
		private System.Windows.Forms.ComboBox comboBoxSelectDirection;
		private System.Windows.Forms.ComboBox comboBoxSelectGroup;
		private System.Windows.Forms.Label labelSelectDirection;
		private System.Windows.Forms.Label labelSelectGroup;
	}
}