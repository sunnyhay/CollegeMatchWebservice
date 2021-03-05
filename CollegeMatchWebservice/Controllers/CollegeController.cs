using CollegeDataService;
using CollegeMatchWebservice.Models;
using CollegeMatchWebservice.Util;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeMatchWebservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollegeController : Controller
    {
        private readonly ICosmosDBDataService _dbService;

        public CollegeController(ICosmosDBDataService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IEnumerable<College> Get()
        {
            var college1 = new College()
            {
                Id = "100663",
                Name = "University of Alabama at Birmingham",
                City = "Birmingham",
                StateBrief = "AL",
                Url = "https://www.uab.edu"
            };
            var college2 = new College()
            {
                Id = "100724",
                Name = "Alabama State University",
                City = "Montgomery",
                StateBrief = "AL",
                Url = "www.alasu.edu"
            };
            var college3 = new College()
            {
                Id = "100937",
                Name = "Birmingham-Southern College",
                City = "Birmingham",
                StateBrief = "AL",
                Url = "www.bsc.edu/"
            };
            var colleges = new College[]
            {
                college1, college2, college3
            };

            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Task.Delay(2000).Wait();

            return colleges;
        }

        [HttpPost]
        [Route("/Match")]
        public async Task<IEnumerable<MatchData>> SearchMatch(Input input)
        {
            var userInput = JsonConvert.SerializeObject(Utils.ParseUserInput(input));
            var query = $"select * from c where udf.AcademicMatch(c, {userInput}) = 4 and c.RankType = 1 order by c.Rank offset 0 limit 20";
            var result = await _dbService.MatchColleges<MatchData>(query);
            Console.WriteLine("result number: " + result.Count);
            return result;
        }

        [HttpPost]
        public async Task<IEnumerable<College>> SearchCollege(Input input)
        {
            // search MatchData table to match the college searching criteria
            var userInput = JsonConvert.SerializeObject(Utils.ParseUserInput(input));
            var query = $"select * from c where udf.AcademicMatch(c, {userInput}) = 4 and c.RankType = 1 order by c.Rank offset 0 limit 20";
            var matches = await _dbService.MatchColleges<MatchData>(query);
            List<string> ids = new List<string>();
            foreach(var match in matches)
            {
                ids.Add(match.UNITID);
            }

            // fetch all qualified colleges
            var insideStr = "";
            foreach (var id in ids)
            {
                insideStr += "\"" + id + "\",";
            }
            var query1 = $"select * from c where c.UNITID in ({insideStr.Substring(0, insideStr.Length - 1)})";
            Console.WriteLine("new query: " + query1);
            var colleges = await _dbService.SearchColleges<College>(query1);
            
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return colleges;
        }
    }
}
