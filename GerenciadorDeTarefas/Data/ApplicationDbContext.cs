using System;
using System.Collections.Generic;
using System.Text;
using GerenciadorDeTarefas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ListaDeTarefa> ListaDeTarefas { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
