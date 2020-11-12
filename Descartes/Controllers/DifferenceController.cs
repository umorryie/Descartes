using Descartes.DifferenceDeterminator;
using Descartes.Entities;
using Descartes.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpPut]
        [Route("{id}/left")]
        public String saveLeft([FromBody] RequestDifferenceInputHelper requestInput, int id)
        {
            return _differenceRepository.saveObject("left", requestInput, id);
        }

        [HttpPut]
        [Route("{id}/right")]
        public String saveRight([FromBody] RequestDifferenceInputHelper requestInput, int id)
        {
            return _differenceRepository.saveObject("right", requestInput, id);
        }

        [HttpGet]
        [Route("{id}")]
        public object getDifferences(int id)
        {
            string differences = _differenceRepository.determineDifferences(id);
            return JsonConvert.DeserializeObject<DifferenceResponse>(differences);
        }

        [HttpGet]
        [Route("getAllDatabaseContent")]
        public List<DifferenceObject> getAllDatabaseContent()
        {
            return _differenceRepository.getAllDatabaseContent();
        }
    }

    public class RequestDifferenceInputHelper
    {
        public string data { get; set; }
    }
}
