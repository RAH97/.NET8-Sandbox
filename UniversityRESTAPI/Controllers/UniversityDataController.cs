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
            var dataPage = await this._context.UniversityData.ToListAsync();
            if(perPage > dataPage.Count)
            {
                return new UniversityDataPage()
                {
                    page = 0,
                    per_page = dataPage.Count,
                    total = dataPage.Count,
                    totlPages = 1,
                    data = dataPage.ToList()
                };

            }
            else
            {
                UniversityData[] paginatedData = new UniversityData[perPage];
                //pull range of results, start at index:(zero-indexed page number * results per page), add requested amount of results per page to paginated result.
                dataPage.CopyTo(0, paginatedData, (perPage * pageNumber), perPage);

                var paginatedSorted = paginatedData.OrderByDescending(x => x.score).ToList();
                for(int i = 1; i <= paginatedSorted.Count; i++)
                {
                    paginatedSorted[i - 1].rank_display = i.ToString();
                }

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
    }
}
