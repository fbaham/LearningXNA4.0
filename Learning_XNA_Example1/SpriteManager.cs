using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Learning_XNA_Example1
{
	public class SpriteManager: DrawableGameComponent
	{
		SpriteBatch spriteBatch;
		UserControlledSprite player;
		List<Sprite> spriteList = new List<Sprite>();

		Color bgColor = Color.CornflowerBlue;
		bool collision = false;

		public SpriteManager(Game game)
		   : base(game)
		{
			// TODO: Construct any child components here
		}

		public override void Initialize()
		{
			// TODO: Add your initialization code here

			base.Initialize();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(Game.GraphicsDevice);

			player = new UserControlledSprite(Game.Content.Load<Texture2D>("Sprites/threerings"), Vector2.Zero, new Point(75, 75),
			                                  10, new Point(0, 0), new Point(6, 8), new Vector2(6, 6));

			spriteList.Add(new BouncingSprite(Game.Content.Load<Texture2D>("Sprites/plus"), new Vector2(100, 400),
			                                  new Point(75, 75), 10, new Point(0, 0), new Point(6, 4), new Vector2(4,4)));

			spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>("Sprites/skullball"), new Vector2(150, 150), 
			                                   new Point(75, 75), 10, new Point(0, 0), new Point(6, 8), Vector2.Zero));
			spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>("Sprites/skullball"), new Vector2(300, 150), 
			                                   new Point(75, 75), 10, new Point(0, 0), new Point(6, 8), Vector2.Zero));
			spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>("Sprites/skullball"), new Vector2(150, 300), 
			                                   new Point(75, 75), 10, new Point(0, 0), new Point(6, 8), Vector2.Zero));
			spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>("Sprites/skullball"), new Vector2(600, 400), 
			                                   new Point(75, 75), 10, new Point(0, 0), new Point(6, 8), Vector2.Zero));



			base.LoadContent();
		}

		public override void Update(GameTime gameTime)
		{
			// Actualiza jugador
			player.Update(gameTime, Game.Window.ClientBounds);

			// Actualiza todos los sprites
			foreach (Sprite s in spriteList)
			{
				s.Update(gameTime, Game.Window.ClientBounds);

				// Controla las colisiones
				if (player.collisionRect.Intersects(s.collisionRect))
					collision = true;
				/// Reparar el problema que se produce con los elementos del spriteList.
			}
			if (collision)
				bgColor = Color.Red;
			else
				bgColor = Color.CornflowerBlue;

			collision = false;

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(bgColor);

			spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
			// Draw the player
			player.Draw(gameTime, spriteBatch);

			// Draw all sprites
			foreach (Sprite s in spriteList)
				s.Draw(gameTime, spriteBatch);

			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
