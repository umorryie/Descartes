using Descartes.Contex;
using Descartes.DifferenceDeterminator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Descartes.Repository
{
    public class DifferenceRepository: IDifferenceRepository
    {
        private IDifferenceDeterminatorResolver _differenceDeterminator;
        private DiffContext _diffContext;
        public DifferenceRepository(IDifferenceDeterminatorResolver differenceDeterminator, DiffContext diffContext)
        {
            _differenceDeterminator = differenceDeterminator;
            _diffContext = diffContext;
        }

        public string determineDifferences()
        {
            return _differenceDeterminator.determineDifferences();
        }

        private string saveRight()
        {
            return "";
        }

        private string saveLeft()
        {
            return "";
        }

        public string saveObject(string identifier)
        {
            return identifier == "left" ? saveLeft() : saveRight();
        }
        
    }
}
