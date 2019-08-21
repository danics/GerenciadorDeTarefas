using GerenciadorDeTarefas.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Models.ViewModels
{
    public class TarefaViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Status Status { get; set; }
        public int ListaDeTarefaId { get; set; }      
    }
}
