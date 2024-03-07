using UniversityRankingAPI.Models.Entities;

namespace UniversityRankingAPI.Models
{
    public class UniversityDataPage
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int totlPages { get; set; }
        public List<UniversityData> data { get; set; }
    }
}
