using System.Collections.Generic;
using WebReports.Models;
using WebReports.Interfaces;
using WebReports.Helpers;
using Microsoft.Extensions.Logging;

namespace WebReports.Services
{
    public class ClientService : IClientService
    {

        #region Private Variables

        /// <summary>
        /// Logger to be used to log messages
        /// </summary>
        private ILogger<ClientService> _logger;

        /// <summary>
        /// IUserRepository
        /// </summary>
        private IClientRepository _clientRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="clientRepository"></param>
        public ClientService(ILogger<ClientService> logger, IClientRepository clientRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
        }

        #endregion

        #region Default CRUD Calls

        /// <summary>
        /// Creates an client in the database
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <returns>ClientsData</returns>
        public Client CreateClient(Client clientInfo)
        {
            try
            {
                return _clientRepository.CreateClient(clientInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
                //throw new ValidationException("Error occured while adding client.");
            }
        }

        /// <summary>
        /// Edits client in the database
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <returns>ClientsData</returns>
        public Client EditClient(Client clientInfo)
        {
            try
            {
                return _clientRepository.EditClient(clientInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
                //throw new ValidationException("Error occured while editing client.");
            }
        }

        /// <summary>
        /// Deletes client from the database
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteClient(int id)
        {
            try
            {
                return _clientRepository.DeleteClient(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
                //throw new ValidationException("Error occured while deleting client.");
            }
        }

        /// <summary>
        /// Fetches client from the database based on id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClientsData</returns>
        public Client GetClientById(int id)
        {
            try
            {
                return _clientRepository.GetClientById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
                //throw new ValidationException("Error occured while fetching client by id.");
            }
        }

        /// <summary>
        /// Fetches the list of clients from the database.
        /// </summary>
        /// <returns>list of Client</returns>
        public IList<Client> GetAllClients()
        {
            try
            {
                return _clientRepository.GetAllClients();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
                //throw new ValidationException("Error occured while fetching client list.");
            }
        }

        #endregion

        #region Other Calls


        #endregion

    }
}
