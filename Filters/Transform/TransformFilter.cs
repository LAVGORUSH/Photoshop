using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class TransformFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters : IParameters, new()
    {
        public string Name { get; set; }
        Func<Size, TParameters, Size> sizeTransform;
        Func<Size, Point, TParameters, Point?> pointTransform;

        public TransformFilter(string name, Func<Size, TParameters, Size> sizeTransform, Func<Size, Point, TParameters, Point?> pointTransform)
        {
            Name = name;
            this.sizeTransform = sizeTransform;
            this.pointTransform = pointTransform;
        }

        public override Photo Process(Photo original, TParameters parameters)
        {
            var oldSize = new Size(original.width, original.height);
            var newSize = sizeTransform(oldSize, parameters);
            var result = new Photo(newSize.Width, newSize.Height);
            for (int x = 0; x < newSize.Width; x++)
            {
                for (int y = 0; y < newSize.Height; y++)
                {
                    var point = new Point(x, y);
                    var oldPoint = pointTransform(oldSize, point, parameters);
                    if (oldPoint.HasValue)
                    {
                        result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
                    }
                }
            }
            return result;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
