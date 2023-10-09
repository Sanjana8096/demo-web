using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebReports.Models;

namespace WebReports.Controllers
{
    public class ClientUsersController : Controller
    {
        private readonly BSWebReportsDbContext _context;

        public ClientUsersController(BSWebReportsDbContext context)
        {
            _context = context;
        }

        // GET: ClientUsers
        public async Task<IActionResult> Index()
        {
            var bSWebReportsDbContext = _context.ClientUsers.Include(c => c.Client).Include(c => c.CreatedByNavigation).Include(c => c.LastUpdatedByNavigation).Include(c => c.User);
            return View(await bSWebReportsDbContext.ToListAsync());
        }

        // GET: ClientUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClientUsers == null)
            {
                return NotFound();
            }

            var clientUser = await _context.ClientUsers
                .Include(c => c.Client)
                .Include(c => c.CreatedByNavigation)
                .Include(c => c.LastUpdatedByNavigation)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientUser == null)
            {
                return NotFound();
            }

            return View(clientUser);
        }

        // GET: ClientUsers/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id");
            ViewData["CreatedBy"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            ViewData["LastUpdatedBy"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: ClientUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ClientId,CreatedBy,LastUpdatedBy,CreatedOn,LastUpdatedOn,IsAcive,DisabledOn")] ClientUser clientUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", clientUser.ClientId);
            ViewData["CreatedBy"] = new SelectList(_context.AspNetUsers, "Id", "Id", clientUser.CreatedBy);
            ViewData["LastUpdatedBy"] = new SelectList(_context.AspNetUsers, "Id", "Id", clientUser.LastUpdatedBy);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", clientUser.UserId);
            return View(clientUser);
        }

        // GET: ClientUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClientUsers == null)
            {
                return NotFound();
            }

            var clientUser = await _context.ClientUsers.FindAsync(id);
            if (clientUser == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", clientUser.ClientId);
            ViewData["CreatedBy"] = new SelectList(_context.AspNetUsers, "Id", "Id", clientUser.CreatedBy);
            ViewData["LastUpdatedBy"] = new SelectList(_context.AspNetUsers, "Id", "Id", clientUser.LastUpdatedBy);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", clientUser.UserId);
            return View(clientUser);
        }

        // POST: ClientUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ClientId,CreatedBy,LastUpdatedBy,CreatedOn,LastUpdatedOn,IsAcive,DisabledOn")] ClientUser clientUser)
        {
            if (id != clientUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientUserExists(clientUser.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", clientUser.ClientId);
            ViewData["CreatedBy"] = new SelectList(_context.AspNetUsers, "Id", "Id", clientUser.CreatedBy);
            ViewData["LastUpdatedBy"] = new SelectList(_context.AspNetUsers, "Id", "Id", clientUser.LastUpdatedBy);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", clientUser.UserId);
            return View(clientUser);
        }

        // GET: ClientUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClientUsers == null)
            {
                return NotFound();
            }

            var clientUser = await _context.ClientUsers
                .Include(c => c.Client)
                .Include(c => c.CreatedByNavigation)
                .Include(c => c.LastUpdatedByNavigation)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientUser == null)
            {
                return NotFound();
            }

            return View(clientUser);
        }

        // POST: ClientUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClientUsers == null)
            {
                return Problem("Entity set 'BSWebReportsDbContext.ClientUsers'  is null.");
            }
            var clientUser = await _context.ClientUsers.FindAsync(id);
            if (clientUser != null)
            {
                _context.ClientUsers.Remove(clientUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientUserExists(int id)
        {
          return (_context.ClientUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
