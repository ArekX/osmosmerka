namespace OsmosmerkaGenerator
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
            this.nmMaxWS = new System.Windows.Forms.NumericUpDown();
            this.lblWSNum = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblWordNum = new System.Windows.Forms.Label();
            this.nmWords = new System.Windows.Forms.NumericUpDown();
            this.lblWidth = new System.Windows.Forms.Label();
            this.nmWidth = new System.Windows.Forms.NumericUpDown();
            this.lblVersion = new System.Windows.Forms.Label();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.btnClearExclusion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxWS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmWords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // nmMaxWS
            // 
            this.nmMaxWS.Location = new System.Drawing.Point(106, 12);
            this.nmMaxWS.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nmMaxWS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMaxWS.Name = "nmMaxWS";
            this.nmMaxWS.Size = new System.Drawing.Size(64, 20);
            this.nmMaxWS.TabIndex = 0;
            this.nmMaxWS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblWSNum
            // 
            this.lblWSNum.AutoSize = true;
            this.lblWSNum.Location = new System.Drawing.Point(12, 15);
            this.lblWSNum.Name = "lblWSNum";
            this.lblWSNum.Size = new System.Drawing.Size(88, 13);
            this.lblWSNum.TabIndex = 1;
            this.lblWSNum.Text = "Broj Osmosmerki:";
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(12, 117);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(469, 40);
            this.pbProgress.TabIndex = 2;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(9, 101);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(46, 13);
            this.lblProgress.TabIndex = 3;
            this.lblProgress.Text = "Progres:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(258, 20);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(223, 52);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generiši PDF";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblWordNum
            // 
            this.lblWordNum.AutoSize = true;
            this.lblWordNum.Location = new System.Drawing.Point(52, 40);
            this.lblWordNum.Name = "lblWordNum";
            this.lblWordNum.Size = new System.Drawing.Size(48, 13);
            this.lblWordNum.TabIndex = 6;
            this.lblWordNum.Text = "Broj reči:";
            // 
            // nmWords
            // 
            this.nmWords.Location = new System.Drawing.Point(106, 38);
            this.nmWords.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nmWords.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nmWords.Name = "nmWords";
            this.nmWords.Size = new System.Drawing.Size(64, 20);
            this.nmWords.TabIndex = 5;
            this.nmWords.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(64, 66);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(36, 13);
            this.lblWidth.TabIndex = 8;
            this.lblWidth.Text = "Širina:";
            // 
            // nmWidth
            // 
            this.nmWidth.Location = new System.Drawing.Point(106, 64);
            this.nmWidth.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.nmWidth.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmWidth.Name = "nmWidth";
            this.nmWidth.Size = new System.Drawing.Size(64, 20);
            this.nmWidth.TabIndex = 7;
            this.nmWidth.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(12, 172);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(165, 13);
            this.lblVersion.TabIndex = 11;
            this.lblVersion.Text = "Verzija 1.00, by Panić Aleksandar";
            // 
            // dlgSave
            // 
            this.dlgSave.DefaultExt = "pdf";
            this.dlgSave.Filter = "PDF fajlovi|*.pdf";
            this.dlgSave.Title = "Mjesto gdje ce se snimiti PDF fajl...";
            // 
            // btnClearExclusion
            // 
            this.btnClearExclusion.Enabled = false;
            this.btnClearExclusion.Location = new System.Drawing.Point(258, 163);
            this.btnClearExclusion.Name = "btnClearExclusion";
            this.btnClearExclusion.Size = new System.Drawing.Size(223, 22);
            this.btnClearExclusion.TabIndex = 12;
            this.btnClearExclusion.Text = "Očisti listu već dodanih reči";
            this.btnClearExclusion.UseVisualStyleBackColor = true;
            this.btnClearExclusion.Click += new System.EventHandler(this.btnClearExclusion_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 194);
            this.Controls.Add(this.btnClearExclusion);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.nmWidth);
            this.Controls.Add(this.lblWordNum);
            this.Controls.Add(this.nmWords);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.lblWSNum);
            this.Controls.Add(this.nmMaxWS);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Generator Osmosmerki";
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxWS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmWords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmMaxWS;
        private System.Windows.Forms.Label lblWSNum;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblWordNum;
        private System.Windows.Forms.NumericUpDown nmWords;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.NumericUpDown nmWidth;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.Button btnClearExclusion;
    }
}

