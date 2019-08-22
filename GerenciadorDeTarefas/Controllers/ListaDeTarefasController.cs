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
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Controllers
{
    [Authorize]
    public class ListaDeTarefasController : Controller
    {        
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ListaDeTarefasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _context.ListaDeTarefas.ToListAsync();           
            return View(_mapper.Map<List<ListaDeTarefaViewModel>>(lista));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ListaDeTarefaViewModel listaDeTarefaviewModel)
        {           
            var lista = _mapper.Map<ListaDeTarefa>(listaDeTarefaviewModel);
            await _context.ListaDeTarefas.AddAsync(lista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int Id)
        {            
            var tarefas = _context.ListaDeTarefas.Find(Id);           
            if(tarefas.Tarefas == null)
            {
                tarefas.Tarefas = new List<Tarefa>();               
            }    
            
            return View(_mapper.Map<ListaDeTarefaViewModel>(tarefas));
        }
    }
}