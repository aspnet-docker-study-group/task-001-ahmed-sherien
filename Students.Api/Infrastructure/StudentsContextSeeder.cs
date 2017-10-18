using Students.Api.Models;
using System.Linq;

namespace Students.Api.Infrastructure
{
    public static class StudentsContextSeeder
    {
        public static void SeedData(StudentsContext context)
        {
            if (!context.Students.Any())
            {
                context.Students.Add(new Student
                {
                    FirstName = "Ahmed",
                    LastName = "Sherien",
                    NationalId = "1122334455667788",
                    Email = "eng.a.sherien@gmail.com"
                });
                context.SaveChanges();
            }
        }
    }
}
