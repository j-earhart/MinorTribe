using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinorTribe.Models;

namespace MinorTribe.Controllers
{

    public class BiosController : Controller
    {
        private readonly MinorTribeContext _context;

        public BiosController(MinorTribeContext context)
        {
            _context = context;
        }

        // GET: Bios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bios.ToListAsync());
        }

        // GET: Bios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bio = await _context.Bios
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bio == null)
            {
                return NotFound();
            }

            return View(bio);
        }

        // GET: Bios/Create
        public IActionResult Create()
        {
            return View();
        }

       

        [HttpPost]
        public async Task<IActionResult> Create(BiosViewModel model)
        {

            var file = model.file; // Extracting the property file of IFormFile type

            //Upload the file using our new function/method
            string fileName = UploadFile(model.file);

            /*
              We just finished writing the file and getting the BIO form values.
              Let's go ahead and populate the imageUpload Property and give it the name of the file.
             */
                model.bio.ImageUpload = fileName;   

                // Finally:  Write out data to our table.
                _context.Bios.Add(model.bio);
            _context.SaveChanges();

            return RedirectToAction("Index");


        }

        // GET: Bios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bio = await _context.Bios.SingleOrDefaultAsync(m => m.Id == id);
            if (bio == null)
            {
                return NotFound();
            }

            //Change the model that the view is expecting
            BiosViewModel model = new BiosViewModel();
            model.bio = bio;

            return View(model);
        }

        // POST: Bios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BiosViewModel model)
        {
            if (id != model.bio.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    /*
                     * Upload the file using our new function/method
                    */
                    string fileName = UploadFile(model.file); //Upload the file
                    model.bio.ImageUpload = fileName; //Upload the name of the file
                    _context.Update(model.bio);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BioExists(model.bio.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
            return View(model.bio);
        }

        // GET: Bios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bio = await _context.Bios
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bio == null)
            {
                return NotFound();
            }

            return View(bio);
        }

        // POST: Bios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bio = await _context.Bios.SingleOrDefaultAsync(m => m.Id == id);
            _context.Bios.Remove(bio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BioExists(int id)
        {
            return _context.Bios.Any(e => e.Id == id);
        }

        // Custom methods go below
        private string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return "file not selected";

            var fileName = string.Format("{0}{1}{2}{3}-" + file.FileName,
                            DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Second);

            // Define the path that will be used to save the file to:
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads", fileName);

            // Opening a memory block to store the file
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }

            return fileName;
        }





    }
}
