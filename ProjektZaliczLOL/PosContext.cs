using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczLOL
{
    public class PosContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //optionBuilder.UseSqlServer(@"server=SZN-SILS0051\SQLEXPRESS;database=Gielda;User Id=sa;Password=sa");
            optionBuilder.UseSqlServer(@"server=DESKTOP-PHJF6CT\SQLEXPRESS;database=Postacie;trusted_connection=true");
        }
        public DbSet<Postacie> Postacie { get; set; }
    }
}
