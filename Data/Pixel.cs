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
            set { r = Check(value); } 
        }
        public double G {
            get { return g; }
            set { g = Check(value); }
        }
        public double B {
            get { return b; }
            set { b = Check(value); }
        }
        public static Pixel operator *(Pixel pixel, double param) {
            pixel.R = Trim(pixel.R * param);
            pixel.G = Trim(pixel.G * param);
            pixel.B = Trim(pixel.B * param);
            return pixel;
        }

        public double Check(double val) {
            if (val < 0 || val > 1) throw new ArgumentException();
            return val;
        }

        public static double Trim(double val) {
            return val < 0 ? 0 : (val > 1 ? 1 : val);
        }
    }
}
