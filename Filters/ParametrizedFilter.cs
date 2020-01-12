using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public abstract class ParametrizedFilter : IFilter
    {
        public IParameters Parameters;

        public ParametrizedFilter(IParameters parameters)
        {
            Parameters = parameters;
        }

        public ParameterInfo[] GetParameters()
        {
            return Parameters.GetDesсription();
        }

        public Photo Process(Photo original, double[] parameters)
        {
            Parameters.Parse(parameters);
            return Process(original, Parameters);
        }

        public abstract Photo Process(Photo original, IParameters parameters);
    }
}
