using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMusic.Models
{
    public class MusicDbContext: DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Composer> Composers { get; set; }
        public DbSet<Piece> Pieces { get; set; }

        public MusicDbContext(DbContextOptions<MusicDbContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
