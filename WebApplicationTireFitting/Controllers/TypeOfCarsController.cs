using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationTireFitting.Models;

namespace WebApplicationTireFitting.Controllers
{
    public class TypeOfCarsController : Controller
    {
        private readonly DB_Kursova_Tire_FittingContext _context;

        public TypeOfCarsController(DB_Kursova_Tire_FittingContext context)
        {
            _context = context;
        }

        // GET: TypeOfCars
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeOfCars.ToListAsync());
        }

        // GET: TypeOfCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfCar = await _context.TypeOfCars
                .FirstOrDefaultAsync(m => m.IdTypeOfCar == id);
            if (typeOfCar == null)
            {
                return NotFound();
            }

            return View(typeOfCar);
        }

        // GET: TypeOfCars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeOfCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTypeOfCar,TypeOfCar1")] TypeOfCar typeOfCar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeOfCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeOfCar);
        }

        // GET: TypeOfCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfCar = await _context.TypeOfCars.FindAsync(id);
            if (typeOfCar == null)
            {
                return NotFound();
            }
            return View(typeOfCar);
        }

        // POST: TypeOfCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTypeOfCar,TypeOfCar1")] TypeOfCar typeOfCar)
        {
            if (id != typeOfCar.IdTypeOfCar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeOfCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeOfCarExists(typeOfCar.IdTypeOfCar))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(typeOfCar);
        }

        // GET: TypeOfCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeOfCar = await _context.TypeOfCars
                .FirstOrDefaultAsync(m => m.IdTypeOfCar == id);
            if (typeOfCar == null)
            {
                return NotFound();
            }

            return View(typeOfCar);
        }

        // POST: TypeOfCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeOfCar = await _context.TypeOfCars.FindAsync(id);
            _context.TypeOfCars.Remove(typeOfCar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeOfCarExists(int id)
        {
            return _context.TypeOfCars.Any(e => e.IdTypeOfCar == id);
        }
    }
}
