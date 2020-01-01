using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class Pixel
    {
        private double r;
        private double g;
        private double b;
        public double R { 
            get { return r; }
            set { r = r > 1 ? 1 : value; } 
        }
        public double G {
            get { return r; }
            set { g = g > 1 ? 1 : value; }
        }
        public double B {
            get { return b; }
            set { b = b > 1 ? 1 : value; }
        }
        public static Pixel operator *(Pixel pixel, double param) {
            pixel.R *= param;
            pixel.G *= param;
            pixel.B *= param;
            return pixel;
        }
    }
}
