using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UniversityRankingAPI.Models;
using UniversityRankingAPI.Models.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UniversityDataController : ControllerBase
    {
        private readonly UniversityContext _context;
        private readonly ILogger<UniversityDataController> _logger;

        public UniversityDataController(ILogger<UniversityDataController> logger, UniversityContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<UniversityDataPage> Get(int pageNumber, int perPage)
        {
            var dataPage = await this._context.UniversityData
                 .Include(data => data.location)
                 .ToListAsync();
            var nonPaginatedSorted = this.OrderDatasByScore(dataPage);

            //If user requeseted more items per page than what we have available, return entire contents of table.
            if (perPage > dataPage.Count)
            {
                return new UniversityDataPage()
                {
                    page = 0,
                    per_page = dataPage.Count,
                    total = dataPage.Count,
                    totlPages = 1,
                    data = nonPaginatedSorted.ToList()
                };

            }
            else
            {
                UniversityData[] paginatedData = new UniversityData[perPage];
                //pull range of results, start at index:(zero-indexed page number * results per page), add requested amount of results per page to paginated result.
                dataPage.CopyTo(0, paginatedData, (perPage * pageNumber), perPage);
                var paginatedSorted = this.OrderDatasByScore(paginatedData);



                return new UniversityDataPage()
                {
                    page = 0,
                    per_page = perPage,
                    total = dataPage.Count,
                    totlPages = 1,
                    data = paginatedSorted
                };
            }
        }

        private List<UniversityData> OrderDatasByScore(IEnumerable<UniversityData> datas)
        {
            var sorted = datas.OrderByDescending(x => x.score).ToList();
            for (int i = 1; i <= sorted.Count; i++)
            {
                sorted[i - 1].rank_display = i.ToString();
            }
            return sorted;
        }
    }
}
