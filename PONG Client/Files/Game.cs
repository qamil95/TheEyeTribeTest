using System;
using Newtonsoft.Json;
using PONG_Client.Steering_modes;
using PONG_Common;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace PONG_Client
{
    internal class Game
    {
        private readonly Ball ball;
        private readonly Paddle playerPaddle;
        private readonly Paddle opponentPaddle;
        private readonly NetworkData opponentHeight;
        private readonly RectangleShape[] borders;
        private readonly RenderWindow app;
        private readonly CentralText result;
        private readonly Connection connection;

        public Game(ControlType controlType, bool? fullScreen, Connection connection)
        {
            if (fullScreen.HasValue && fullScreen.Value)
            {
                app = new RenderWindow(VideoMode.DesktopMode, "The Eye Tribe PONG Game Window", Styles.Fullscreen);
            }
            else
            {
                app = new RenderWindow(VideoMode.DesktopMode, "The Eye Tribe PONG Game Window", Styles.Default);
            }

            ball = new Ball();
            opponentHeight = new NetworkData();

            playerPaddle = AssignControlMode(controlType);
            opponentPaddle = AssignControlMode(ControlType.Network);

            borders = new RectangleShape[4];
            borders[0] = new RectangleShape(new Vector2f(app.Size.X, 3))
                {Position = new Vector2f(0, 0)};
            borders[1] = new RectangleShape(new Vector2f(3, app.Size.Y))
                {Position = new Vector2f(app.Size.X - 3, 0)};
            borders[2] = new RectangleShape(new Vector2f(app.Size.X, 3))
                {Position = new Vector2f(0, app.Size.Y - 3)};
            borders[3] = new RectangleShape(new Vector2f(3, app.Size.Y))
                {Position = new Vector2f(0, 0)};

            result = new CentralText(app.Size)
            {
                Font = new Font("consola.ttf"),
                Color = Color.Yellow
            };
            result.SetText("Waiting for connection");

            app.Closed += OnClose;
            app.KeyPressed += OnKeyPressed;
            app.SetFramerateLimit(60);

            this.connection = connection;
        }

        public void Run(PaddlePosition paddlePosition)
        {
            if (paddlePosition == PaddlePosition.Left)
            {
                playerPaddle.Position =
                    new Vector2f(10 + playerPaddle.Size.X, (float) VideoMode.DesktopMode.Height / 2);
                opponentPaddle.Position = new Vector2f(VideoMode.DesktopMode.Width - 10 - opponentPaddle.Size.X,
                    (float) VideoMode.DesktopMode.Height / 2);
            }
            else
            {
                opponentPaddle.Position =
                    new Vector2f(10 + opponentPaddle.Size.X, (float) VideoMode.DesktopMode.Height / 2);
                playerPaddle.Position = new Vector2f(VideoMode.DesktopMode.Width - 10 - playerPaddle.Size.X,
                    (float) VideoMode.DesktopMode.Height / 2);
            }

            ball.RandomAngle();
            ball.Position = new Vector2f((float)VideoMode.DesktopMode.Width / 2, (float)VideoMode.DesktopMode.Height / 2);

            var initState = new InitialState
            {
                StartBallAngle = ball.Angle,
                StartBallPosition = ball.Position,
                StartPaddlePosition = playerPaddle.Position
            };
            connection.SendMessage(JsonConvert.SerializeObject(initState));

            var windowColor = new Color(0, 0, 0);
            app.Draw(result);
            app.Display();

            while (app.IsOpen)
            {
                app.DispatchEvents();

                app.Clear(windowColor);

                var gameState = JsonConvert.DeserializeObject<GameState>(connection.ReceiveMessage());
                opponentHeight.SetCursorHeight(gameState.OpponentHeight);
                ball.SetPosition(gameState.BallPosition);

                playerPaddle.UpdatePosition();
                opponentPaddle.UpdatePosition();

                result.SetText($"LEFT {gameState.LeftPoints} -||- {gameState.RightPoints} RIGHT");

                app.Draw(playerPaddle);
                app.Draw(opponentPaddle);
                app.Draw(ball);
                app.Draw(result);

                foreach (var border in borders)
                {
                    app.Draw(border);
                }

                app.Display();

                var clientState = new ClientState();
                CheckCollisions(clientState);
                clientState.cursorHeight = playerPaddle.Position.Y;
                connection.SendMessage(JsonConvert.SerializeObject(clientState));
            }
        }

        private Paddle AssignControlMode(ControlType controlType)
        {
            switch (controlType)
            {
                case ControlType.Ball:
                    return new Paddle(new BallData(ball));

                case ControlType.Keyboard:
                    return new PaddleDirectional(new KeyboardData());

                case ControlType.Mouse:
                    return new PaddleDirectional(new MouseData());
                case ControlType.Mouse_Gaussian:
                    return new PaddleGaussian(new MouseData());
                case ControlType.Mouse_SetPosition:
                    return new Paddle(new MouseData());

                case ControlType.EyeTribe:
                    return new PaddleDirectional(new EyeData());
                case ControlType.EyeTribe_Gaussian:
                    return new PaddleGaussian(new EyeData());
                case ControlType.EyeTribe_SetPosition:
                    return new Paddle(new EyeData());

                case ControlType.Network:
                    return new Paddle(opponentHeight);

                default:
                    return new Paddle(new DummyData());
            }
        }

        private void CheckCollisions(ClientState clientState)
        {
            var ballBounds = ball.GetGlobalBounds();
            if (ballBounds.Intersects(borders[0].GetGlobalBounds()))
            {
                clientState.newBallAngle = -ball.Angle;
            }
            if (ballBounds.Intersects(borders[1].GetGlobalBounds()))
            {
                clientState.leftCollision = true;
                ball.RandomAngle();
                clientState.newBallAngle = ball.Angle;
            }
            if (ballBounds.Intersects(borders[2].GetGlobalBounds()))
            {
                clientState.newBallAngle = -ball.Angle;
            }
            if (ballBounds.Intersects(borders[3].GetGlobalBounds()))
            {
                clientState.rightCollision = true;
                ball.RandomAngle();
                clientState.newBallAngle = ball.Angle;
            }
            if (ballBounds.Intersects(opponentPaddle.GetGlobalBounds()))
            {
                if (ball.Position.Y > opponentPaddle.Position.Y)
                {
                    clientState.newBallAngle = Math.PI - ball.Angle + new Random().Next(20) * Math.PI / 180;
                }
                else
                {
                    clientState.newBallAngle = Math.PI - ball.Angle - new Random().Next(20) * Math.PI / 180;
                }
            }
            if (ballBounds.Intersects(playerPaddle.GetGlobalBounds()))
            {
                if (ball.Position.Y > playerPaddle.Position.Y)
                {
                    clientState.newBallAngle = Math.PI - ball.Angle + new Random().Next(20) * Math.PI / 180;
                }
                else
                {
                    clientState.newBallAngle = Math.PI - ball.Angle - new Random().Next(20) * Math.PI / 180;
                }
            }
        }

        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Escape:
                    OnClose(sender, EventArgs.Empty);
                    break;
            }
        }

        private void OnClose(object sender, EventArgs e)
        {
            playerPaddle.RemoveGazeListener();

            var window = (RenderWindow) sender;
            window.Close();
        }
    }
}