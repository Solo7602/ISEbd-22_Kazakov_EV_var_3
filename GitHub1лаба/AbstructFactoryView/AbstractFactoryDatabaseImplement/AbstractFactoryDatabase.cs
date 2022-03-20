using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace AbstractFactoryDatabaseImplement
{
    public class AbstractFactoryDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=192.168.56.1\SQLEXPRESS;Initial Catalog=AbstractFactoryDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Detail> Detail { set; get; }
        public virtual DbSet<Engine> Engines { set; get; }
        public virtual DbSet<EngineDetail> EngineDetail { set; get; }
        public virtual DbSet<Order> Orders { set; get; }

    }
}
