using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Descartes.DifferenceDeterminator
{
    public interface IDifferenceDeterminatorResolver
    {
        public DifferenceResponse determineDifferences(string leftValue, string rightValue);
    }
}
