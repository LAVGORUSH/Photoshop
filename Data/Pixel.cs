using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public struct Pixel
    {
        private double r;
        public double R { 
            get { return r; }
            set {r = CheckValue(value);}
        }
        private double g;
        public double G
        {
            get { return g; }
            set { g = CheckValue(value); }
        }
        private double b;
        public double B
        {
            get { return b; }
            set { b = CheckValue(value); }
        }

        public double CheckValue(double val) {
            if (val < 0 || val > 1) throw new ArgumentException();
            return val;
        }
        public static double Trim(double val)
        {
            return val < 0 ? 0 : (val > 1 ? 1 : val);
        }

        public Pixel(double r, double g, double b) : this()
        {
            R = r;
            G = g;
            B = b;
        }

        public static Pixel operator *(Pixel p, double c) {
            return new Pixel(Trim(p.R * c), Trim(p.G * c), Trim(p.B * c));
        }
    }
}
