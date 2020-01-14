using System;

namespace MyPhotoshop
{
	public class LighteningFilter : PixelFilter<LightningParameters>
	{
		public override string ToString ()
		{
			return "Осветление/затемнение";
		}
		
		public override Pixel ProcessPixel(Pixel original, LightningParameters parameters)
		{
			return original * parameters.Coeficient;
		}
	}
}

