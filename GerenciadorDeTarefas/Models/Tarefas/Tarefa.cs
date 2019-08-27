using GerenciadorDeTarefas.Models.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Models
{
    public class Tarefa
    {        
        public int Id { get; private set; }
        public string Descricao { get; set; }
        public Status Status { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ListaDeTarefaId { get; private set; }
        [ForeignKey("ListaDeTarefaId")]
        public ListaDeTarefa ListaDeTarefa { get; private set; }
    }
}
