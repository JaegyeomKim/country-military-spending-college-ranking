using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _420FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EffectController : ControllerBase
    {
        // GET: api/<EffectController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EffectData>>> GetOrdersData()
        {
            var context = new Models.FinalDBContext();
            return await context.EducationEffectTables.Select(t => new EffectData
            {
                effectId = t.EffectId,
                universityId = t.UniversityId,
                defenseId = t.DefenseId,
                countryId = t.CountryId,
                worldUniversityRanking = t.WorldUniversityRanking,
            }).ToListAsync();
        }

        // GET api/<EffectController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EffectController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EffectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EffectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


    public class EffectData
    {
        public double effectId { get; set; }
        public double universityId { get; set; }
        public double defenseId { get; set; }
        public double countryId { get; set; }
        public double worldUniversityRanking { get; set; }
    }
}
