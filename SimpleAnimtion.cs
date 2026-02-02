using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AssignmentGame
{
    public class SimpleAnimation
    {
        private Texture2D _spriteSheet;      // The sprite sheet texture containing animation frames
        private int _frameWidth;             // Width of a single frame
        private int _frameHeight;            // Height of a single frame
        private int _frameCount;             // Total number of frames in the animation
        private int _currentFrame;           // Index of the current frame being displayed
        private double _timer;               // Timer to track frame changes
        private double _interval;            // Time interval between frames (in milliseconds)

        public Vector2 Position;             // Position to draw the animation on screen

        // Constructor to initialize animation properties
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

        // Updates the animation frame based on elapsed time
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

        // Draws the current frame of the animation at the specified position
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle source = new Rectangle(_currentFrame * _frameWidth, 0, _frameWidth, _frameHeight);
            spriteBatch.Draw(_spriteSheet, Position, source, Color.White);
        }
    }
}