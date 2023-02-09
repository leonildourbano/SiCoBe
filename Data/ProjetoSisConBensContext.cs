using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoSisConBens.Models;

namespace ProjetoSisConBens.Data
{
    public class ProjetoSisConBensContext : DbContext
    {
        public ProjetoSisConBensContext (DbContextOptions<ProjetoSisConBensContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoSisConBens.Models.Cidade> Cidade { get; set; } = default!;

        public DbSet<ProjetoSisConBens.Models.Cargo> Cargo { get; set; }

        public DbSet<ProjetoSisConBens.Models.Colaborador> Colaborador { get; set; }

        public DbSet<ProjetoSisConBens.Models.Unidade> Unidade { get; set; }

        public DbSet<ProjetoSisConBens.Models.Inventario> Inventario { get; set; }

        public DbSet<ProjetoSisConBens.Models.Bem> Bem { get; set; }
    }
}
