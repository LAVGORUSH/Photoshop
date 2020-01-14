using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public abstract class ParametrizedFilter<TParameters> : IFilter
        where TParameters : IParameters, new()
    {
       
        public ParameterInfo[] GetParameters()
        {
            return new TParameters().GetDesсription();
        }

        public Photo Process(Photo original, double[] parameters)
        {
            var param = new TParameters();
            param.Parse(parameters);
            return Process(original, param);
        }

        public abstract Photo Process(Photo original, TParameters parameters);
    }
}
