using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Learning_XNA_Example1
{
	class UserControlledSprite: Sprite
	{
		MouseState prevMouseState;

		public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame, 
		                            Point sheetSize, Vector2 speed)
			: base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed)
		{
		}

		public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame, 
		                            Point sheetSize, Vector2 speed, int millisecondsPerFrame)
			: base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, millisecondsPerFrame)
		{
		}

		public override Vector2 direction
		{
			get
			{
				Vector2 inputDirection = Vector2.Zero;
				KeyboardState keyboardState = Keyboard.GetState();
				if (keyboardState.IsKeyDown(Keys.Left))
					inputDirection.X -= 1;
				if (keyboardState.IsKeyDown(Keys.Right))
					inputDirection.X += 1;
				if (keyboardState.IsKeyDown(Keys.Up))
					inputDirection.Y -= 1;
				if (keyboardState.IsKeyDown(Keys.Down))
					inputDirection.Y += 1;

				GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);
				if (gamepadState.ThumbSticks.Left.X != 0)
					inputDirection.X += gamepadState.ThumbSticks.Left.X;
				if (gamepadState.ThumbSticks.Left.Y != 0)
					inputDirection.Y -= gamepadState.ThumbSticks.Left.Y;

				return inputDirection * speed;
			}
		}

		public override void Update(GameTime gameTime, Rectangle clientBounds)
		{
			// Mueve el sprite en la direccion
			position += direction;

			// si el jugador mueve el mouse, mueve el sprite
			MouseState currentMouseState = Mouse.GetState();
			if (currentMouseState.X != prevMouseState.X || currentMouseState.Y != prevMouseState.Y)
			{
				position = new Vector2(currentMouseState.X, currentMouseState.Y);
			}
			prevMouseState = currentMouseState;

			/// Limita el movimiento del objeto al ancho y largo de la ventana
			if (position.X < 0)
				position.X = 0;
			if (position.Y < 0)
				position.Y = 0;
			if (position.X > clientBounds.Width - frameSize.X)
				position.X = clientBounds.Width - frameSize.X;
			if (position.Y > clientBounds.Height - frameSize.Y)
				position.Y = clientBounds.Height - frameSize.Y;

			base.Update(gameTime, clientBounds);
		}

	}
}
