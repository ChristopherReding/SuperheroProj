using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHero.Data;
using SuperHero.Models;

namespace SuperHero.Controllers
{
    public class SuperheroController : Controller
    {
        private ApplicationDbContext _context;
        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public ActionResult Index()
        {
            var superheroes = _context.Superheroes.ToList();
            return View(superheroes);
        }
        
        public ActionResult Details(int id)
        {
            var hero = _context.Superheroes.Where(m => m.Id == id).SingleOrDefault();
            return View(hero);
        }
        

        [HttpGet]
        public ActionResult Create()
        {
            var hero = new Superhero();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Superhero hero)
        {
            _context.Superheroes.Add(hero);
            _context.SaveChanges();
            return RedirectToAction("index");         
        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }
                      
        
    }
}