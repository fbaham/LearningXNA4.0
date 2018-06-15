using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Learning_XNA_Example1
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		AnimateSprites player;
		AnimateSprites player2;
		AnimateSprites ring;

		Vector2 pos1 = Vector2.Zero;
		Vector2 pos2 = Vector2.Zero;
		float speed1 = 2f;
		float speed2 = 3f;

		//Ajusta el framerate de un sprite
		int timeSinceLastFrame = 0;
		int millisecondsPerFrame = 50;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			player = new AnimateSprites(Content.Load<Texture2D>("Sprites/player1"), new Point(48, 48), new Point(0, 0), new Point(8, 5));
			player2 = new AnimateSprites(Content.Load<Texture2D>("Sprites/player2"), new Point(48, 48), new Point(0, 0), new Point(8, 5));
			ring = new AnimateSprites(Content.Load<Texture2D>("Sprites/threerings"), new Point(75, 75), new Point(0, 0), new Point(6, 8));
			//player.position = new Vector2(Window.ClientBounds.Width/2 - player.texture.Width/2, Window.ClientBounds.Height/2 - player.texture.Height/2);
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
#if !__IOS__ && !__TVOS__
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
#endif

			pos1.X += speed1;
			if (pos1.X > Window.ClientBounds.Width - player.FrameSize.X || pos1.X < 0)
				speed1 *= -1;

			pos2.Y += speed2;
			if (pos2.Y > Window.ClientBounds.Height - player.FrameSize.Y || pos2.Y < 0)
				speed2 *= -1;

			/// pgameTime.ElapsedGameTime.Milliseconds entrega el tiempo transcurrido entre cada llamada al metodo update en milisegundos.
			/// timeSinceLastFrame acumula el tiempo hasta superar el valor de la variable millisecondsPerFrame.
			/// Actualmente esa variable se encuentra configurada con un valor de 50, lo que permite que el framerate del sprite sea de 20fps.
			timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
			if (timeSinceLastFrame > millisecondsPerFrame)
			{
				/// reiniciamos el valor de timeSinceLastFrame
				timeSinceLastFrame -= millisecondsPerFrame;
				ring.Update();
				player.Update();
				player2.Update();
			}

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
			spriteBatch.Draw(player.texture, pos1, player.source, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
			spriteBatch.Draw(player2.texture, pos2, player2.source, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
			spriteBatch.Draw(ring.texture, Vector2.Zero, ring.source, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
