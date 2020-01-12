using System;

namespace MyPhotoshop
{
	public abstract class AbstractPixelFilter : ParametrizedFilter
	{
		public AbstractPixelFilter(IParameters parameters) : base(parameters)
		{
		}

		public override Photo Process(Photo original, IParameters parameters)
		{
			var result=new Photo(original.width, original.height);
			for (int x = 0; x < result.width; x++)
				for (int y = 0; y < result.height; y++)
				{
					result[x, y] = ProcessPixel(original[x, y],parameters);
				}
			return result;
		}

		public abstract Pixel ProcessPixel(Pixel original, IParameters parameters);
	}
}

