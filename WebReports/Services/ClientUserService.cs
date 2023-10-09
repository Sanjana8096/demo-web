using WebReports.Interfaces;
using WebReports.Models;
using WebReports.Helpers;
using Microsoft.Extensions.Logging;

namespace WebReports.Services
{
    public class ClientUserService
    {

        #region Private Variables

        /// <summary>
        /// Logger to be used to log messages
        /// </summary>
        private ILogger<ClientUserService> _logger;

        /// <summary>
        /// Private variable used for IClientUserRepository
        /// </summary>
        private IClientUserRepository _clientUserRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="clientUserRepository"></param>
        public ClientUserService(ILogger<ClientUserService> logger, IClientUserRepository clientUserRepository)
        {
            _logger = logger;
            _clientUserRepository = clientUserRepository;
        }

        #endregion

        #region Default CRUD Calls

        /// <summary>
        /// Creates a client user in the database
        /// </summary>
        /// <param name="clientUserInfo"></param>
        /// <returns>ClientUser data</returns>
        public ClientUser CreateClientUser(ClientUser clientUserInfo)
        {
            try
            {
                return _clientUserRepository.CreateClientUser(clientUserInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new ValidationException("Error occured while adding client user.");
            }
        }

        /// <summary>
        /// Edits client user in the database
        /// </summary>
        /// <param name="clientUserInfo"></param>
        /// <returns>ClientsData</returns>
        public ClientUser EditClientUser(ClientUser clientUserInfo)
        {
            try
            {
                return _clientUserRepository.EditClientUser(clientUserInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new ValidationException("Error occured while editing client user.");
            }
        }

        /// <summary>
        /// Deletes client user from the database
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteClientUser(int id)
        {
            try
            {
                return _clientUserRepository.DeleteClientUser(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new ValidationException("Error occured while deleting client user.");
            }
        }

        /// <summary>
        /// Fetches client user from the database based on id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClientsData</returns>
        public ClientUser GetClientUserById(int id)
        {
            try
            {
                return _clientUserRepository.GetClientUserById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new ValidationException("Error occured while fetching client user by id.");
            }
        }

        /// <summary>
        /// Fetches the list of all client users from the database.
        /// </summary>
        /// <returns>list of ClientUser</returns>
        public IList<ClientUser> GetAllClientUsers()
        {
            try
            {
                return _clientUserRepository.GetAllClientUsers();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new ValidationException("Error occured while fetching all client user list.");
            }
        }

        #endregion

        #region Other Calls


        /// <summary>
        ///  Fetches the list of client users from the database based on client id.
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public IList<ClientUser> GetClientUsersByClientId(int clientId)
        {
            try
            {
                return _clientUserRepository.GetClientUsersByClientId(clientId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new ValidationException("Error occured while fetching client user list by client id.");
            }
        }

        /// <summary>
        /// Checks whether the client user exists. user id is unique for client.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public bool CheckClientUserExists(string userId, int clientId)
        {
            try
            {
                return _clientUserRepository.CheckClientUserExists(userId, clientId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new ValidationException("Error occured while checking if client user exists by user id.");
            }
        }

        #endregion

    }
}
