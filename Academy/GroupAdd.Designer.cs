namespace Academy
{
	partial class AddGroup
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
			this.labelInputName = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.buttonGroupAdd = new System.Windows.Forms.Button();
			this.buttonGroupAddCancel = new System.Windows.Forms.Button();
			this.comboBoxSelectDirection = new System.Windows.Forms.ComboBox();
			this.labelSelectDirection = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelInputName
			// 
			this.labelInputName.AutoSize = true;
			this.labelInputName.Location = new System.Drawing.Point(49, 110);
			this.labelInputName.Name = "labelInputName";
			this.labelInputName.Size = new System.Drawing.Size(60, 13);
			this.labelInputName.TabIndex = 0;
			this.labelInputName.Text = "Input name";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(126, 103);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(161, 20);
			this.textBoxName.TabIndex = 1;
			// 
			// buttonGroupAdd
			// 
			this.buttonGroupAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonGroupAdd.Location = new System.Drawing.Point(212, 164);
			this.buttonGroupAdd.Name = "buttonGroupAdd";
			this.buttonGroupAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonGroupAdd.TabIndex = 2;
			this.buttonGroupAdd.Text = "Add";
			this.buttonGroupAdd.UseVisualStyleBackColor = true;
			this.buttonGroupAdd.Click += new System.EventHandler(this.buttonGroupAdd_Click);
			// 
			// buttonGroupAddCancel
			// 
			this.buttonGroupAddCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonGroupAddCancel.Location = new System.Drawing.Point(102, 164);
			this.buttonGroupAddCancel.Name = "buttonGroupAddCancel";
			this.buttonGroupAddCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonGroupAddCancel.TabIndex = 3;
			this.buttonGroupAddCancel.Text = "Cancel";
			this.buttonGroupAddCancel.UseVisualStyleBackColor = true;
			// 
			// comboBoxSelectDirection
			// 
			this.comboBoxSelectDirection.FormattingEnabled = true;
			this.comboBoxSelectDirection.Location = new System.Drawing.Point(32, 49);
			this.comboBoxSelectDirection.Name = "comboBoxSelectDirection";
			this.comboBoxSelectDirection.Size = new System.Drawing.Size(255, 21);
			this.comboBoxSelectDirection.TabIndex = 4;
			// 
			// labelSelectDirection
			// 
			this.labelSelectDirection.AutoSize = true;
			this.labelSelectDirection.Location = new System.Drawing.Point(29, 21);
			this.labelSelectDirection.Name = "labelSelectDirection";
			this.labelSelectDirection.Size = new System.Drawing.Size(80, 13);
			this.labelSelectDirection.TabIndex = 5;
			this.labelSelectDirection.Text = "Select direction";
			this.labelSelectDirection.UseMnemonic = false;
			// 
			// AddGroup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(312, 214);
			this.Controls.Add(this.labelSelectDirection);
			this.Controls.Add(this.comboBoxSelectDirection);
			this.Controls.Add(this.buttonGroupAddCancel);
			this.Controls.Add(this.buttonGroupAdd);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelInputName);
			this.Name = "AddGroup";
			this.Text = "Add group";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelInputName;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Button buttonGroupAdd;
		private System.Windows.Forms.Button buttonGroupAddCancel;
		private System.Windows.Forms.ComboBox comboBoxSelectDirection;
		private System.Windows.Forms.Label labelSelectDirection;
	}
}