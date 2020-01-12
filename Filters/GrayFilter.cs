using System;

namespace MyPhotoshop
{
	public class GrayFilter : AbstractPixelFilter
	{
		public GrayFilter() : base( new EmptyParameters())
		{
		}

		public override string ToString ()
		{
			return "Оттенки серого";
		}

		public override Pixel ProcessPixel(Pixel original, IParameters parameters)
		{
			var lightness = original.R + original.G + original.B;
			lightness /= 3;
			return new Pixel(lightness, lightness, lightness);
		}
	}
}

