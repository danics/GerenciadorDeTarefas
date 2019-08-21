using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Models.ViewModels
{
    public class ListaDeTarefaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Tarefa> Tarefas { get; set; }
    }
}
