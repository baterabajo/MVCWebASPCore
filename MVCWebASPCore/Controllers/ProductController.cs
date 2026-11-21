using Microsoft.AspNetCore.Mvc;
using MVCWebASPCore.Data;
using Microsoft.EntityFrameworkCore;
using MVCWebASPCore.Data.Model;
using Microsoft.IdentityModel.Tokens;

namespace MVCWebASPCore.Controllers
{
    public class ProductController : Controller
    {
        private readonly dbFirstContext _context;

        public ProductController(dbFirstContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Products = await _context.TbProducts.ToListAsync();
            return View(Products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbProduct Product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Product);
        }


        //Get Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Product = await _context.TbProducts.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, TbProduct Product)
        {
            if (id != Product.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(Product.Id))
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
            return View(Product);
        }

        private bool ProductExists(int id)
        {
            throw new NotImplementedException();
        }

        //Get Product/Edit/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Product = await _context.TbProducts.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }

        //Post Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Product = await _context.TbProducts.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            _context.TbProducts.Remove(Product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
