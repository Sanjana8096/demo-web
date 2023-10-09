using WebReports.Interfaces;
using WebReports.Models;
using WebReports.Helpers;
using Microsoft.Extensions.Logging;

namespace WebReports.Services
{
    public class ClientMenuService : IClientMenuService
    {

        #region Private Variables

        /// <summary>
        /// Logger to be used to log messages
        /// </summary>
        private ILogger<ClientMenuService> _logger;

        /// <summary>
        /// Private variable used for IClientMenuRepository
        /// </summary>
        private IClientMenuRepository _clientMenuRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="clientMenuRepository"></param>
        public ClientMenuService(ILogger<ClientMenuService> logger, IClientMenuRepository clientMenuRepository)
        {
            _logger = logger;
            _clientMenuRepository = clientMenuRepository;
        }

        #endregion

        #region Default CRUD Calls

        /// <summary>
        /// Creates a client menu in the database
        /// </summary>
        /// <param name="clientMenuInfo"></param>
        /// <returns>ClientMenu data</returns>
        public ClientMenu CreateClientMenu(ClientMenu clientMenuInfo)
        {
            try
            {
                return _clientMenuRepository.CreateClientMenu(clientMenuInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new ValidationException("Error occured while adding client menu.");
            }
        }

        /// <summary>
        /// Edits client menu in the database
        /// </summary>
        /// <param name="clientMenuInfo"></param>
        /// <returns>ClientsData</returns>
        public ClientMenu EditClientMenu(ClientMenu clientMenuInfo)
        {
            try
            {
                return _clientMenuRepository.EditClientMenu(clientMenuInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new ValidationException("Error occured while editing client menu.");
            }
        }

        /// <summary>
        /// Deletes client menu from the database
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteClientMenu(int id)
        {
            try
            {
                return _clientMenuRepository.DeleteClientMenu(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new ValidationException("Error occured while deleting client menu.");
            }
        }

        /// <summary>
        /// Fetches client menu from the database based on id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClientsData</returns>
        public ClientMenu GetClientMenuById(int id)
        {
            try
            {
                return _clientMenuRepository.GetClientMenuById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new ValidationException("Error occured while fetching client menu by id.");
            }
        }

        /// <summary>
        /// Fetches the list of all client menus from the database.
        /// </summary>
        /// <returns>list of ClientMenu</returns>
        public IList<ClientMenu> GetAllClientMenus()
        {
            try
            {
                return _clientMenuRepository.GetAllClientMenus();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new ValidationException("Error occured while fetching all client menu list.");
            }
        }

        #endregion

        #region Other Calls


        /// <summary>
        ///  Fetches the list of client menus from the database based on client id.
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public IList<ClientMenu> GetClientMenusByClientId(int clientId)
        {
            try
            {
                return _clientMenuRepository.GetClientMenusByClientId(clientId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new ValidationException("Error occured while fetching client menu list by client id.");
            }
        }

        /// <summary>
        /// Checks whether the client menu exists. Workspace id, report id is unique for client.
        /// </summary>
        /// <param name="workspaceId"></param>
        /// <param name="reportId"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public bool CheckClientMenuExists(string workspaceId, string reportId, int clientId)
        {
            try
            {
                return _clientMenuRepository.CheckClientMenuExists(workspaceId, reportId, clientId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new ValidationException("Error occured while checking if client menu exists by workspace and report id.");
            }
        }

        #endregion

    }
}
