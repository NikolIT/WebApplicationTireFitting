using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTireFitting.Models;

namespace WebApplicationTireFitting.Controllers
{
    public class ReportOrder
    {
        public DateTime date;
        public decimal price;
        public string fullName;
        public string nameAuto;
        public string pathCarImg;

    }

    public class ReportClient
    {
        public Client cli;
        public int carsCount;
        public int orderCount;

    }

    public class ReportWorker
    {
        public Worker wor;
        public int orderCount;
    }

    public class ReportCar
    {
        public string pathCarImg;
        public string name;
        public string fullName;
        public int orderCount;
    }
    public class ReportService
    {
        public Service ser;
        public int orderCount;
    }


    public class ReportController : Controller
    {
        private readonly DB_Kursova_Tire_FittingContext _context;

        public ReportController(DB_Kursova_Tire_FittingContext context)
        {
            _context = context;
        }

        

        //головна сторінка
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ReportOrder()
        {
            ViewBag.Date = $"{DateTime.Now.ToString("d")}";
            var reportOrder = (from ord in _context.Orders
                               join Cli in _context.Clients on ord.IdClient equals Cli.IdClient into client
                               from cli in client.DefaultIfEmpty()
                               join Car in _context.Cars on ord.IdCar equals Car.IdCar into cars
                               from car in cars.DefaultIfEmpty()
                               select new ReportOrder
                               {
                                   date = ord.Date,
                                   price = ord.Price,
                                   fullName = cli.FullName,
                                   nameAuto = car.Name,
                                   pathCarImg = car.PathCarImg
                               }
                              ); ;
            return View(reportOrder);
        }

        public IActionResult RepotrClient()
        {
            ViewBag.Date = $"{DateTime.Now.ToString("d")}";
            var countClientCars = (from cli in _context.Clients
                                   join Car in _context.Cars on cli.IdClient equals Car.IdClient
                                   group cli by cli.IdClient into client
                                   select new
                                   {
                                       cli = client.Key,
                                       carsCount = client.Count()
                                   }
                                   );

            var countClientOrder = (from cli in _context.Clients
                                    join Ord in _context.Orders on cli.IdClient equals Ord.IdClient
                                    group cli by cli.IdClient into client
                                    select new
                                    {
                                        cli = client.Key,
                                        orderCount = client.Count()
                                    }
                                   );

            var repotrClient = (from cli in _context.Clients
                                join CliCar in countClientCars on cli.IdClient equals CliCar.cli into countclientcars
                                from cliCar in countclientcars.DefaultIfEmpty()
                                join CliOrd in countClientOrder on cli.IdClient equals CliOrd.cli into countclientorder
                                from cliOrd in countclientorder.DefaultIfEmpty()
                                select new ReportClient
                                {
                                    cli = cli,
                                    carsCount = cliCar.carsCount,
                                    orderCount = cliOrd.orderCount
                                }
                               );//.OrderByDescending(g => g.orderCount);

            return View(repotrClient);
        }

        public IActionResult RepotrWorker()
        {
            ViewBag.Date = $"{DateTime.Now.ToString("d")}";
            var countWorkerOrder = (from wor in _context.Workers
                                    join OrdWor in _context.OrderWorkers on wor.IdWorker equals OrdWor.IdWorker
                                    join Ord in _context.Orders on OrdWor.IdOrder equals Ord.IdOrder
                                    group wor by wor.IdWorker into worker
                                    select new
                                    {
                                        wor = worker.Key,
                                        orderCount = worker.Count()
                                    }
                                  );

            var repotrWorker = (from wor in _context.Workers
                                join OrdWor in countWorkerOrder on wor.IdWorker equals OrdWor.wor into countworkerorder
                                from ordWor in countworkerorder.DefaultIfEmpty()
                                select new ReportWorker
                                {
                                    wor = wor,
                                    orderCount = ordWor.orderCount
                                }
                               ).OrderByDescending(g => g.orderCount);

            return View(repotrWorker);
        }

        public IActionResult ReportCar()
        {
            ViewBag.Date = $"{DateTime.Now.ToString("d")}";
            var countCarOrder = (from car in _context.Cars
                                 join Ord in _context.Orders on car.IdCar equals Ord.IdCar into order
                                 from ord in order.DefaultIfEmpty()
                                 group car by car.IdCar into cars
                                 select new
                                 {
                                     car = cars.Key,
                                     coutnOrd = cars.Count()
                                 }
                                 );
            var reportCar = (from car in _context.Cars
                             join CarOrd in countCarOrder on car.IdCar equals CarOrd.car into carsorder
                             from carorder in carsorder.DefaultIfEmpty()
                             join Cli in _context.Clients on car.IdClient equals Cli.IdClient into client
                             from cli in client.DefaultIfEmpty()
                             select new ReportCar
                             {
                                 pathCarImg = car.PathCarImg,
                                 name = car.Name,
                                 fullName = cli.FullName,
                                 orderCount = carorder.coutnOrd
                             }
                             ).OrderByDescending(g => g.orderCount);
            return View(reportCar);
        }

        public IActionResult ReportService()
        {
            ViewBag.Date = $"{DateTime.Now.ToString("d")}";

            var countServiceOrder = (from ser in _context.Services
                                     join OrdSer in _context.ServiceOrders on ser.IdService equals OrdSer.IdService into serviceorders
                                     from ordSer in serviceorders.DefaultIfEmpty()
                                     join Ord in _context.Orders on ordSer.IdOrder equals Ord.IdOrder into orders
                                     from ord in orders.DefaultIfEmpty()
                                     group ser by ser.IdService into service
                                     select new
                                     {
                                         ser = service.Key,
                                         coutnOrd = service.Count()
                                     }
                                 );

            var reportService = (from ser in _context.Services
                                 join SerOrd in countServiceOrder on ser.IdService equals SerOrd.ser into countserviceorder
                                 from serOrd in countserviceorder.DefaultIfEmpty()
                                 select new ReportService
                                 {
                                     ser = ser,
                                     orderCount = serOrd.coutnOrd
                                 }
                             ).OrderByDescending(g => g.orderCount);

            return View(reportService);
        }

