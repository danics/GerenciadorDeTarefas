using AutoMapper;
using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Mapping
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<TarefaViewModel, Tarefa>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Descricao, opt => opt.MapFrom(x => x.Descricao))
                .ForMember(x => x.ListaDeTarefaId, opt => opt.MapFrom(x => x.ListaDeTarefaId))
                .ForMember(x => x.Status, opt => opt.MapFrom(x => x.Status));

            CreateMap<Tarefa, TarefaViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Descricao, opt => opt.MapFrom(x => x.Descricao))
                .ForMember(x => x.ListaDeTarefaId, opt => opt.MapFrom(x => x.ListaDeTarefaId))
                .ForMember(x => x.Status, opt => opt.MapFrom(x => x.Status));
        }
    }
}
