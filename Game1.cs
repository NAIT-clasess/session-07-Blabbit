using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AssignmentGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Assets
        private Texture2D _background;
        private Texture2D _staticImage;
        private Texture2D _animSheet;
        private SpriteFont _font;

        // Static sprite position (keyboard movement)
        private Vector2 _staticPos = new Vector2(100, 300);
        private float _speed = 200f;

        // Animated sprite position (automatic movement)
        private Vector2 _animPos = new Vector2(50, 50);
        private float _autoSpeed = 100f;

        // Animation variables
        private int _frameWidth;
        private int _frameHeight;
        private int _currentFrame = 0;
        private double _timer = 0;
        private double _interval = 0.15; // seconds per frame
        private int _totalFrames = 8; // your skeleton sheet has 8 poses

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _background = Content.Load<Texture2D>("background");
            _staticImage = Content.Load<Texture2D>("staticImage");
            _animSheet = Content.Load<Texture2D>("anim1");
            _font = Content.Load<SpriteFont>("Font");

            // Calculate frame size for animation
            _frameWidth = _animSheet.Width / _totalFrames;
            _frameHeight = _animSheet.Height;
        }

        protected override void Update(GameTime gameTime)
        {
            var k = Keyboard.GetState();
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Exit
            if (k.IsKeyDown(Keys.Escape))
                Exit();

            // Keyboard movement for static sprite
            if (k.IsKeyDown(Keys.Left))
                _staticPos.X -= _speed * dt;
            if (k.IsKeyDown(Keys.Right))
                _staticPos.X += _speed * dt;
            if (k.IsKeyDown(Keys.Up))
                _staticPos.Y -= _speed * dt;
            if (k.IsKeyDown(Keys.Down))
                _staticPos.Y += _speed * dt;

            // Automatic movement for animated sprite
            _animPos.X += _autoSpeed * dt;

            // Loop animation
            _timer += gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer >= _interval)
            {
                _currentFrame++;
                if (_currentFrame >= _totalFrames)
                    _currentFrame = 0;

                _timer = 0;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // Draw background
            _spriteBatch.Draw(_background, new Rectangle(0, 0, 800, 480), Color.White);

            // Draw static sprite
            _spriteBatch.Draw(_staticImage, _staticPos, Color.White);

            // Draw animated sprite
            Rectangle sourceRect = new Rectangle(
                _frameWidth * _currentFrame,
                0,
                _frameWidth,
                _frameHeight
            );

            _spriteBatch.Draw(_animSheet, _animPos, sourceRect, Color.White);

            // Draw text
            _spriteBatch.DrawString(_font, "Assignment Game - Tavien", new Vector2(10, 10), Color.Yellow);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}