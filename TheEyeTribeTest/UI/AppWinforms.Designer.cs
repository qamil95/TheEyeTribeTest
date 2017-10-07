namespace TheEyeTribeTest
{
    partial class AppWinforms
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelX = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelY = new System.Windows.Forms.ToolStripStatusLabel();
            this.radioButtonPosition = new System.Windows.Forms.RadioButton();
            this.buttonPosition = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelX,
            this.toolStripStatusLabelY});
            this.statusStrip1.Location = new System.Drawing.Point(0, 420);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelX
            // 
            this.toolStripStatusLabelX.Name = "toolStripStatusLabelX";
            this.toolStripStatusLabelX.Size = new System.Drawing.Size(119, 17);
            this.toolStripStatusLabelX.Text = "toolStripStatusLabelX";
            // 
            // toolStripStatusLabelY
            // 
            this.toolStripStatusLabelY.Name = "toolStripStatusLabelY";
            this.toolStripStatusLabelY.Size = new System.Drawing.Size(119, 17);
            this.toolStripStatusLabelY.Text = "toolStripStatusLabelY";
            // 
            // radioButtonPosition
            // 
            this.radioButtonPosition.AutoSize = true;
            this.radioButtonPosition.Location = new System.Drawing.Point(218, 64);
            this.radioButtonPosition.Name = "radioButtonPosition";
            this.radioButtonPosition.Size = new System.Drawing.Size(14, 13);
            this.radioButtonPosition.TabIndex = 3;
            this.radioButtonPosition.TabStop = true;
            this.radioButtonPosition.UseVisualStyleBackColor = true;
            // 
            // buttonPosition
            // 
            this.buttonPosition.Location = new System.Drawing.Point(12, 12);
            this.buttonPosition.Name = "buttonPosition";
            this.buttonPosition.Size = new System.Drawing.Size(25, 100);
            this.buttonPosition.TabIndex = 4;
            this.buttonPosition.Text = "button1";
            this.buttonPosition.UseVisualStyleBackColor = true;
            // 
            // AppWinforms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.buttonPosition);
            this.Controls.Add(this.radioButtonPosition);
            this.Controls.Add(this.statusStrip1);
            this.Name = "AppWinforms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Winforms";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainApp_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelX;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelY;
        private System.Windows.Forms.RadioButton radioButtonPosition;
        private System.Windows.Forms.Button buttonPosition;
    }
}

