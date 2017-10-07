﻿using EyeTribe.ClientSdk;
using System;
using System.Windows.Forms;

namespace TheEyeTribeTest
{
    public partial class Launcher :
        InvokeForm, 
        IConnectionStateListener, 
        ITrackerStateListener
    {
        public Launcher()
        {
            InitializeComponent();
            textBoxActivated.Text =  GazeManager.Instance.Activate(GazeManagerCore.ApiVersion.VERSION_1_0).ToString();
            GazeManager.Instance.AddConnectionStateListener(this);
            GazeManager.Instance.AddTrackerStateListener(this);

            textBoxTrackerState.Text = GazeManager.Instance.Trackerstate.ToString();
        }

        public void OnConnectionStateChanged(bool isConnected)
        {
            DoInvoke(() => textBoxActivated.Text = isConnected.ToString());
        }

        public void OnTrackerStateChanged(GazeManagerCore.TrackerState trackerState)
        {
            DoInvoke(() => textBoxTrackerState.Text = trackerState.ToString());
        }

        private void buttonStartApp_Click(object sender, EventArgs e)
        {
            AppWinforms window = new AppWinforms();
            GazeManager.Instance.AddGazeListener(window);
            Hide();
            window.ShowDialog();            
            Show();            
        }

        private void Launcher_FormClosed(object sender, FormClosedEventArgs e)
        {
            GazeManager.Instance.Deactivate();
        }

        private void buttonStartSfmlApp_Click(object sender, EventArgs e)
        {
            SFML_Test test = new SFML_Test(checkBoxEyeTribeMode.Checked);
            test.Run();
        }
    }
}