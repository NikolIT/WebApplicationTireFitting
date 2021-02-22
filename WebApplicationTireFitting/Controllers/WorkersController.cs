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
    public class WorkersController : Controller
    {
        private readonly DB_Kursova_Tire_FittingContext _context;
        IWebHostEnvironment _appEnvironment;

        public WorkersController(DB_Kursova_Tire_FittingContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: Workers
        public async Task<IActionResult> Index()
        {
            var dB_Kursova_Tire_FittingContext = _context.Workers.Include(w => w.IdPositionNavigation);
            return View(await dB_Kursova_Tire_FittingContext.ToListAsync());
        }

        // GET: Workers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers
                .Include(w => w.IdPositionNavigation)
                .FirstOrDefaultAsync(m => m.IdWorker == id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // GET: Workers/Create
        public IActionResult Create()
        {
            ViewData["IdPosition"] = new SelectList(_context.Positions, "IdPosition", "Name");
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdWorker,IdPosition,FullName,PhoneNumber,Address,Rate,DateOfBirth,PathWorkerImg")] Worker worker, IFormFile uploadedFile)
        {
            if (ModelState.IsValid && uploadedFile != null)
            {
                _context.Add(worker);

                //збереження зображення
                // путь к папке Files
                string path = $"/Files/WorkerImg/{worker.IdWorker}_{uploadedFile.FileName}";
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }

                worker.PathWorkerImg = path;
                await _context.SaveChangesAsync();
                //
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPosition"] = new SelectList(_context.Positions, "IdPosition", "Name", worker.IdPosition);
            return View(worker);
        }

        // GET: Workers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }
            ViewData["IdPosition"] = new SelectList(_context.Positions, "IdPosition", "Name", worker.IdPosition);
            return View(worker);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdWorker,IdPosition,FullName,PhoneNumber,Address,Rate,DateOfBirth,PathWorkerImg")] Worker worker, IFormFile uploadedFile)
        {
            if (id != worker.IdWorker)
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

                        string path = $"/Files/WorkerImg/{worker.IdWorker}_{uploadedFile.FileName}";
                        // сохраняем файл в папку Files в каталоге wwwroot
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await uploadedFile.CopyToAsync(fileStream);
                        }

                        FileInfo fileInf = new FileInfo(_appEnvironment.WebRootPath + worker.PathWorkerImg);
                        if (fileInf.Exists)
                        {
                            fileInf.Delete();
                        }

                        worker.PathWorkerImg = path;
                    }
                    //
                    _context.Update(worker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerExists(worker.IdWorker))
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
            ViewData["IdPosition"] = new SelectList(_context.Positions, "IdPosition", "Name", worker.IdPosition);
            return View(worker);
        }

        // GET: Workers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers
                .Include(w => w.IdPositionNavigation)
                .FirstOrDefaultAsync(m => m.IdWorker == id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var worker = await _context.Workers.FindAsync(id);
            //видаляє зображення
            FileInfo fileInf = new FileInfo(_appEnvironment.WebRootPath + worker.PathWorkerImg);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
            //
            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerExists(int id)
        {
            return _context.Workers.Any(e => e.IdWorker == id);
        }
    }
}
