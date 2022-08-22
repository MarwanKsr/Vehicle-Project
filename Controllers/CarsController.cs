using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vehicl_Project.Areas.Identity.Data;
using Vehicl_Project.Models;
using Vehicl_Project.ProjectServices;

namespace Vehicl_Project.Controllers
{
    [Authorize(Roles ="Vendor,Customer")]
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(Vehicle_ProjectDbContext context, ICarService carService)
        {
            _carService = carService;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            return View(await _carService.Index());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if ( _carService.IsTableExists == null || await _carService.IsExists(id) == false)
            {
                return NotFound();
            }

            var car = await _carService.DetailsById(id);
            return View(car);            
        }

        // GET: Cars/Create
        [Authorize(Roles = "Vendor")]
        public  async Task<IActionResult> Create()
        {
            ViewBag.ColorsList = new SelectList(await _carService.GetColors(), "Id", "Name");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> Create([Bind("Id,Name,Brand,Wheels,Headlights,ColorId")] Car car)
        {
            if (ModelState.IsValid)
            {
                car.ColorName = await _carService.SetColorNameById(car.ColorId);
                await _carService.Create(car);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ColorsList = new SelectList(await _carService.GetColors(), "Id", "Name",car.ColorId);
            return View(car);
        }

        // GET: Cars/Edit/5
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> Edit(int id)
        {
            if ( _carService.IsTableExists == null || await _carService.IsExists(id) == false)
            {
                return NotFound();
            }

            var car = await _carService.GetById(id);

            ViewBag.ColorsList = new SelectList(await _carService.GetColors(), "Id", "Name");
            return View(car);
            
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Brand,Wheels,Headlights,ColorId")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    car.ColorName = await _carService.SetColorNameById(car.ColorId);
                    await _carService.Edit(car);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _carService.IsExists(car.Id) == false)
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
            ViewBag.ColorsList = new SelectList(await _carService.GetColors(), "Id", "Name", car.ColorId);
            return View(car);
        }

        // GET: Cars/Delete/5
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_carService.IsTableExists == null || await _carService.IsExists(id) == false) 
            {
                return NotFound();
            }
            var car = await _carService.GetById(id);
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_carService.IsTableExists == null)
            {
                return Problem("Entity set 'Vehicle_ProjectDbContext.Cars'  is null.");
            }
            var car = await _carService.IsExists(id);
            if (car != false)
            {
               await _carService.Delete(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

    }
}
