using GerenciadorDeTarefas.Models.Enuns;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorDeTarefas.Models
{
    public class Tarefa
    {        
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Status Status { get; set; }
       
        public int ListaDeTarefaId { get; set; }
        [ForeignKey("ListaDeTarefaId")]
        public ListaDeTarefa ListaDeTarefa { get; set; }
    }
}
