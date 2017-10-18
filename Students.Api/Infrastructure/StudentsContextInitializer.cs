using Microsoft.EntityFrameworkCore;

namespace Students.Api.Infrastructure
{
    public static class StudentsContextInitializer
    {
        public static void InitializeDatabase(StudentsContext context)
        {
            context.Database.Migrate();
        }
    }
}
