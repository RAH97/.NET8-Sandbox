using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using UniversityRankingAPI.Models.Entities;

namespace UniversityRankingAPI.Migrations
{
    public class MockContextDataPopulator
    {
        private readonly UniversityContext _context;
        public MockContextDataPopulator(UniversityContext context)
        {
            this._context = context;
        }

        public async Task InsertMockUniversityData()
        {
            //Delete mock data if relic data exists in mock tables.
            int deleted = this._context.UniversityData.ExecuteDelete();
            int locationDeleted = this._context.UniversityData.ExecuteDelete();
            await this._context.SaveChangesAsync();

            //Create mock data.
            List<UniversityData> datas = new List<UniversityData>()
            {
                new UniversityData()
                {
                    university = "Case Western Reserve University",
                    faculty_count = "10104",
                    international_students = "2078",
                    location = new Location("Cleveland", "United States", "North America"),
                    score = 82.00M,
                    student_faculty_ratio = 11,
                    type = "Private",
                    rank_display = ""
                
                },
                new UniversityData()
                {
                    university = "THE Ohio State University",
                    faculty_count = "7399",
                    international_students = "5566",
                    location = new Location("Columbus", "United States", "North America"),
                    score = 85.00M,
                    student_faculty_ratio = 18,
                    type = "Public",
                    rank_display = ""
                },
                new UniversityData()
                {
                    university = "The University of Pittsburgh",
                    faculty_count = "4491",
                    international_students = "2963",
                    location = new Location("Pittsburgh", "United States", "North America"),
                    score = 83.00M,
                    student_faculty_ratio = 5,
                    type = "Public",
                    rank_display = ""
                
                },
                 new UniversityData()
                 {
                     university = "Massachusetts Institute of Technology ",
                     faculty_count = "1110",
                     international_students = "4329",
                     location = new Location("Cambridge", "United States", "North America"),
                     score = 98.00M,
                     student_faculty_ratio = 3,
                     type = "Private",
                     rank_display = ""
                 },
                    new UniversityData()
                    {
                        university = "Harvard University ",
                        faculty_count = "2048",
                        international_students = "6963",
                        location = new Location("New Haven", "United States", "North America"),
                        score = 97.00M,
                        student_faculty_ratio = 7,
                        type = "Private",
                        rank_display = ""
                    },
                    new UniversityData()
                    {
                        university = "Oxford University ",
                        faculty_count = "14841",
                        international_students = "12075",
                        location = new Location("Oxford", "United Kingdom", "Europe"),
                        score = 96.00M,
                        student_faculty_ratio = 11,
                        type = "Public",
                        rank_display = ""
                    },
                    new UniversityData()
                    {
                        university = "Cambridge University ",
                        faculty_count = "12437",
                        international_students = "9708",
                        location = new Location("Oxford", "United Kingdom", "Europe"),
                        score = 95.00M,
                        student_faculty_ratio = 11,
                        type = "Public",
                        rank_display = ""
                    },
                    new UniversityData()
                    {
                        university = "Imperial College London",
                        faculty_count = "8000",
                        international_students = "6800",
                        location = new Location("London", "United Kingdom", "Europe"),
                        score = 90.00M,
                        student_faculty_ratio = 7,
                        type = "Public",
                        rank_display = ""
                    },
                    new UniversityData()
                    {
                        university = "Universidad Nacional Autónoma de México",
                        faculty_count = "9947",
                        international_students = "6734",
                        location = new Location("Mexico City", "Mexico", "North America"),
                        score = 81.00M,
                        student_faculty_ratio = 17,
                        type = "Public",
                        rank_display = ""
                    },
                    new UniversityData()
                    {
                        university = "Tecnológico de Monterrey",
                        faculty_count = "3268",
                        international_students = "2710",
                        location = new Location("Monterrey", "Mexico", "North America"),
                        score = 84.00M,
                        student_faculty_ratio = 15,
                        type = "Public",
                        rank_display = ""
                    },
                     new UniversityData()
                    {
                        university = "Universidad de Guadalajara",
                        faculty_count = "15229",
                        international_students = "Unknown",
                        location = new Location("Guadalajara", "Mexico", "North America"),
                        score = 80.00M,
                        student_faculty_ratio = 7,
                        type = "Public",
                        rank_display = ""
                    },
                    new UniversityData()
                    {
                        university = "Technical University of Munich",
                        faculty_count = "795",
                        international_students = "10710",
                        location = new Location("Aachen", "Germany", "Europe"),
                        score = 89.00M,
                        student_faculty_ratio = 50,
                        type = "Public",
                        rank_display = ""
                    },
                    new UniversityData()
                    {
                        university = "RWTH Aachen University",
                        faculty_count = "795",
                        international_students = "11138",
                        location = new Location("Aachen", "Germany", "Europe"),
                        score = 87.00M,
                        student_faculty_ratio = 50,
                        type = "Public",
                        rank_display = ""
                    },
                    new UniversityData()
                    {
                        university = "Freie Universität Berlin",
                        faculty_count = "699",
                        international_students = "11138",
                        location = new Location("Berlin", "Germany", "Europe"),
                        score = 85.00M,
                        student_faculty_ratio = 41,
                        type = "Public",
                        rank_display = ""
                    },
                    new UniversityData()
                    {
                        university = "Heidelberg University",
                        faculty_count = "699",
                        international_students = "12730",
                        location = new Location("Heidelberg", "Germany", "Europe"),
                        score = 88.00M,
                        student_faculty_ratio = 48,
                        type = "Public",
                        rank_display = ""
                    },
            };

            await this._context.BulkInsertAsync(datas, type: typeof(UniversityData));
        }
    }
}
