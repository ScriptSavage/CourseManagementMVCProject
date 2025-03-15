using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Context;

public class ProjectContextFactory : IDesignTimeDbContextFactory<ProjectContext>
{
    public ProjectContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<ProjectContext>();
            
       
        var connectionString = 
            "Data Source=localhost;Initial Catalog=TinTest;User ID=sa;Password=H[k7-4Zq;Encrypt=False";

        builder.UseSqlServer(connectionString);

        return new ProjectContext(builder.Options);
    }
}