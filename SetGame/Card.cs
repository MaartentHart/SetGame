using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetGame
{
	public class Card
	{
		public readonly int index; 
		public readonly int color;
		public readonly int amount;
		public readonly int shape;
		public readonly int fill; 
		public Card(int i)
		{
			if (i < 0 || i >= 81)
				throw new IndexOutOfRangeException();
			index = i;
			fill = i % 3;
			i /= 3;

			amount = i % 3;
			i /= 3;

			shape = i % 3;
			i /= 3;

			color = i % 3;
			
		}

		internal Image Compose()
		{
			Image shapeImage = null;
			if (shape == 0)
				shapeImage = Image.FromFile("Cards\\BAR.png");
			else if (shape == 1)
				shapeImage = Image.FromFile("Cards\\OVAL.png");
			else if (shape == 2)
				shapeImage = Image.FromFile("Cards\\TWIST.png");

			Bitmap bitmap = new Bitmap(256, 256);

			Color paintColor = Color.Red;
			if (color == 1)
				paintColor = Color.Green;
			else if (color == 2)
				paintColor = Color.Purple;

			shapeImage = SetColor(shapeImage, paintColor, fill);

			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.Clear(Color.White);
				if (amount == 0)
				{
					graphics.DrawImage(shapeImage, new Point(0, 96));
				}
				else if (amount == 1)
				{
					graphics.DrawImage(shapeImage, new Point(0, 64));

					graphics.DrawImage(shapeImage, new Point(0, 128));
				}
				else if (amount == 2)
				{
					graphics.DrawImage(shapeImage, new Point(0, 32));
					graphics.DrawImage(shapeImage, new Point(0, 96));

					graphics.DrawImage(shapeImage, new Point(0, 160));
				}
			}
			shapeImage.Dispose();
			return bitmap; 
		}

		private Image SetColor(Image image, Color color, int fillType)
		{
			Color empty = Color.White; 
			Bitmap bitmap = new Bitmap(image);
			Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

			System.Drawing.Imaging.BitmapData bmpData =
					bitmap.LockBits(rect,
							System.Drawing.Imaging.ImageLockMode.ReadOnly,
							bitmap.PixelFormat);
			IntPtr ptr = bmpData.Scan0;

			int bytes = bmpData.Stride * bitmap.Height;
			byte[] rgbValues = new byte[bytes];

			System.Runtime.InteropServices.Marshal.Copy(ptr,
										 rgbValues, 0, bytes);
			
			for (int x = 0; x < bitmap.Width; x++)
			{
				for (int y = 0; y < bitmap.Height; y++)
				{
					Color use = empty;

					//See the link above for an explanation 
					//of this calculation
					int position = (y * bmpData.Stride) + (x * Image.GetPixelFormatSize(bmpData.PixelFormat) / 8);
					byte blue = rgbValues[position];
					byte green = rgbValues[position + 1];
					byte red = rgbValues[position + 2];
					
					if (red > 200)
						use = color;
					else if (green > 200 && fillType >0)
						use = color;
					else if (blue > 200 && fillType ==2)
						use = color;

					red = use.R;
					green = use.G;
					blue = use.B; 

					rgbValues[position] = blue;
					rgbValues[position + 1] = green;
					rgbValues[position + 2] = red;
				}
			}


			System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

			bitmap.UnlockBits(bmpData);
			image.Dispose();
			return bitmap;
		}
	}
}
