﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class RotationParameters : IParameters
    {
        public double Angle { get; set; }
        public ParameterInfo[] GetDesсription()
        {
            return new[]
            {
                new ParameterInfo { Name="Угол", MaxValue=360, MinValue=0, Increment=5, DefaultValue=0 }

            };
        }

        public void Parse(double[] parameters)
        {
            Angle = parameters[0];
        }
    }
}
