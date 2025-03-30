namespace MoviesForms
{
	partial class movies
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(movies));
			this.labelMovies = new System.Windows.Forms.Label();
			this.comboBoxMovies = new System.Windows.Forms.ComboBox();
			this.contextMenuStripForMovies = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.comboBoxDirectors = new System.Windows.Forms.ComboBox();
			this.contextMenuStripForDirector = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.labelReleaseDate = new System.Windows.Forms.Label();
			this.buttonExit = new System.Windows.Forms.Button();
			this.buttonPlay = new System.Windows.Forms.Button();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.labelDirector = new System.Windows.Forms.Label();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ToolStripMenuItemAddMovie = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemAddDirector = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonFilter = new System.Windows.Forms.Button();
			this.contextMenuStripForMovies.SuspendLayout();
			this.contextMenuStripForDirector.SuspendLayout();
			this.contextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelMovies
			// 
			this.labelMovies.AutoSize = true;
			this.labelMovies.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMovies.Location = new System.Drawing.Point(147, 9);
			this.labelMovies.Name = "labelMovies";
			this.labelMovies.Size = new System.Drawing.Size(96, 29);
			this.labelMovies.TabIndex = 0;
			this.labelMovies.Text = "Movies";
			// 
			// comboBoxMovies
			// 
			this.comboBoxMovies.ContextMenuStrip = this.contextMenuStripForMovies;
			this.comboBoxMovies.FormattingEnabled = true;
			this.comboBoxMovies.Location = new System.Drawing.Point(12, 51);
			this.comboBoxMovies.Name = "comboBoxMovies";
			this.comboBoxMovies.Size = new System.Drawing.Size(385, 21);
			this.comboBoxMovies.TabIndex = 1;
			// 
			// contextMenuStripForMovies
			// 
			this.contextMenuStripForMovies.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem1});
			this.contextMenuStripForMovies.Name = "contextMenuStripForMovies";
			this.contextMenuStripForMovies.Size = new System.Drawing.Size(108, 26);
			// 
			// deleteToolStripMenuItem1
			// 
			this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
			this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
			this.deleteToolStripMenuItem1.Text = "Delete";
			this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
			// 
			// comboBoxDirectors
			// 
			this.comboBoxDirectors.ContextMenuStrip = this.contextMenuStripForDirector;
			this.comboBoxDirectors.FormattingEnabled = true;
			this.comboBoxDirectors.Location = new System.Drawing.Point(152, 174);
			this.comboBoxDirectors.Name = "comboBoxDirectors";
			this.comboBoxDirectors.Size = new System.Drawing.Size(225, 21);
			this.comboBoxDirectors.TabIndex = 3;
			this.comboBoxDirectors.SelectedIndexChanged += new System.EventHandler(this.comboBoxDirectors_SelectedIndexChanged);
			// 
			// contextMenuStripForDirector
			// 
			this.contextMenuStripForDirector.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
			this.contextMenuStripForDirector.Name = "contextMenuStripForDirector";
			this.contextMenuStripForDirector.Size = new System.Drawing.Size(108, 26);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// labelReleaseDate
			// 
			this.labelReleaseDate.AutoSize = true;
			this.labelReleaseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelReleaseDate.Location = new System.Drawing.Point(137, 93);
			this.labelReleaseDate.Name = "labelReleaseDate";
			this.labelReleaseDate.Size = new System.Drawing.Size(132, 24);
			this.labelReleaseDate.TabIndex = 4;
			this.labelReleaseDate.Text = "Release date";
			// 
			// buttonExit
			// 
			this.buttonExit.Location = new System.Drawing.Point(15, 260);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(175, 23);
			this.buttonExit.TabIndex = 6;
			this.buttonExit.Text = "Exit";
			this.buttonExit.UseVisualStyleBackColor = true;
			this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
			// 
			// buttonPlay
			// 
			this.buttonPlay.Location = new System.Drawing.Point(222, 260);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.Size = new System.Drawing.Size(175, 23);
			this.buttonPlay.TabIndex = 7;
			this.buttonPlay.Text = "Play";
			this.buttonPlay.UseVisualStyleBackColor = true;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new System.Drawing.Point(92, 129);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(80, 20);
			this.dateTimePicker1.TabIndex = 8;
			this.dateTimePicker1.ValueChanged += new System.EventHandler(this.comboBoxDirectors_SelectedIndexChanged);
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker2.Location = new System.Drawing.Point(211, 129);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(81, 20);
			this.dateTimePicker2.TabIndex = 9;
			this.dateTimePicker2.ValueChanged += new System.EventHandler(this.comboBoxDirectors_SelectedIndexChanged);
			// 
			// labelDirector
			// 
			this.labelDirector.AutoSize = true;
			this.labelDirector.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDirector.Location = new System.Drawing.Point(23, 171);
			this.labelDirector.Name = "labelDirector";
			this.labelDirector.Size = new System.Drawing.Size(83, 24);
			this.labelDirector.TabIndex = 10;
			this.labelDirector.Text = "Director";
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddMovie,
            this.ToolStripMenuItemAddDirector});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(142, 48);
			// 
			// ToolStripMenuItemAddMovie
			// 
			this.ToolStripMenuItemAddMovie.Name = "ToolStripMenuItemAddMovie";
			this.ToolStripMenuItemAddMovie.Size = new System.Drawing.Size(141, 22);
			this.ToolStripMenuItemAddMovie.Text = "Add Movie";
			this.ToolStripMenuItemAddMovie.Click += new System.EventHandler(this.ToolStripMenuItemAddMovie_Click);
			// 
			// ToolStripMenuItemAddDirector
			// 
			this.ToolStripMenuItemAddDirector.Name = "ToolStripMenuItemAddDirector";
			this.ToolStripMenuItemAddDirector.Size = new System.Drawing.Size(141, 22);
			this.ToolStripMenuItemAddDirector.Text = "Add Director";
			this.ToolStripMenuItemAddDirector.Click += new System.EventHandler(this.ToolStripMenuItemAddDirector_Click);
			// 
			// buttonFilter
			// 
			this.buttonFilter.Location = new System.Drawing.Point(114, 214);
			this.buttonFilter.Name = "buttonFilter";
			this.buttonFilter.Size = new System.Drawing.Size(178, 23);
			this.buttonFilter.TabIndex = 12;
			this.buttonFilter.Text = "Clear filter";
			this.buttonFilter.UseVisualStyleBackColor = true;
			this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
			// 
			// movies
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(410, 304);
			this.ContextMenuStrip = this.contextMenuStrip;
			this.Controls.Add(this.buttonFilter);
			this.Controls.Add(this.labelDirector);
			this.Controls.Add(this.dateTimePicker2);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.buttonPlay);
			this.Controls.Add(this.buttonExit);
			this.Controls.Add(this.labelReleaseDate);
			this.Controls.Add(this.comboBoxDirectors);
			this.Controls.Add(this.comboBoxMovies);
			this.Controls.Add(this.labelMovies);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "movies";
			this.Text = "Movies";
			this.contextMenuStripForMovies.ResumeLayout(false);
			this.contextMenuStripForDirector.ResumeLayout(false);
			this.contextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelMovies;
		private System.Windows.Forms.ComboBox comboBoxMovies;
		private System.Windows.Forms.ComboBox comboBoxDirectors;
		private System.Windows.Forms.Label labelReleaseDate;
		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.Button buttonPlay;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Label labelDirector;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddMovie;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddDirector;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripForDirector;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripForMovies;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
		private System.Windows.Forms.Button buttonFilter;
	}
}

