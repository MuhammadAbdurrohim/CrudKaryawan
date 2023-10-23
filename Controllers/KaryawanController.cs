using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudKARYAWAN.Data;
using CrudKARYAWAN.Models;
using CrudKARYAWAN.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace CrudKARYAWAN.Controllers
{
    public class KaryawanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KaryawanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Karyawan
        [Authorize]
        public async Task<IActionResult> Index()
        {
              return _context.KaryawanModel != null ? 
                          View(await _context.KaryawanModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.KaryawanModel'  is null.");
        }

        // GET: Karyawan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KaryawanModel == null)
            {
                return NotFound();
            }

            var karyawanModel = await _context.KaryawanModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (karyawanModel == null)
            {
                return NotFound();
            }

            return View(karyawanModel);
        }

        // GET: Karyawan/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Karyawan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nama,Alamat")] KaryawanModel karyawanModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(karyawanModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(karyawanModel);
        }

        // GET: Karyawan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KaryawanModel == null)
            {
                return NotFound();
            }

            var karyawanModel = await _context.KaryawanModel.FindAsync(id);
            if (karyawanModel == null)
            {
                return NotFound();
            }
            return View(karyawanModel);
        }

        // POST: Karyawan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nama,Alamat")] KaryawanModel karyawanModel)
        {
            if (id != karyawanModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(karyawanModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KaryawanModelExists(karyawanModel.Id))
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
            return View(karyawanModel);
        }

        // GET: Karyawan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KaryawanModel == null)
            {
                return NotFound();
            }

            var karyawanModel = await _context.KaryawanModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (karyawanModel == null)
            {
                return NotFound();
            }

            return View(karyawanModel);
        }

        // POST: Karyawan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KaryawanModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.KaryawanModel'  is null.");
            }
            var karyawanModel = await _context.KaryawanModel.FindAsync(id);
            if (karyawanModel != null)
            {
                _context.KaryawanModel.Remove(karyawanModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Cari()
        {
            return View();

        }
        public async Task<IActionResult> HasiPencarian(string KataKunci)
        {
            return View("Index", await _context.KaryawanModel.Where(j => j.Nama.Contains(KataKunci)).ToListAsync());
                
        }


            private bool KaryawanModelExists(int id)
        {
          return (_context.KaryawanModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
