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
			this.components = new System.ComponentModel.Container();
			this.cbDirections = new System.Windows.Forms.ComboBox();
			this.cbGroups = new System.Windows.Forms.ComboBox();
			this.timerDataSet = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// cbDirections
			// 
			this.cbDirections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDirections.FormattingEnabled = true;
			this.cbDirections.Location = new System.Drawing.Point(438, 108);
			this.cbDirections.Name = "cbDirections";
			this.cbDirections.Size = new System.Drawing.Size(223, 21);
			this.cbDirections.TabIndex = 0;
			this.cbDirections.SelectedIndexChanged += new System.EventHandler(this.cbDirections_SelectedIndexChanged);
			// 
			// cbGroups
			// 
			this.cbGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbGroups.FormattingEnabled = true;
			this.cbGroups.Location = new System.Drawing.Point(128, 108);
			this.cbGroups.Name = "cbGroups";
			this.cbGroups.Size = new System.Drawing.Size(200, 21);
			this.cbGroups.TabIndex = 1;
			// 
			// timerDataSet
			// 
			this.timerDataSet.Enabled = true;
			this.timerDataSet.Interval = 5000;
			this.timerDataSet.Tick += new System.EventHandler(this.timerDataSet_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.cbGroups);
			this.Controls.Add(this.cbDirections);
			this.Name = "MainForm";
			this.Text = "DataSet";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cbDirections;
		private System.Windows.Forms.ComboBox cbGroups;
		private System.Windows.Forms.Timer timerDataSet;
	}
}

