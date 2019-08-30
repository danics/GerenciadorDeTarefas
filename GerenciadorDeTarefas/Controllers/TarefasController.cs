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
        [Route("/ListaDeTarefas/{listadetarefaId}/Tarefas") ]
        public IActionResult CriaTarefa(int listadetarefaId)
        {
            ViewData["listas"] = _context.ListaDeTarefas.ToList();            
            return View(new TarefaViewModel { ListaDeTarefaId = listadetarefaId });
        }

        [HttpPost]
        [Route("/ListaDeTarefas/{listadetarefaId}/Tarefas")]
        public async Task<IActionResult> CriaTarefa(TarefaViewModel tarefaViewModel)
        {
            ViewData["listas"] = _context.ListaDeTarefas.ToList();
            _context.Tarefas.Add(_mapper.Map<Tarefa>(tarefaViewModel));
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", "ListaDeTarefas", new { id = tarefaViewModel.ListaDeTarefaId });
        }

        [HttpGet]
        public async Task<IActionResult> EditarTarefa(int id)
        {
            ViewData["listas"] = _context.ListaDeTarefas.ToList();
            var tarefa = await _context.Tarefas.FindAsync(id);
            return View(_mapper.Map<TarefaViewModel>(tarefa));
        }
        
        [HttpPost]
        public async Task<IActionResult> EditarTarefa(TarefaViewModel tarefaViewModel)
        {
            ViewData["listas"] = _context.ListaDeTarefas.ToList();
            _context.Tarefas.Update(_mapper.Map<Tarefa>(tarefaViewModel));
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", "ListaDeTarefas", new { id = tarefaViewModel.ListaDeTarefaId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ViewData["listas"] = _context.ListaDeTarefas.ToList();
            var tarefa = await _context.Tarefas.FindAsync(id);
            return View(_mapper.Map<TarefaViewModel>(tarefa));            
        }

        public async Task<IActionResult> Delete(TarefaViewModel tarefaViewModel)
        {
            ViewData["listas"] = _context.ListaDeTarefas.ToList();
            var idlistaDeTarefa = tarefaViewModel.ListaDeTarefaId;
            _context.Tarefas.Remove(_mapper.Map<Tarefa>(tarefaViewModel));
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", "ListaDeTarefas", new { id = idlistaDeTarefa });
        }
    }
}