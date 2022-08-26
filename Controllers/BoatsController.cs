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
    public class BoatsController : Controller
    {
        private readonly IBoatService _boatService;

        public BoatsController(IBoatService boatService)
        {
            _boatService = boatService;
        }

        // GET: Boats
        public async Task<IActionResult> Index()
        {
            return View(await _boatService.Index());
        }

        // GET: Boats/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (_boatService.IsTableExists == null || await _boatService.IsExists(id) == false)
            {
                return NotFound();
            }

            var boat = await _boatService.DetailsById(id);
            return View(boat);
        }

        // GET: Boats/Create
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> Create()
        {
            ViewBag.ColorsList = new SelectList(await _boatService.GetColors(), "Id", "Name");
            return View();
        }

        // POST: Boats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> Create([Bind("Id,Name,Brand,ColorId")] Boat boat)
        {
            if (ModelState.IsValid)
            {
                await _boatService.Create(boat);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ColorsList = new SelectList(await _boatService.GetColors(), "Id", "Name");
            return View(boat);
        }

        // GET: Boats/Edit/5
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> Edit(int id)
        {
            if (_boatService.IsTableExists == null || await _boatService.IsExists(id) == false)
            {
                return NotFound();
            }

            var boat = await _boatService.GetById(id);
            ViewBag.ColorsList = new SelectList(await _boatService.GetColors(), "Id", "Name");
            return View(boat);
        }

        // POST: Boats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Brand,ColorId")] Boat boat)
        {
            if (id != boat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _boatService.Edit(boat);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _boatService.IsExists(boat.Id) == false)
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
            ViewBag.ColorsList = new SelectList(await _boatService.GetColors(), "Id", "Name");
            return View(boat);
        }

        // GET: Boats/Delete/5
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_boatService.IsTableExists == null || await _boatService.IsExists(id) == false)
            {
                return NotFound();
            }

            var boat = await _boatService.GetById(id);
            return View(boat);
        }

        // POST: Boats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_boatService.IsTableExists == null)
            {
                return Problem("Entity set 'Vehicle_ProjectDbContext.Boats'  is null.");
            }
            var boat = await _boatService.IsExists(id);
            if (boat != false)
            {
                await _boatService.Delete(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

    }
}
