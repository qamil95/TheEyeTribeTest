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
            this.buttonStartWinformsApp = new System.Windows.Forms.Button();
            this.textBoxActivated = new System.Windows.Forms.TextBox();
            this.labelAcivated = new System.Windows.Forms.Label();
            this.buttonStartSfmlApp = new System.Windows.Forms.Button();
            this.checkBoxEyeTribeMode = new System.Windows.Forms.CheckBox();
            this.comboBoxSteeringLeftPaddle = new System.Windows.Forms.ComboBox();
            this.comboBoxSteeringRightPaddle = new System.Windows.Forms.ComboBox();
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
            // buttonStartWinformsApp
            // 
            this.buttonStartWinformsApp.Location = new System.Drawing.Point(12, 327);
            this.buttonStartWinformsApp.Name = "buttonStartWinformsApp";
            this.buttonStartWinformsApp.Size = new System.Drawing.Size(360, 23);
            this.buttonStartWinformsApp.TabIndex = 0;
            this.buttonStartWinformsApp.Text = "Start winforms app";
            this.buttonStartWinformsApp.UseVisualStyleBackColor = true;
            this.buttonStartWinformsApp.Click += new System.EventHandler(this.buttonStartApp_Click);
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
            // buttonStartSfmlApp
            // 
            this.buttonStartSfmlApp.Location = new System.Drawing.Point(13, 298);
            this.buttonStartSfmlApp.Name = "buttonStartSfmlApp";
            this.buttonStartSfmlApp.Size = new System.Drawing.Size(359, 23);
            this.buttonStartSfmlApp.TabIndex = 6;
            this.buttonStartSfmlApp.Text = "Start SFML App";
            this.buttonStartSfmlApp.UseVisualStyleBackColor = true;
            this.buttonStartSfmlApp.Click += new System.EventHandler(this.buttonStartSfmlApp_Click);
            // 
            // checkBoxEyeTribeMode
            // 
            this.checkBoxEyeTribeMode.AutoSize = true;
            this.checkBoxEyeTribeMode.Location = new System.Drawing.Point(13, 64);
            this.checkBoxEyeTribeMode.Name = "checkBoxEyeTribeMode";
            this.checkBoxEyeTribeMode.Size = new System.Drawing.Size(97, 17);
            this.checkBoxEyeTribeMode.TabIndex = 7;
            this.checkBoxEyeTribeMode.Text = "EyeTribe mode";
            this.checkBoxEyeTribeMode.UseVisualStyleBackColor = true;
            // 
            // comboBoxSteeringLeftPaddle
            // 
            this.comboBoxSteeringLeftPaddle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSteeringLeftPaddle.FormattingEnabled = true;
            this.comboBoxSteeringLeftPaddle.Location = new System.Drawing.Point(13, 149);
            this.comboBoxSteeringLeftPaddle.Name = "comboBoxSteeringLeftPaddle";
            this.comboBoxSteeringLeftPaddle.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSteeringLeftPaddle.TabIndex = 8;
            // 
            // comboBoxSteeringRightPaddle
            // 
            this.comboBoxSteeringRightPaddle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSteeringRightPaddle.FormattingEnabled = true;
            this.comboBoxSteeringRightPaddle.Location = new System.Drawing.Point(250, 149);
            this.comboBoxSteeringRightPaddle.Name = "comboBoxSteeringRightPaddle";
            this.comboBoxSteeringRightPaddle.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSteeringRightPaddle.TabIndex = 9;
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.comboBoxSteeringRightPaddle);
            this.Controls.Add(this.comboBoxSteeringLeftPaddle);
            this.Controls.Add(this.checkBoxEyeTribeMode);
            this.Controls.Add(this.buttonStartSfmlApp);
            this.Controls.Add(this.labelAcivated);
            this.Controls.Add(this.textBoxActivated);
            this.Controls.Add(this.labelTrackerState);
            this.Controls.Add(this.textBoxTrackerState);
            this.Controls.Add(this.buttonStartWinformsApp);
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Launcher_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartWinformsApp;
        private System.Windows.Forms.TextBox textBoxTrackerState;
        private System.Windows.Forms.Label labelTrackerState;
        private System.Windows.Forms.TextBox textBoxActivated;
        private System.Windows.Forms.Label labelAcivated;
        private System.Windows.Forms.Button buttonStartSfmlApp;
        private System.Windows.Forms.CheckBox checkBoxEyeTribeMode;
        private System.Windows.Forms.ComboBox comboBoxSteeringLeftPaddle;
        private System.Windows.Forms.ComboBox comboBoxSteeringRightPaddle;
    }
}