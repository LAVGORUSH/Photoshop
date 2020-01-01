using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class Pixel
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
    }
}
