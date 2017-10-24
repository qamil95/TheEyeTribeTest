using SFML.Graphics;
using SFML.Window;
using System;
using SFML.System;
using TheEyeTribeTest.Files;
using TheEyeTribeTest.Steering_modes;

namespace TheEyeTribeTest
{
    internal class SFML_Test
    {
        private readonly Ball ball;
        private readonly Paddle leftPaddle;
        private readonly Paddle rightPaddle;
        private readonly RectangleShape [] borders;
        private readonly RenderWindow app;
        private readonly CentralText result;
        private int leftPoints;
        private int rightPoints;

        public SFML_Test(ControlTypes controlTypeLeft, ControlTypes controlTypeRight)
        {
            //create application window
            app = new RenderWindow(VideoMode.DesktopMode, "SFML Test PONG!", Styles.Fullscreen);

            //create ball
            ball = new Ball();

            //create left player
            leftPaddle = AssignControlMode(controlTypeLeft);

            //create right player - ball data
            rightPaddle = AssignControlMode(controlTypeRight);
            
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
            result.SetText($"LEFT {leftPoints} -||- {rightPoints} RIGHT");

            app.Closed += OnClose;
            app.KeyPressed += OnKeyPressed;
            app.SetVerticalSyncEnabled(true);
        }

        private Paddle AssignControlMode(ControlTypes controlTypeLeft)
        {
            switch (controlTypeLeft)
            {
                case ControlTypes.Keyboard:
                    return new PaddleDirectional(new KeyboardData());
                case ControlTypes.Mouse:
                    return new PaddleDirectional(new MouseData());
                case ControlTypes.Mouse_SetPosition:
                    return new Paddle(new MouseData());
                case ControlTypes.EyeTribe:
                    return new PaddleDirectional(new EyeData());
                case ControlTypes.EyeTribe_SetPosition:
                    return new Paddle(new EyeData());
                case ControlTypes.EyeTribe_Gaussian:
                    return new PaddleGaussian(new EyeData());
                case ControlTypes.Ball:
                    return new Paddle(new BallData(ball));
                default:
                    return new Paddle(new DummyData());
            }
        }

        public void Run()
        {
            ResetGame();

            Color windowColor = new Color(0, 0, 0);

            while (app.IsOpen)
            {
                app.DispatchEvents();
                
                app.Clear(windowColor);

                ball.UpdatePosition();
                leftPaddle.UpdatePosition();
                rightPaddle.UpdatePosition();
                
                app.Draw(leftPaddle);
                app.Draw(rightPaddle);
                app.Draw(ball);
                app.Draw(result);

                foreach (var border in borders)
                {
                    app.Draw(border);
                }

                app.Display();

                CheckCollisions();
            }
        }

        private void CheckCollisions()
        {
            var ballBounds = ball.GetGlobalBounds();
            if (ballBounds.Intersects(borders[0].GetGlobalBounds()))
            {
                ball.Angle = -ball.Angle;
            }
            if (ballBounds.Intersects(borders[1].GetGlobalBounds()))
            {
                leftPoints++;
                result.SetText($"LEFT {leftPoints} -||- {rightPoints} RIGHT");
                ResetGame();
            }
            if (ballBounds.Intersects(borders[2].GetGlobalBounds()))
            {
                ball.Angle = -ball.Angle;
            }
            if (ballBounds.Intersects(borders[3].GetGlobalBounds()))
            {
                rightPoints++;
                result.SetText($"LEFT {leftPoints} -||- {rightPoints} RIGHT");
                ResetGame();
            }
            if (ballBounds.Intersects(leftPaddle.GetGlobalBounds()))
            {
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
            leftPaddle.Position = new Vector2f(10 + leftPaddle.Size.X, (float)VideoMode.DesktopMode.Height / 2);
            rightPaddle.Position = new Vector2f(VideoMode.DesktopMode.Width - 10 - rightPaddle.Size.X, (float)VideoMode.DesktopMode.Height / 2);
            ball.Position = new Vector2f((float)VideoMode.DesktopMode.Width / 2 , (float)VideoMode.DesktopMode.Height / 2);
            ball.RandomAngle();
        }

        #region Events
        void OnClose(object sender, EventArgs e)
        {
            leftPaddle.RemoveGazeListener();
            rightPaddle.RemoveGazeListener();

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
