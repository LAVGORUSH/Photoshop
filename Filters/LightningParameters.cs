using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    class LightningParameters : IParameters
    {
        public double Coeficient { get; set; }
        public ParameterInfo[] GetDesсription()
        {
            return new[]
            {
                new ParameterInfo { Name="Коэффициент", MaxValue=10, MinValue=0, Increment=0.1, DefaultValue=1 }

            };
        }

        public void Parse(double[] parameters)
        {
            Coeficient = parameters[0];
        }
    }
}
