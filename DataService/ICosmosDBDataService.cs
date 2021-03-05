using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeDataService
{
    public interface ICosmosDBDataService
    {
        Task<List<T>> SearchColleges<T>(string query);
        Task<List<T>> MatchColleges<T>(string query);
    }
}
