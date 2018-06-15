using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Learning_XNA_Example1
{
	public class AnimateSprites : Sprite
	{
		#region Constructor
		Point frameSize;
		Point currentFrame;
		Point sheetSize;

		public AnimateSprites(Texture2D texture, Point frameSize, Point currentFrame, Point sheetSize)
		{
			this.texture = texture;
			this.frameSize = frameSize;
			this.currentFrame = currentFrame;
			this.sheetSize = sheetSize;
		}

		#endregion

		#region Propiedades

		public Point FrameSize 
		{ 
			get { return frameSize; } 
		}

		public Point CurrentFrame
		{
			get { return currentFrame; }
		}

		public Point SheetSize
		{
			get { return sheetSize; }
		}

		public new Rectangle source
		{
			get { return new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y); }
		}

		#endregion

		public void Update()
		{
			++currentFrame.X;
			if (currentFrame.X >= sheetSize.X)
			{
				currentFrame.X = 0;
				++currentFrame.Y;
				if (currentFrame.Y >= sheetSize.Y)
					currentFrame.Y = 0;
			}
		}
	}
}
