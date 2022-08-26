using System;
using System.Collections.Generic;
using System.Data;
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
    public class BusesController : Controller
    {
        private readonly IBusService _busService;

        public BusesController(IBusService busService)
        {
            _busService = busService;
        }

        // GET: Buses
        public async Task<IActionResult> Index()
        {
            return View(await _busService.Index());
        }

        // GET: Buses/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (_busService.IsTableExists == null || await _busService.IsExists(id) == false)
            {
                return NotFound();
            }

            var bus = await _busService.DetailsById(id);
            return View(bus);
        }

        // GET: Buses/Create
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> Create()
        {
            ViewBag.ColorsList = new SelectList(await _busService.GetColors(), "Id", "Name");
            return View();
        }

        // POST: Buses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> Create([Bind("Id,Name,Brand,ColorId")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                await _busService.Create(bus);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ColorsList = new SelectList(await _busService.GetColors(), "Id", "Name",bus.ColorId);
            return View(bus);
        }

        // GET: Buses/Edit/5
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> Edit(int id)
        {
           if (_busService.IsTableExists == null || await _busService.IsExists(id) == false)
            {
                return NotFound();
            } 

            var bus = await _busService.GetById(id);

            ViewBag.ColorsList = new SelectList(await _busService.GetColors(), "Id", "Name");
            return View(bus);
        }

        // POST: Buses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Brand,ColorId")] Bus bus)
        {
            if (id != bus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _busService.Edit(bus);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _busService.IsExists(bus.Id) == false)
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
            ViewBag.ColorsList = new SelectList(await _busService.GetColors(), "Id", "Name",bus.ColorId);
            return View(bus);
        }

        // GET: Buses/Delete/5
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_busService.IsTableExists == null || await _busService.IsExists(id) == false)
            {
                return NotFound();
            }

            var bus =  await _busService.GetById(id);
            return View(bus);
        }

        // POST: Buses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_busService.IsTableExists == null)
            {
                return Problem("Entity set 'Vehicle_ProjectDbContext.Buses'  is null.");
            }
            var bus = await _busService.IsExists(id);
            if (bus != false)
            {
                await _busService.Delete(id);
            }
            
            return RedirectToAction(nameof(Index));
        }


    }
}
