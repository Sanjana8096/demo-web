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
using WebReports.Helpers;
using System.Net.Mail;
using System.Text;

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

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="clientService"></param>
        public ClientsController(ILogger<ClientsController> logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        #endregion


        #region Default CRUD Calls


        #endregion


        #region Default CRUD Calls


        /// <summary>
        /// // GET: Clients
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            IList<Client> clientList = new List<Client>();
            try
            {
                clientList = _clientService.GetAllClients();
            }
            catch (ValidationException vex)
            {
                TempData["ErrorMessage"] = vex.GetConcatenatedValidationMessages();
            }
            return View(clientList);
        }


        /// <summary>
        /// // GET: Clients/Details/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id.HasValue)
            {
                Client clientInfo = null;
                try
                {
                    clientInfo = _clientService.GetClientById(id.Value);
                }
                catch (ValidationException vex)
                {
                    TempData["ErrorMessage"] = vex.GetConcatenatedValidationMessages();
                }
                return View(clientInfo);
            }
            else
            {
                TempData["ErrorMessage"] = "Not a valid request.";
                return RedirectToAction("Index");
            }
        }


        /// <summary>
        /// // GET: Clients/Create
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }


        /// <summary>
        /// // POST: Clients/Create
        /// To protect from overposting attacks, enable the specific properties you want to bind to.
        /// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,DisplayName,Description,IsAcive")] Client clientInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_clientService.CheckClientExists(clientInfo.Name))
                    {
                        TempData["ErrorMessage"] = "Client name already in use. Please use another name.";
                    }
                    else
                    {
                        // Set logged in user id for created and last updated by properties.
                        clientInfo.CreatedBy = clientInfo.LastUpdatedBy = User.Claims.First(c => c.Type.EndsWith("nameidentifier")).Value;
                        // create a new record in database
                        clientInfo = _clientService.CreateClient(clientInfo);

                        TempData["SuccessMessage"] = "Client has been added successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (ValidationException vex)
                {
                    TempData["ErrorMessage"] = vex.GetConcatenatedValidationMessages();
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid data submitted. Please provide valid information.";
            }
            return View(clientInfo);
        }


        /// <summary>
        /// // GET: Clients/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id.HasValue)
            {
                Client clientInfo = null;
                try
                {
                    clientInfo = _clientService.GetClientById(id.Value);
                }
                catch (ValidationException vex)
                {
                    TempData["ErrorMessage"] = vex.GetConcatenatedValidationMessages();
                }
                return View(clientInfo);
            }
            else
            {
                TempData["ErrorMessage"] = "Not a valid request.";
                return RedirectToAction("Index");
            }
        }


        /// <summary>
        /// // POST: Clients/Edit/5
        /// To protect from overposting attacks, enable the specific properties you want to bind to.
        /// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Client clientInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //clientInfo.UpdatedBy = _GetUserData().Id;
                    clientInfo = _clientService.EditClient(clientInfo);
                    return RedirectToAction("Index");
                }
                catch (ValidationException vex)
                {
                    TempData["ErrorMessage"] = vex.GetConcatenatedValidationMessages();
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid data submitted. Please provide valid information.";
            }
            return View(clientInfo);            
        }


        /// <summary>
        /// // POST: Clients/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            var result = new AjaxResultData();
            try
            {
                if (id.HasValue)
                {
                    _clientService.DeleteClient(id.Value);
                }
                else
                {
                    result.Success = false;
                    result.Message = "Please select a valid record to delete.";
                }
            }
            catch (ValidationException vex)
            {
                result.Success = false;
                result.Message = vex.GetConcatenatedValidationMessages();
            }
            return this.Json(result);
        }

        #endregion

    }
}
