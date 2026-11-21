using Microsoft.AspNetCore.Mvc;
using MVCWebASPCore.Data;
using Microsoft.EntityFrameworkCore;
using MVCWebASPCore.Data.Model;
using Microsoft.IdentityModel.Tokens;

namespace MVCWebASPCore.Controllers
{
    public class ClientController : Controller
    {
        private readonly dbFirstContext _context;

        public ClientController(dbFirstContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var clients = await _context.TbClients.ToListAsync();
            return View(clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbClient client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }


        //Get Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.TbClients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, TbClient client)
        {
            if (id != client.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
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
            return View(client);
        }

        private bool ClientExists(int id)
        {
            throw new NotImplementedException();
        }

        //Get Client/Edit/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.TbClients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        //Post Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.TbClients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            _context.TbClients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
