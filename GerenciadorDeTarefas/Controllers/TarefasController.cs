using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GerenciadorDeTarefas.Data;
using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.Controllers
{
    [Authorize]
    public class TarefasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TarefasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Tarefa(int Id)
        {
            ViewData["listas"] = _context.ListaDeTarefas.ToList();            
            return View(new TarefaViewModel { ListaDeTarefaId = Id });
        }

        [HttpPost]
        public async Task<IActionResult> Tarefa(TarefaViewModel tarefaViewModel)
        {
            ViewData["listas"] = _context.ListaDeTarefas.ToList();
            _context.Tarefas.Add(_mapper.Map<Tarefa>(tarefaViewModel));
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", "ListaDeTarefas");
        }
    }
}