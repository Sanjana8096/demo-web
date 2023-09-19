using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebReports.Interfaces;
using WebReports.Models;
using WebReports.Services;

namespace WebReports.Controllers
{
    [Authorize]
    public class ClientsController : Controller
    {

        #region Private Variables

        /// <summary>
        /// Logger to be used to log messages
        /// </summary>
        private ILogger<ClientsController> _logger;

        /// <summary>
        /// IUserRepository
        /// </summary>
        private IClientService _clientService;

        #endregion

        public ClientsController(ILogger<ClientsController> logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            IList<Client> clientList = _clientService.GetAllClients();
              return clientList.Count != null ? 
                          View(clientList) :
                          Problem("Entity set 'BswebReportsContext.Clients'  is null.");
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var client = _clientService.GetClientById(id.GetValueOrDefault());
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DisplayName,Description,IsActive")] Client client)
        {
            if (ModelState.IsValid)
            {
                _clientService.CreateClient(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _clientService.GetClientById(id.GetValueOrDefault());
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DisplayName,Description,IsActive")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _clientService.EditClient(client);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!ClientExists(client.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _clientService.GetClientById(id.GetValueOrDefault());
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var client = _clientService.GetClientById(id);
            if (client != null)
            {
                _clientService.DeleteClient(id);
            }
            return RedirectToAction(nameof(Index));
        }

        //private bool ClientExists(int id)
        //{
        //  return (_context.Clients?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
