using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Descartes.Repository
{
    public interface IDifferenceRepository
    {
        public string determineDifferences();

        public string saveObject(string identifier);
    }
}
