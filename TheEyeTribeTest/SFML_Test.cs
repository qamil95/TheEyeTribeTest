using SFML.Graphics;
using SFML.Window;
using System;
using System.Diagnostics.CodeAnalysis;
using EyeTribe.ClientSdk;
using SFML.System;

namespace TheEyeTribeTest
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class SFML_Test
    {
        private readonly EyeData _eyeData;
        public SFML_Test()
        {
            _eyeData = new EyeData();
            GazeManager.Instance.AddGazeListener(_eyeData);
        }

        public void Run()
        {
            RenderWindow app = new RenderWindow(VideoMode.DesktopMode, "SFML Works!", Styles.Fullscreen);
            app.Closed += OnClose;
            app.KeyPressed += OnKeyPressed;
            
            Color windowColor = new Color(0, 192, 255);
            var shape = new CircleShape(10);
            while (app.IsOpen)
            {
                app.DispatchEvents();
                
                app.Clear(windowColor);

                shape.Position = new Vector2f(_eyeData.X, _eyeData.Y);
                app.Draw(shape);

                app.Display();
            }
        }

        #region Events
        void OnClose(object sender, EventArgs e)
        {
            GazeManager.Instance.RemoveGazeListener(_eyeData);

            var window = (RenderWindow) sender;
            window.Close();
        }

        private void OnKeyPressed(object sender, KeyEventArgs keyPressed)
        {
            var window = (RenderWindow)sender;
            switch (keyPressed.Code)
            {
                case Keyboard.Key.Escape:
                    OnClose(sender, EventArgs.Empty);
                    break;
            }
        }
        #endregion
    }
}
