namespace TheEyeTribeTest
{
    partial class Launcher
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
            this.labelTrackerState = new System.Windows.Forms.Label();
            this.textBoxTrackerState = new System.Windows.Forms.TextBox();
            this.buttonStartApp = new System.Windows.Forms.Button();
            this.textBoxActivated = new System.Windows.Forms.TextBox();
            this.labelAcivated = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTrackerState
            // 
            this.labelTrackerState.AutoSize = true;
            this.labelTrackerState.Location = new System.Drawing.Point(187, 40);
            this.labelTrackerState.Name = "labelTrackerState";
            this.labelTrackerState.Size = new System.Drawing.Size(70, 13);
            this.labelTrackerState.TabIndex = 3;
            this.labelTrackerState.Text = "Tracker state";
            // 
            // textBoxTrackerState
            // 
            this.textBoxTrackerState.Location = new System.Drawing.Point(13, 37);
            this.textBoxTrackerState.Name = "textBoxTrackerState";
            this.textBoxTrackerState.ReadOnly = true;
            this.textBoxTrackerState.Size = new System.Drawing.Size(168, 20);
            this.textBoxTrackerState.TabIndex = 2;
            this.textBoxTrackerState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonStartApp
            // 
            this.buttonStartApp.Location = new System.Drawing.Point(12, 327);
            this.buttonStartApp.Name = "buttonStartApp";
            this.buttonStartApp.Size = new System.Drawing.Size(360, 23);
            this.buttonStartApp.TabIndex = 0;
            this.buttonStartApp.Text = "Start app";
            this.buttonStartApp.UseVisualStyleBackColor = true;
            this.buttonStartApp.Click += new System.EventHandler(this.buttonStartApp_Click);
            // 
            // textBoxActivated
            // 
            this.textBoxActivated.Location = new System.Drawing.Point(13, 11);
            this.textBoxActivated.Name = "textBoxActivated";
            this.textBoxActivated.ReadOnly = true;
            this.textBoxActivated.Size = new System.Drawing.Size(168, 20);
            this.textBoxActivated.TabIndex = 4;
            this.textBoxActivated.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelAcivated
            // 
            this.labelAcivated.AutoSize = true;
            this.labelAcivated.Location = new System.Drawing.Point(187, 14);
            this.labelAcivated.Name = "labelAcivated";
            this.labelAcivated.Size = new System.Drawing.Size(153, 13);
            this.labelAcivated.TabIndex = 5;
            this.labelAcivated.Text = "TheEyeTrivbe server activated";
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.labelAcivated);
            this.Controls.Add(this.textBoxActivated);
            this.Controls.Add(this.labelTrackerState);
            this.Controls.Add(this.textBoxTrackerState);
            this.Controls.Add(this.buttonStartApp);
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Launcher_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartApp;
        private System.Windows.Forms.TextBox textBoxTrackerState;
        private System.Windows.Forms.Label labelTrackerState;
        private System.Windows.Forms.TextBox textBoxActivated;
        private System.Windows.Forms.Label labelAcivated;
    }
}