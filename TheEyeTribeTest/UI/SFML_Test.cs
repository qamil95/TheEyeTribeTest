﻿using SFML.Graphics;
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
        private readonly RectangleShape [] borders;
        private readonly RenderWindow app;
        private readonly CentralText result;

        public SFML_Test(bool eyeTribeMode)
        {
            app = new RenderWindow(VideoMode.DesktopMode, "SFML Test PONG!", Styles.Fullscreen);

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
            borders = new RectangleShape[4];

            borders[0] = new RectangleShape(new Vector2f(app.Size.X, 3))
                { Position = new Vector2f(0, 0) };

            borders[1] = new RectangleShape(new Vector2f(3, app.Size.Y))
                { Position = new Vector2f(app.Size.X - 3, 0) };

            borders[2] = new RectangleShape(new Vector2f(app.Size.X, 3))
                { Position = new Vector2f(0, app.Size.Y - 3) };

            borders[3] = new RectangleShape(new Vector2f(3, app.Size.Y))
                { Position = new Vector2f(0, 0) };
            
            result = new CentralText(app.Size)
            {
                Font = new Font("consola.ttf"),
                Color = Color.Yellow
            };
            result.SetText("Pong started...");

            app.Closed += OnClose;
            app.KeyPressed += OnKeyPressed;
            app.SetVerticalSyncEnabled(true);
        }

        public void Run()
        {
            ResetGame();

            Color windowColor = new Color(0, 0, 0);

            while (app.IsOpen)
            {
                app.DispatchEvents();
                
                app.Clear(windowColor);

                ball.UpdateBallPosition();
                leftPaddle.Position = new Vector2f(leftPaddle.Position.X, cursorPosition.GetCursorPosition().Y);
                rightPaddle.Position = new Vector2f(rightPaddle.Position.X, ball.Position.Y);

                CheckCollisions();

                app.Draw(leftPaddle);
                app.Draw(rightPaddle);
                app.Draw(ball);
                app.Draw(result);

                foreach (var border in borders)
                {
                    app.Draw(border);
                }

                app.Display();
            }
        }

        private void CheckCollisions()
        {
            var ballBounds = ball.GetGlobalBounds();
            if (ballBounds.Intersects(borders[0].GetGlobalBounds()))
            {
                result.SetText("HIT upper");
                ball.Angle = -ball.Angle;
            }
            if (ballBounds.Intersects(borders[1].GetGlobalBounds()))
            {
                result.SetText("HIT right");
            }
            if (ballBounds.Intersects(borders[2].GetGlobalBounds()))
            {
                result.SetText("HIT bottom");
                ball.Angle = -ball.Angle;
            }
            if (ballBounds.Intersects(borders[3].GetGlobalBounds()))
            {
                result.SetText("HIT left");
            }
            if (ballBounds.Intersects(leftPaddle.GetGlobalBounds()))
            {
                result.SetText("HIT left paddle");
                if (ball.Position.Y > leftPaddle.Position.Y)
                {
                    ball.Angle = Math.PI - ball.Angle + new Random().Next(20) * Math.PI / 180;
                }
                else
                {
                    ball.Angle = Math.PI - ball.Angle - new Random().Next(20) * Math.PI / 180;
                }
            }
            if (ballBounds.Intersects(rightPaddle.GetGlobalBounds()))
            {
                result.SetText("HIT right paddle");
                if (ball.Position.Y > rightPaddle.Position.Y)
                {
                    ball.Angle = Math.PI - ball.Angle + new Random().Next(20) * Math.PI / 180;
                }
                else
                {
                    ball.Angle = Math.PI - ball.Angle - new Random().Next(20) * Math.PI / 180;
                }
            }
        }

        private void ResetGame()
        {
            leftPaddle.Position = new Vector2f(10 + leftPaddle.Size.X, leftPaddle.Size.Y);
            rightPaddle.Position = new Vector2f(VideoMode.DesktopMode.Width - 10 - rightPaddle.Size.X, rightPaddle.Size.Y);
            ball.Position = new Vector2f((float)VideoMode.DesktopMode.Width / 2 , (float)VideoMode.DesktopMode.Height / 2);
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
            switch (keyPressed.Code)
            {
                case Keyboard.Key.Escape:
                    OnClose(sender, EventArgs.Empty);
                    break;
                case Keyboard.Key.Return:
                    ResetGame();
                    break;
            }
        }
        #endregion
    }
}
