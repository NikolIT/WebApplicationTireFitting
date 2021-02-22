using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationTireFitting.Models;

namespace WebApplicationTireFitting.Controllers
{
    public class CarsController : Controller
    {
        private readonly DB_Kursova_Tire_FittingContext _context;
        IWebHostEnvironment _appEnvironment;

        public CarsController(DB_Kursova_Tire_FittingContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var dB_Kursova_Tire_FittingContext = _context.Cars.Include(c => c.IdClientNavigation).Include(c => c.IdTypeOfCarNavigation);
            return View(await dB_Kursova_Tire_FittingContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.IdClientNavigation)
                .Include(c => c.IdTypeOfCarNavigation)
                .FirstOrDefaultAsync(m => m.IdCar == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "FullName");
            ViewData["IdTypeOfCar"] = new SelectList(_context.TypeOfCars, "IdTypeOfCar", "TypeOfCar1");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCar,Name,Owner,IdClient,IdTypeOfCar,PathCarImg")] Car car, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();

                //збереження зображення
                // путь к папке Files
                string path = $"/Files/CarImg/{car.IdCar}_{uploadedFile.FileName}";
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }

                car.PathCarImg = path;
                await _context.SaveChangesAsync();
                //
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "FullName", car.IdClient);
            ViewData["IdTypeOfCar"] = new SelectList(_context.TypeOfCars, "IdTypeOfCar", "TypeOfCar1", car.IdTypeOfCar);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "FullName", car.IdClient);
            ViewData["IdTypeOfCar"] = new SelectList(_context.TypeOfCars, "IdTypeOfCar", "TypeOfCar1", car.IdTypeOfCar);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCar,Name,Owner,IdClient,IdTypeOfCar,PathCarImg")] Car car, IFormFile uploadedFile)
        {
            if (id != car.IdCar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //
                    //якщо було вибрано файл то він замінює попередній
                    if (uploadedFile != null)
                    {
                        //збереження зображення
                        // путь к папке Files

                        string path = $"/Files/CarImg/{car.IdCar}_{uploadedFile.FileName}";
                        // сохраняем файл в папку Files в каталоге wwwroot
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await uploadedFile.CopyToAsync(fileStream);
                        }

                        FileInfo fileInf = new FileInfo(_appEnvironment.WebRootPath + car.PathCarImg);
                        if (fileInf.Exists)
                        {
                            fileInf.Delete();
                        }

                        car.PathCarImg = path;
                    }
                    //

                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.IdCar))
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
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "FullName", car.IdClient);
            ViewData["IdTypeOfCar"] = new SelectList(_context.TypeOfCars, "IdTypeOfCar", "TypeOfCar1", car.IdTypeOfCar);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.IdClientNavigation)
                .Include(c => c.IdTypeOfCarNavigation)
                .FirstOrDefaultAsync(m => m.IdCar == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            //видаляє зображення
            FileInfo fileInf = new FileInfo(_appEnvironment.WebRootPath + car.PathCarImg);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
            //
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.IdCar == id);
        }
    }
}

//git testttt
