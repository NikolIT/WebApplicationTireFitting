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
    public class OrdersController : Controller
    {
        private readonly DB_Kursova_Tire_FittingContext _context;

        public OrdersController(DB_Kursova_Tire_FittingContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var dB_Kursova_Tire_FittingContext = _context.Orders.Include(o => o.IdCarNavigation).Include(o => o.IdClientNavigation);
            return View(await dB_Kursova_Tire_FittingContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.IdCarNavigation)
                .Include(o => o.IdClientNavigation)
                .FirstOrDefaultAsync(m => m.IdOrder == id);
            //
                // передача на сторінку масива з Services
            ViewData["Materials"] = await _context.Orders
                .Where(p => p.IdOrder == id)
                .Include(v => v.MaterialsOrders)
                .ThenInclude(p => p.IdMaterialsNavigation)
                .ToListAsync();

            ViewData["Workers"] = await _context.Orders
                .Where(p => p.IdOrder == id)
                .Include(v => v.OrderWorkers)
                .ThenInclude(p => p.IdWorkerNavigation)
                .ToListAsync();

            ViewData["Services"] = await _context.Orders
                .Where(p => p.IdOrder == id)
                .Include(v => v.ServiceOrders)
                .ThenInclude(p => p.IdServiceNavigation)
                .ToListAsync();
            //
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            //
            ViewData["Materials"] = _context.Materials.ToList();
            ViewData["Workers"] = _context.Workers.ToList();
            ViewData["Services"] = _context.Services.ToList();
            //
            ViewData["IdCar"] = new SelectList(_context.Cars, "IdCar", "Name");
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "FullName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrder,Date,IdClient,IdCar,Price")] Order order, int[] idMaterials, int[] idWorkers, int[] idServices)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                //
                foreach (var n in idMaterials)
                {
                    order.MaterialsOrders.Add(new MaterialsOrder
                    {
                        IdOrderNavigation = order,
                        IdMaterialsNavigation = _context.Materials.FirstOrDefault(p => p.IdMaterials == n)
                    });
                }

                foreach (var n in idWorkers)
                {
                    order.OrderWorkers.Add(new OrderWorker
                    {
                        IdOrderNavigation = order,
                        IdWorkerNavigation = _context.Workers.FirstOrDefault(p => p.IdWorker == n)
                    });
                }

                foreach (var n in idServices)
                {
                    order.ServiceOrders.Add(new ServiceOrder
                    {
                        IdOrderNavigation = order,
                        IdServiceNavigation = _context.Services.FirstOrDefault(p => p.IdService == n)
                    });
                }
                //
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //
            //
            ViewData["Materials"] = _context.Materials.ToList();
            ViewData["Workers"] = _context.Workers.ToList();
            ViewData["Services"] = _context.Services.ToList();
            //
            //
            ViewData["IdCar"] = new SelectList(_context.Cars, "IdCar", "Name", order.IdCar);
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "FullName", order.IdClient);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);

            //
            // передача на сторінку масива з Services
            //
            ViewData["MaterialsFull"] = _context.Materials.ToList();
            ViewData["WorkersFull"] = _context.Workers.ToList();
            ViewData["ServicesFull"] = _context.Services.ToList();
            //
            ViewData["Materials"] = await _context.Orders
                .Where(p => p.IdOrder == id)
                .Include(v => v.MaterialsOrders)
                .ThenInclude(p => p.IdMaterialsNavigation)
                .ToListAsync();

            ViewData["Workers"] = await _context.Orders
                .Where(p => p.IdOrder == id)
                .Include(v => v.OrderWorkers)
                .ThenInclude(p => p.IdWorkerNavigation)
                .ToListAsync();

            ViewData["Services"] = await _context.Orders
                .Where(p => p.IdOrder == id)
                .Include(v => v.ServiceOrders)
                .ThenInclude(p => p.IdServiceNavigation)
                .ToListAsync();
            //

            if (order == null)
            {
                return NotFound();
            }
            ViewData["IdCar"] = new SelectList(_context.Cars, "IdCar", "Name", order.IdCar);
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "FullName", order.IdClient);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrder,Date,IdClient,IdCar,Price")] Order order, int[] idMaterials, int[] idWorkers, int[] idServices)
        {
            if (id != order.IdOrder)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {


                    _context.Update(order);
                    //
                    var OrderWorkers = _context.OrderWorkers
                        .Where(p => p.IdOrder == id)
                        .ToListAsync();
                    foreach (var item in await OrderWorkers)
                    {
                        _context.OrderWorkers.RemoveRange(item);
                    }

                    var MaterialsOrders = _context.MaterialsOrders
                        .Where(p => p.IdOrder == id)
                        .ToListAsync();
                    foreach (var item in await MaterialsOrders)
                    {
                        _context.MaterialsOrders.RemoveRange(item);
                    }

                    var ServiceOrders = _context.ServiceOrders
                        .Where(p => p.IdOrder == id)
                        .ToListAsync();
                    foreach (var item in await ServiceOrders)
                    {
                        _context.ServiceOrders.RemoveRange(item);
                    }

                    //
                    foreach (var n in idMaterials)
                    {
                        order.MaterialsOrders.Add(new MaterialsOrder
                        {
                            IdOrderNavigation = order,
                            IdMaterialsNavigation = _context.Materials.FirstOrDefault(p => p.IdMaterials == n)
                        });
                    }

                    foreach (var n in idWorkers)
                    {
                        order.OrderWorkers.Add(new OrderWorker
                        {
                            IdOrderNavigation = order,
                            IdWorkerNavigation = _context.Workers.FirstOrDefault(p => p.IdWorker == n)
                        });
                    }

                    foreach (var n in idServices)
                    {
                        order.ServiceOrders.Add(new ServiceOrder
                        {
                            IdOrderNavigation = order,
                            IdServiceNavigation = _context.Services.FirstOrDefault(p => p.IdService == n)
                        });
                    }
                    //

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.IdOrder))
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
            ViewData["IdCar"] = new SelectList(_context.Cars, "IdCar", "Name", order.IdCar);
            ViewData["IdClient"] = new SelectList(_context.Clients, "IdClient", "FullName", order.IdClient);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.IdCarNavigation)
                .Include(o => o.IdClientNavigation)
                .FirstOrDefaultAsync(m => m.IdOrder == id);
            //
            // передача на сторінку масива з Services
            ViewData["Materials"] = await _context.Orders
                .Where(p => p.IdOrder == id)
                .Include(v => v.MaterialsOrders)
                .ThenInclude(p => p.IdMaterialsNavigation)
                .ToListAsync();

            ViewData["Workers"] = await _context.Orders
                .Where(p => p.IdOrder == id)
                .Include(v => v.OrderWorkers)
                .ThenInclude(p => p.IdWorkerNavigation)
                .ToListAsync();

            ViewData["Services"] = await _context.Orders
                .Where(p => p.IdOrder == id)
                .Include(v => v.ServiceOrders)
                .ThenInclude(p => p.IdServiceNavigation)
                .ToListAsync();
            //
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.IdOrder == id);
        }
    }
}
