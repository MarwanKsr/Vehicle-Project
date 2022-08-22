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
    [Authorize(Roles ="Admin")]
    public class ColorsController : Controller
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        // GET: Colors
        public async Task<IActionResult> Index()
        {
            return View(await _colorService.Index());
        }

       
        // GET: Colors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Color color)
        {
            if (ModelState.IsValid)
            {
                await _colorService.Create(color);
                return RedirectToAction(nameof(Index));
            }
            return View(color);
        }

       
        // GET: Colors/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (_colorService.IsTableExists == null || await _colorService.IsExists(id) == false)
            {
                return NotFound();
            }

            var color = await _colorService.GetById(id);
            return View(color);
        }

        // POST: Colors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_colorService.IsTableExists == null)
            {
                return Problem("Entity set 'Vehicle_ProjectDbContext.Colors'  is null.");
            }
            var color = await _colorService.IsExists(id);
            if (color != null)
            {
                await _colorService.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
