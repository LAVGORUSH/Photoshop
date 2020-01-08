using System;

namespace MyPhotoshop
{
	public class GrayFilter : AbstractPixelFilter
	{
		
		public override string ToString ()
		{
			return "Оттенки серого";
		}

		public override Pixel ProcessPixel(Pixel original,double[] parameters)
		{
			var lightness = original.R + original.G + original.B;
			lightness /= 3;
			return new Pixel(lightness, lightness, lightness);
		}
	}
}

