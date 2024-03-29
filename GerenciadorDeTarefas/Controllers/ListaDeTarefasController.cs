﻿using System;
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
            var lista = await _context.ListaDeTarefas.AsNoTracking().ToListAsync();           
            return View(_mapper.Map<List<ListaDeTarefaViewModel>>(lista));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["listas"] = _context.ListaDeTarefas.AsNoTracking().ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ListaDeTarefaViewModel listaDeTarefaviewModel)
        {
            ViewData["listas"] = _context.ListaDeTarefas.AsNoTracking().ToList();
            var lista = _mapper.Map<ListaDeTarefa>(listaDeTarefaviewModel);
            await _context.ListaDeTarefas.AddAsync(lista);
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", new { id = lista.Id });
        }

        public IActionResult Edit(int Id)
        {
            ViewData["listas"] = _context.ListaDeTarefas.AsNoTracking().ToList();
            var tarefas = _context.ListaDeTarefas.Include(x => x.Tarefas).AsNoTracking().Where(x => x.Id == Id).FirstOrDefault();           
            if(tarefas.Tarefas == null)
            {
                tarefas.Tarefas = new List<Tarefa>();               
            }             
            return View(_mapper.Map<ListaDeTarefaViewModel>(tarefas));
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            ViewData["listas"] = _context.ListaDeTarefas.AsNoTracking().ToList();
            var listadetarefa = _context.ListaDeTarefas.Find(Id);
            return View(_mapper.Map<ListaDeTarefaViewModel>(listadetarefa));
        }

        [HttpPost]
        public IActionResult Delete(ListaDeTarefaViewModel listaDeTarefaViewModel)
        {
            ViewData["listas"] = _context.ListaDeTarefas.AsNoTracking().ToList();
            _context.ListaDeTarefas.Remove(_mapper.Map<ListaDeTarefa>(listaDeTarefaViewModel));
            _context.SaveChanges();
            return RedirectToAction("Edit", new { id = 1 });
        }
    }
}