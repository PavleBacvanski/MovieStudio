using Microsoft.EntityFrameworkCore;
using MovieStudio.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStudio.Data
{
    public class MovieStudioDBContext : DbContext
    {

        public MovieStudioDBContext(DbContextOptions<MovieStudioDBContext> options)
            :base(options) 
        {

        }
        public DbSet<Theaters> Theaters { get; set; } 
    }
}
