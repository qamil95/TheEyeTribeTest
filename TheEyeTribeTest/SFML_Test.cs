using SFML.Graphics;
using SFML.Window;
using System;
using EyeTribe.ClientSdk;

namespace TheEyeTribeTest
{
    class SFML_Test
    {
        private readonly EyeData _eyeData;
        public SFML_Test()
        {
            _eyeData = new EyeData();
            GazeManager.Instance.AddGazeListener(_eyeData);
        }

        void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        public void Run()
        {
            // Create the main window
            RenderWindow app = new RenderWindow(new VideoMode(800, 600), "SFML Works!");
            app.Closed += OnClose;
            
            Color windowColor = new Color(0, 192, 255);

            // Start the game loop
            while (app.IsOpen)
            {
                // Process events
                app.DispatchEvents();

                // Clear screen
                app.Clear(windowColor);
                
                // Update the window
                app.Display();
            } //End game loop
        } //End Main()
    }
}
