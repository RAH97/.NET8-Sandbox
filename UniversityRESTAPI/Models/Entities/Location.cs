using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UniversityRankingAPI.Models.Entities.Configurations;

namespace UniversityRankingAPI.Models.Entities
{
    [EntityTypeConfiguration(typeof(LocationEntityTypeConfiguration))]
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public Location(string city, string country, string region)
        {
            city = this.city;
            country = this.country;
            region = this.region;
        }
    }
}
