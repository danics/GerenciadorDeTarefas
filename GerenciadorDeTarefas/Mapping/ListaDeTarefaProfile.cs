using AutoMapper;
using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Mapping
{
    public class ListaDeTarefaProfile : Profile
    {
        public ListaDeTarefaProfile()
        {
            CreateMap<ListaDeTarefaViewModel, ListaDeTarefa>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(x => x.Tarefas, opt => opt.MapFrom(x => x.Tarefas));

            CreateMap<ListaDeTarefa, ListaDeTarefaViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(x => x.Tarefas, opt => opt.MapFrom(x => x.Tarefas));                        

        }
    }
}