        /*public IActionResult Report()
        {
            //загальний запрос на інформацію про замовлення
            //-------------------------------------------------------------------------------------------------

            var reportOrder = (from ord in _context.Orders
                               join Cli in _context.Clients on ord.IdClient equals Cli.IdClient into client
                               from cli in client.DefaultIfEmpty()
                               join Car in _context.Cars on ord.IdCar equals Car.IdCar into cars
                               from car in cars.DefaultIfEmpty()
                               select new ReportOther
                               {
                                   ord = ord,
                                   car = car,
                                   cli = cli
                               }
                               );
            //-------------------------------------------------------------------------------------------------

            //загальне по клієнтам
            //-------------------------------------------------------------------------------------------------

            var countClientCars = (from cli in _context.Clients
                                   join Car in _context.Cars on cli.IdClient equals Car.IdClient into cars
                                   from car in cars.DefaultIfEmpty()
                                   group cli by cli.IdClient into client
                                   select new
                                   {
                                       cli = client.Key,
                                       carsCount = client.Count()
                                   }
                                   );

            var countClientOrder = (from cli in _context.Clients
                                   join Ord in _context.Orders on cli.IdClient equals Ord.IdClient into orders
                                   from ord in orders.DefaultIfEmpty()
                                   group cli by cli.IdClient into client
                                   select new
                                   {
                                       cli = client.Key,
                                       orderCount = client.Count()
                                   }
                                   );

            var repotrClient = (from cli in _context.Clients
                                join CliCar in countClientCars on cli.IdClient equals CliCar.cli into countclientcars
                                from cliCar in countClientCars.DefaultIfEmpty()
                                join CliOrd in countClientOrder on cli.IdClient equals CliOrd.cli into countclientorder
                                from cliOrd in countclientcars.DefaultIfEmpty()
                                select new RepotrClient
                                {
                                    cli = cli,
                                    carsCount = cliCar.carsCount,
                                    orderCount = cliOrd.carsCount
                                }
                               ).OrderByDescending(g => g.orderCount);

            //-------------------------------------------------------------------------------------------------

            //загальне по працівнику
            //-------------------------------------------------------------------------------------------------

            var countWorkerOrder = (from wor in _context.Workers
                                   join OrdWor in _context.OrderWorkers on wor.IdWorker equals OrdWor.IdWorker into orderworkers
                                   from ordWor in orderworkers.DefaultIfEmpty()
                                   join Ord in _context.Orders on ordWor.IdOrder equals Ord.IdOrder into orders
                                   from ord in orders.DefaultIfEmpty()
                                   group wor by wor.IdWorker into worker
                                   select new
                                   {
                                       wor = worker.Key,
                                       orderCount = worker.Count()
                                   }
                                   );

            var repotrWorker = (from wor in _context.Workers
                                join OrdWor in countWorkerOrder on wor.IdWorker equals OrdWor.wor into countworkerorder
                                from ordWor in countworkerorder.DefaultIfEmpty()
                                select new RepotrWorker
                                {
                                    wor = wor,
                                    orderCount = ordWor.orderCount
                                }
                               ).OrderByDescending(g => g.orderCount);
            //-------------------------------------------------------------------------------------------------

            //загальне по машині
            //-------------------------------------------------------------------------------------------------

            var countCarOrder = (from car in _context.Cars
                                 join Ord in _context.Orders on car.IdCar equals Ord.IdCar into order
                                 group car by car.IdCar into cars
                                 select new
                                 {
                                     car = cars.Key,
                                     coutnOrd = cars.Count()
                                 }
                                 );
            var reportCar = (from car in _context.Cars
                             join CarOrd in countCarOrder on car.IdCar equals CarOrd.car into carsorder
                             from carorder in carsorder.DefaultIfEmpty()
                             select new ReportCar
                             {
                                 car = car,
                                 orderCount = carorder.coutnOrd
                             }
                             ).OrderByDescending(g => g.orderCount);


            //-------------------------------------------------------------------------------------------------

            //популярні послуги
            //-------------------------------------------------------------------------------------------------
            var countServiceOrder = (from ser in _context.Services
                                 join OrdSer in _context.ServiceOrders on ser.IdService equals OrdSer.IdService into serviceorders
                                 from ordSer in serviceorders.DefaultIfEmpty()
                                 join Ord in _context.Orders on ordSer.IdOrder equals Ord.IdOrder into orders
                                 from ord in orders.DefaultIfEmpty()
                                 group ser by ser.IdService into service
                                 select new
                                 {
                                     ser = service.Key,
                                     coutnOrd = service.Count()
                                 }
                                 );

            var reportService =(from ser in _context.Services
                             join SerOrd in countServiceOrder on ser.IdService equals SerOrd.ser into countserviceorder
                                from serOrd in countserviceorder.DefaultIfEmpty()
                             select new ReportService
                             {
                                 ser = ser,
                                 orderCount = serOrd.coutnOrd
                             }
                             ).OrderByDescending(g => g.orderCount);

            //-------------------------------------------------------------------------------------------------

            return View();
        }*/
    }
}
