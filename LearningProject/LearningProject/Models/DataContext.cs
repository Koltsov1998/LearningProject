using Microsoft.EntityFrameworkCore;

namespace LearningProject.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ParsedMeme> ParsedMemes { set; get; }

        public DbSet<VkPublic> VkPublics { set; get; }
    }
}
