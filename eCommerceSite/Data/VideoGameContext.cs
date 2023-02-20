using eCommerceSite.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceSite.Data
{
    public class VideoGameContext : DbContext
    {
        public VideoGameContext(DbContextOptions<VideoGameContext> options) : base(options)
        {    
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<eCommerceSite.Models.RegisterViewModel> RegisterViewModel { get; set; }

        public DbSet<eCommerceSite.Models.LoginViewModel> LoginViewModel { get; set; }
    }
}
