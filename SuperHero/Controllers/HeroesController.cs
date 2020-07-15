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
    public class HeroesController : Controller
    {
        // database here

        private ApplicationDbContext _context;
        public HeroesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Heroes
        public ActionResult Index()
        {
            var heroes = _context.Heroes.ToList();
            return View(heroes);
        }

        // GET: Heroes/Details/5
        public ActionResult Details(int id)
        {
            var hero = _context.Heroes.Where(i => i.Id == id).FirstOrDefault();
            return View(hero);
        }

        // GET: Heroes/Create
        public ActionResult Create()
        {
            Hero hero = new Hero();
            return View(hero);
        }

        // POST: Heroes/Create
        [HttpPost]
        public ActionResult Create(Hero hero)
        {
            try
            {
                _context.Heroes.Add(hero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Heroes/Edit/5
        public ActionResult Edit(int id)
        {
            var hero = _context.Heroes.Where(i => i.Id == id).FirstOrDefault();
            return View(hero);
        }

        // POST: Heroes/Edit/5
        [HttpPost]
       public ActionResult Edit(Hero hero)
        {
            //var hero = _context.Heroes.Where(i => i.Id == id).FirstOrDefault();
            try
            {
                _context.Heroes.Update(hero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(hero);
            }
        }

        // GET: Heroes/Delete/5
        public ActionResult Delete(int id)
        {
            var heroes = _context.Heroes.Where(i => i.Id == id).FirstOrDefault();
            return View(heroes);
        }

        // POST: Heroes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var hero = _context.Heroes.Where(i => i.Id == id).FirstOrDefault();
            try
            {
                _context.Heroes.Remove(hero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(hero);
            }
        }
    }
}
