using Descartes.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Descartes.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("v1/diff/")]
    public class DifferenceController : ControllerBase
    {
        private IDifferenceRepository _differenceRepository;

        public DifferenceController(IDifferenceRepository differenceRepository)
        {
            _differenceRepository = differenceRepository;
        }

        [HttpPut("{id}/left")]
        public String saveLeft()
        {
            return(_differenceRepository.saveObject("left"));
        }

        [HttpPut("{id}/right")]
        public String saveRight()
        {
            return (_differenceRepository.saveObject("right"));
        }

        [HttpGet("{id}")]
        public String getDifferences()
        {
            return (_differenceRepository.determineDifferences());
        }
    }
}
