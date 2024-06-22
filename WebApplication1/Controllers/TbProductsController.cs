using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class TbProductsController : Controller
    {
        private readonly DbClothesShopContext _context;

        public TbProductsController(DbClothesShopContext context)
        {
            _context = context;
        }

        // GET: TbProducts
        public async Task<IActionResult> Index()
        {
            var dbClothesShopContext = _context.TbProducts.Include(t => t.IdCategoryNavigation);
            return View(await dbClothesShopContext.ToListAsync());
        }

        // GET: TbProducts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbProduct = await _context.TbProducts
                .Include(t => t.IdCategoryNavigation)
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (tbProduct == null)
            {
                return NotFound();
            }

            return View(tbProduct);
        }

        // GET: TbProducts/Create
        public IActionResult Create()
        {
            ViewData["IdCategory"] = new SelectList(_context.TbCategories, "IdCategory", "IdCategory");
            return View();
        }

        // POST: TbProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduct,IdCategory,Name,Description,Price,Image,StockQuantity,CreatedAt,UpdatedAt,Type,Size")] TbProduct tbProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategory"] = new SelectList(_context.TbCategories, "IdCategory", "IdCategory", tbProduct.IdCategory);
            return View(tbProduct);
        }

        // GET: TbProducts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbProduct = await _context.TbProducts.FindAsync(id);
            if (tbProduct == null)
            {
                return NotFound();
            }
            ViewData["IdCategory"] = new SelectList(_context.TbCategories, "IdCategory", "IdCategory", tbProduct.IdCategory);
            return View(tbProduct);
        }

        // POST: TbProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdProduct,IdCategory,Name,Description,Price,Image,StockQuantity,CreatedAt,UpdatedAt,Type,Size")] TbProduct tbProduct)
        {
            if (id != tbProduct.IdProduct)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbProductExists(tbProduct.IdProduct))
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
            ViewData["IdCategory"] = new SelectList(_context.TbCategories, "IdCategory", "IdCategory", tbProduct.IdCategory);
            return View(tbProduct);
        }

        // GET: TbProducts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbProduct = await _context.TbProducts
                .Include(t => t.IdCategoryNavigation)
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (tbProduct == null)
            {
                return NotFound();
            }

            return View(tbProduct);
        }

        // POST: TbProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tbProduct = await _context.TbProducts.FindAsync(id);
            if (tbProduct != null)
            {
                _context.TbProducts.Remove(tbProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbProductExists(string id)
        {
            return _context.TbProducts.Any(e => e.IdProduct == id);
        }
    }
}
