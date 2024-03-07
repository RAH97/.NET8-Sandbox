using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UniversityRankingAPI.Models.Entities.Configurations;

namespace UniversityRankingAPI.Models.Entities
{
    [EntityTypeConfiguration(typeof(UniveristyDataEntityTypeConfiguration))]
    public class UniversityData
    {
        [Key]
        public int Id { get; set; }
        public string university { get; set; }
        public string rank_display { get; set; }
        public decimal score { get; set; }
        public string type { get; set; }
        public int student_faculty_ratio { get; set; }
        public string international_students { get; set; }
        public string faculty_count { get; set; }
        public Location location { get; set; }
    }
}
