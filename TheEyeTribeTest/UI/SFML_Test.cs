using SFML.Graphics;
using SFML.Window;
using System;
using System.Diagnostics.CodeAnalysis;
using EyeTribe.ClientSdk;
using SFML.System;
using TheEyeTribeTest.Files;

namespace TheEyeTribeTest
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal class SFML_Test
    {
        private readonly ICursorPosition cursorPosition;
        private readonly Ball ball;
        private readonly Paddle leftPaddle;
        private readonly Paddle rightPaddle;
        public SFML_Test(bool eyeTribeMode)
        {
            if (eyeTribeMode)
            {
                var eye = new EyeData();
                cursorPosition = eye;
                GazeManager.Instance.AddGazeListener(eye);
            }
            else
            {
                cursorPosition = new MouseData();
            }
            
            ball = new Ball();
            leftPaddle = new Paddle();
            rightPaddle = new Paddle();
        }

        public void Run()
        {
            RenderWindow app = new RenderWindow(VideoMode.DesktopMode, "SFML Test PONG!", Styles.Fullscreen);
            app.Closed += OnClose;
            app.KeyPressed += OnKeyPressed;
            app.SetVerticalSyncEnabled(true);
            app.SetFramerateLimit(60);
            ResetGame();

            Color windowColor = new Color(0, 0, 0);

            while (app.IsOpen)
            {
                app.DispatchEvents();
                
                app.Clear(windowColor);

                leftPaddle.Position = new Vector2f(leftPaddle.Position.X, cursorPosition.GetCursorPosition().Y);
                app.Draw(leftPaddle);
                app.Draw(rightPaddle);
                app.Draw(ball);

                app.Display();
            }
        }

        private void ResetGame()
        {
            leftPaddle.Position = new Vector2f(10 + leftPaddle.Size.X, leftPaddle.Size.Y);
            rightPaddle.Position = new Vector2f(VideoMode.DesktopMode.Width - 10 - rightPaddle.Size.X, rightPaddle.Size.Y);
            ball.Position = new Vector2f(VideoMode.DesktopMode.Width / 2 , VideoMode.DesktopMode.Height / 2);
            ball.RandomAngle();
        }

        #region Events
        void OnClose(object sender, EventArgs e)
        {
            var eye = cursorPosition as EyeData;
            if (eye != null)
            {
                GazeManager.Instance.RemoveGazeListener(eye);
            }

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
