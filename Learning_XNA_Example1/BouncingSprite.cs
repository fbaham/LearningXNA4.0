using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Learning_XNA_Example1
{
	class BouncingSprite: Sprite
	{
		public BouncingSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame, 
		                       Point sheetSize, Vector2 speed)
			: base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed)
		{
		}

		public BouncingSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame,
							   Point sheetSize, Vector2 speed, int millisecondsPerFrame)
			: base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, millisecondsPerFrame)
		{
		}

		public override Vector2 direction
		{
			get
			{ return speed; }
		}

		public override void Update(GameTime gameTime, Rectangle clientBounds)
		{
			position += direction;

			if (position.X < 0)
				speed *= -1;
			if (position.Y < 0)
				speed *= -1;
			if (position.X > clientBounds.Width - frameSize.X)
				speed *= -1;
			if (position.Y > clientBounds.Height - frameSize.Y)
				speed *= -1;

			base.Update(gameTime, clientBounds);
		}

	}
}
