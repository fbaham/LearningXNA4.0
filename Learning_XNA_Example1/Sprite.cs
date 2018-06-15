using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Learning_XNA_Example1
{
	public class Sprite
	{
		/// Textura a dibujar
		public Texture2D texture { get; set;}
		/// Coordina desde la esquina superior izquierda la posición en la cual se dibujará la tectura
		public Vector2 position { get; set;}
		/// Permite dibujar solo una porción de la textura 
		public Rectangle source { get; set;}
		/// Color sobrepuesto a la textura, usa White para no sobreponer nada
		public Color color { get; set; }
		/// Rota la imagen
		public float rotation { get; set; }
		/// Indica el origen desde donde rotar la imagen
		public Vector2 origin { get; set; }
		/// Escala la textura
		public float scale { get; set; }
		/// Usa para voltear la imagen de forma horizontal o vertical
		public SpriteEffects effects { get; set; }
		/// Especifica qué imagen está por sobre la otra
		public float layerDepth { get; set; }


		//public void Draw(SpriteBatch spriteBatch)
		//{
		//	/// Llamada simple al metodo Draw
		//	//spriteBatch.Draw(texture, position, color);

		//	/// Llamada completa al metodo Draw
		//	spriteBatch.Draw(texture, position, null, color, rotation, origin, scale, effects, layerDepth);

		//}
	}
}
