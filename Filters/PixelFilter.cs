using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class PixelFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters : IParameters, new()
    {
        public string Name { get; set; }
        public Func<Pixel, TParameters, Pixel> process { get; set; }

        public PixelFilter(string name, Func<Pixel, TParameters, Pixel> process)
        {
            Name = name;
            this.process = process;
        }

        public override Photo Process(Photo original, TParameters parameters)
        {
            var result = new Photo(original.width, original.height);
            for (int x = 0; x < result.width; x++)
                for (int y = 0; y < result.height; y++)
                {
                    result[x, y] = process(original[x, y], parameters);
                }
            return result;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
