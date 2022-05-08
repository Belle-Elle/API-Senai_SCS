using APISenaiSCS.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISenaiSCS.Context
{
    public class HotspotContext : DbContext
    {
        public HotspotContext(DbContextOptions<HotspotContext> options)
            : base(options)
        {

        }
        
            public virtual DbSet<Campanhas> Campanhas { get; set; }
            public virtual DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NOTE0113A3/SQLEXPRESS initial GerencimentoCampanha; user Id=sa; pwd=Senai@132;");
            }
        } 


    }
}
       


