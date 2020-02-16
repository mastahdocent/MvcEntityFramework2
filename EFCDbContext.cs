using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rozdzial2_C.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rozdzial2_C
{
    public class EFCDbContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddDebug(); });

        public DbSet<PostModel> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            var cs = @"Data Source=CARBONX-WKO;Initial Catalog=MvcDbC;Integrated Security=True";
            dbContextOptionsBuilder.UseSqlServer(cs).UseLoggerFactory(MyLoggerFactory);
        }
    }
}
