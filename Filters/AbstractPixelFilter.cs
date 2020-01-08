using System;

namespace MyPhotoshop
{
	public abstract class AbstractPixelFilter : IFilter
	{
		public virtual ParameterInfo[] GetParameters()
		{
			return new ParameterInfo[0];
		}
		
		public Photo Process(Photo original, double[] parameters)
		{
			var result=new Photo(original.width, original.height);
			for (int x = 0; x < result.width; x++)
				for (int y = 0; y < result.height; y++)
				{
					result[x, y] = ProcessPixel(original[x, y],parameters);
				}
			return result;
		}

		public abstract Pixel ProcessPixel(Pixel original, double[] parameters);
	}
}

