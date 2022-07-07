using _420FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace _420FinalProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OtherGetController : ControllerBase
    {
        // GET: api/<OtherGetController>
        [HttpGet]
        [ActionName("GetCountry")]
        public IEnumerable<CountryTable> GetCountry()
        {
            var context = new Models.FinalDBContext();
            return context.CountryTables.ToList();
        }

        [HttpGet]
        [ActionName("GetUniversity")]
        public IEnumerable<UniversityTable> GetUniversity()
        {
            var context = new Models.FinalDBContext();
            return context.UniversityTables.ToList();
        }



        //api/OtherGet/Test/32
        [HttpGet("{id}")]
        [ActionName("Test")]
        public NationalDefense GetDefense(int id)
        {
            var context = new Models.FinalDBContext();
            var myDefense =
                (from oneDefense in context.NationalDefenseTables
                 from oneResult in context.EducationEffectTables
                 where oneResult.CountryId == oneResult.CountryId
                 where oneResult.CountryId == id && oneDefense.CountryId == id
                 select new NationalDefense
                {
                    country = oneResult.Country.Country,
                    spendMoney = oneDefense.SpendMoney
                }).First();

            return myDefense;
        }


        [HttpGet("{id}")]
        [ActionName("Test2")]
        //api/OtherGet/Test2
        public List<WorldUniversity> Get3(int id)
        {
            var context = new Models.FinalDBContext();

            var JoinCollection =

                from oneUniversity in context.UniversityTables
                from oneResult in context.EducationEffectTables
                where oneResult.UniversityId == oneUniversity.UniversityId
                where oneResult.CountryId == id
                orderby oneResult.WorldUniversityRanking
                select new WorldUniversity
                {
                    worldUniversityRanking = oneResult.WorldUniversityRanking,
                    institution = oneUniversity.Institution,
                    score = oneUniversity.Score,
                };

            List<WorldUniversity> myList = JoinCollection.ToList();
            return myList;
        }


        [HttpGet]
        [ActionName("Join2")]
        //api/OtherGet/Join2
        public List<TenWorldUniversity> Get2()
        {
            var context = new Models.FinalDBContext();

            var JoinCollection =

                from oneUniversity in context.UniversityTables
                from oneResult in context.EducationEffectTables
                where oneResult.UniversityId == oneUniversity.UniversityId
                where oneResult.WorldUniversityRanking <= 10
                orderby oneResult.WorldUniversityRanking

                select new TenWorldUniversity
                {
                    worldUniversityRanking = oneResult.WorldUniversityRanking,
                    institution = oneUniversity.Institution,
                };

            List<TenWorldUniversity> myList = JoinCollection.ToList();
            return myList;
        }


    }
    public class NationalDefense
    {
        public string? country { get; set; }
        public double spendMoney { get; set; }

    }

    public class TenWorldUniversity
    {
        public string? institution { get; set; }
        public double worldUniversityRanking { get; set; }
    }


    public class WorldUniversity
    {
        public string? institution { get; set; }
        public double score { get; set; }
        public double worldUniversityRanking { get; set; }

    }

    public class MyDefense
    {
        public double defenseId { get; set; }
        public double countryId { get; set; }
        public double spendMoney { get; set; }
    }

}
