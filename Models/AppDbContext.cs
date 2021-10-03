using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatCafe.Models
{
    public class AppDbContext : DbContext //faz um rastreamento da app com o banco
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //todo Gato que mudra vai refletir no banco
        public DbSet<CadastroGato> Gatos { get; set; }

        public DbSet<EmprestimoGato> Emprestimos { get; set; }
    }
}
