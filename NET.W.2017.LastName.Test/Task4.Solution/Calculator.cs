using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4.Solution
{
    public class Calculator
    {
        public double CalculateAverage(List<double> values, IAverageMethod method)
        {
            if (ReferenceEquals(values,null))
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (ReferenceEquals(method, null))
            {
                throw new ArgumentNullException(nameof(method));
            }

            return method.AvarageMethod(values);

        }
    }
}
