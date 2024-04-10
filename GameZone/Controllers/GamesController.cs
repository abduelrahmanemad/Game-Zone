﻿using Microsoft.AspNetCore.Mvc;
using GameZone.ViewModels;
using GameZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _context.Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).OrderBy(c => c.Text).ToList();

            var devices = _context.Devices.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).OrderBy(d => d.Text).ToList();
            CreateGameFormView model = new()
            {
                Categories = categories,
                Devices = devices,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateGameFormView model)
        {
            return View();
        }
    }
}
