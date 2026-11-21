using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MVCWebASPCore.Data;
using MVCWebASPCore.Data.Model;
using MVCWebASPCore.DTOs;

namespace MVCWebASPCore.Controllers
{
    public class InvoceController : Controller
    {
        private readonly dbFirstContext _context;

        public InvoceController(dbFirstContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductPrice(int id)
        {
            var product = await _context.TbProducts
                .Where(p => p.Id == id)
                .Select(p => p.Price)
                .FirstOrDefaultAsync();

            return Json(product);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            //    Regla para recordar:
            //-Si utilizas Select() para construir un DTO, normalmente no necesitas Include().
            //- Si quieres cargar las entidades relacionadas completas, utiliza Include() y ThenInclude().
            var invoices = await _context.TbInvoces

                //.Include(i => i.IdClientNavigation)
                //.Include(i => i.TbDetailInvoces)
                //    .ThenInclude(d => d.IdProductNavigation)

                .Select(i => new InvoiceDto
                {
                    Id = i.Id,
                    Date = i.Date,
                    NameClient = i.IdClientNavigation!.Name,
                    Total = i.Total ?? 0m,

                    Products = i.TbDetailInvoces.Select(d => new DetailInvoiceDto
                    {
                        IdProduct = d.IdProduct,
                        NameProduct = d.IdProductNavigation!.Name,
                        Quantity = d.Quantity,
                        Price = d.Price

                    }).ToList()

                }).ToListAsync();

           return View(invoices);

        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Clients = new SelectList(
                _context.TbClients.ToList(),
                "Id",
                "Name"
            );

            ViewBag.Products = new SelectList(
                _context.TbProducts.ToList(),
                "Id",
                "Name"
            );

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceCreateDto dto)
        {
            // Validar cliente
            bool clientExists = await _context.TbClients
                .AnyAsync(c => c.Id == dto.IdClient);

            if (!clientExists)
            {
                ModelState.AddModelError("IdClient", "Cliente no válido.");
            }

            // Validar productos
            if (dto.Products == null || !dto.Products.Any())
            {
                ModelState.AddModelError("", "Debe agregar al menos un producto.");
            }
            else
            {
                var productIds = dto.Products.Select(p => p.IdProduct)
                                              .Distinct()
                                              .ToList();

                int productsExists = await _context.TbProducts
                    .CountAsync(p => productIds.Contains(p.Id));

                if (productsExists != productIds.Count)
                {
                    ModelState.AddModelError("", "Hay productos no válidos.");
                }

                if (dto.Products.Any(p => p.Quantity <= 0 || p.Price < 0))
                {
                    ModelState.AddModelError("", "Cantidad o Price no válido.");
                }
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Clients = new SelectList(
                    _context.TbClients.ToList(), "Id", "Name");

                ViewBag.Products = new SelectList(
                    _context.TbProducts.ToList(), "Id", "Name");

                return View(dto);
            }

            // Crear factura
            var invoice = new TbInvoce
            {
                Date = dto.Date,
                IdClient = dto.IdClient,

                Total = dto.Products.Sum(p => p.Quantity * p.Price),

                TbDetailInvoces = dto.Products.Select(p => new TbDetailInvoce
                {
                    IdProduct = p.IdProduct,
                    Quantity = p.Quantity,
                    Price = p.Price

                }).ToList()
            };

            // Guardar factura y detalles
            _context.TbInvoces.Add(invoice);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var invoice = await _context.TbInvoces
                .Include(i => i.TbDetailInvoces)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (invoice == null)
                return NotFound();

            var dto = new InvoiceCreateDto
            {
                Date = invoice.Date,
                IdClient = invoice.IdClient ?? 0,

                Products = invoice.TbDetailInvoces.Select(d => new DetailInvoiceDto 
                {
                    IdProduct = d.IdProduct,
                    Quantity = d.Quantity,
                    Price = d.Price
                }).ToList()
            };

            ViewBag.Clients = new SelectList(
                _context.TbClients.ToList(), "Id", "Name", dto.IdClient);

            ViewBag.Products = new SelectList(
                _context.TbProducts.ToList(), "Id", "Name");

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InvoiceCreateDto dto)
        {
            var invoice = await _context.TbInvoces
                .Include(i => i.TbDetailInvoces)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (invoice == null)
                return NotFound();

            if (dto.Products == null || !dto.Products.Any())
                ModelState.AddModelError("", "Debe agregar al menos un producto.");

            if (!ModelState.IsValid)
            {
                ViewBag.Clients = new SelectList(
                    _context.TbClients.ToList(), "Id", "Name", dto.IdClient);

                ViewBag.Products = new SelectList(
                    _context.TbProducts.ToList(), "Id", "Name");

                return View(dto);
            }

            // Actualizar factura
            invoice.Date = dto.Date;
            invoice.IdClient = dto.IdClient;

            // Eliminar detalles anteriores
            _context.TbDetailInvoces.RemoveRange(invoice.TbDetailInvoces);

            // Agregar los nuevos detalles
            invoice.TbDetailInvoces = dto.Products.Select(p => new TbDetailInvoce
            {
                IdProduct = p.IdProduct,
                Quantity = p.Quantity,
                Price = p.Price
            }).ToList();

            // Calcular total
            invoice.Total = dto.Products.Sum(p => p.Quantity * p.Price);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var invoice = await _context.TbInvoces
                .Include(i => i.IdClientNavigation)
                .Include(i => i.TbDetailInvoces)
                    .ThenInclude(d => d.IdProductNavigation)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (invoice == null)
                return NotFound();

            return View(invoice);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.TbInvoces
                .Include(i => i.TbDetailInvoces)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (invoice == null)
                return NotFound();

            // Eliminar detalles de la factura
            _context.TbDetailInvoces.RemoveRange(invoice.TbDetailInvoces);

            // Eliminar factura
            _context.TbInvoces.Remove(invoice);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}
