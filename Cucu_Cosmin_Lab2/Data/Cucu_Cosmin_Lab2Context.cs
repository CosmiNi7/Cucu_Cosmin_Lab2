using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cucu_Cosmin_Lab2.Models;

namespace Cucu_Cosmin_Lab2.Data
{
    public class Cucu_Cosmin_Lab2Context : DbContext
    {
        public Cucu_Cosmin_Lab2Context (DbContextOptions<Cucu_Cosmin_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Cucu_Cosmin_Lab2.Models.Book> Book { get; set; }

        public DbSet<Cucu_Cosmin_Lab2.Models.Publisher> Publisher { get; set; }

        public DbSet<Cucu_Cosmin_Lab2.Models.Author> Author { get; set; }
    }
}
