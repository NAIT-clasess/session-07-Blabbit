using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AssignmentGame
{
    public class SimpleAnimation
    {
        private Texture2D _spriteSheet;
        private int _frameWidth;
        private int _frameHeight;
        private int _frameCount;
        private int _currentFrame;
        private double _timer;
        private double _interval;

        public Vector2 Position;

        public SimpleAnimation(Texture2D sheet, int frameWidth, int frameHeight, int frameCount, double interval)
        {
            _spriteSheet = sheet;
            _frameWidth = frameWidth;
            _frameHeight = frameHeight;
            _frameCount = frameCount;
            _interval = interval;
            _currentFrame = 0;
            _timer = 0;
            Position = Vector2.Zero;
        }

        public void Update(GameTime gameTime)
        {
            _timer += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_timer > _interval)
            {
                _currentFrame++;
                if (_currentFrame >= _frameCount)
                    _currentFrame = 0;

                _timer = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle source = new Rectangle(_currentFrame * _frameWidth, 0, _frameWidth, _frameHeight);
            spriteBatch.Draw(_spriteSheet, Position, source, Color.White);
        }
    }
}