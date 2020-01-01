using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class Pixel
    {
        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }
        public static Pixel operator *(Pixel pixel, double param) {
            pixel.R *= param;
            pixel.G *= param;
            pixel.B *= param;
            return pixel;
        }
    }
}
