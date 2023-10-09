using WebReports.Interfaces;
using WebReports.Models;

namespace WebReports.Repository
{
    public class ClientUserRepository : IClientUserRepository
    {

        #region Private Variables

        /// <summary>
        /// Private variable used for logging database operations
        /// </summary>
        private ILogger<ClientUserRepository> _logger;

        /// <summary>
        /// Private variable used for database context
        /// </summary>
        private readonly BSWebReportsDbContext _dbContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="dbContext"></param>
        public ClientUserRepository(ILogger<ClientUserRepository> logger, BSWebReportsDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
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

                clientUserInfo.CreatedBy = clientUserInfo.LastUpdatedBy = "95c8645d-9059-4bfb-a4d3-42dfc1b04a21";
                clientUserInfo.CreatedOn = clientUserInfo.LastUpdatedOn = DateTime.Now;
                _dbContext.Add(clientUserInfo);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return clientUserInfo;
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

                //clientUserInfo.CreatedBy = 
                //clientUserInfo.CreatedOn = DateTime.Now;
                _dbContext.Update(clientUserInfo);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return clientUserInfo;
        }

        /// <summary>
        /// Deletes client user from the database
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteClientUser(int id)
        {
            bool isSuccess = false;
            try
            {
                ClientUser clientUserInfo = _dbContext.ClientUsers.FirstOrDefault(m => m.Id == id);
                if (clientUserInfo != null)
                {
                    _dbContext.ClientUsers.Remove(clientUserInfo);
                    _dbContext.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return isSuccess;
        }

        /// <summary>
        /// Fetches client user from the database based on id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClientsData</returns>
        public ClientUser GetClientUserById(int id)
        {
            ClientUser clientUserInfo = null;
            try
            {
                clientUserInfo = _dbContext.ClientUsers.FirstOrDefault(m => m.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return clientUserInfo;
        }

        /// <summary>
        /// Fetches the list of all client menus from the database.
        /// </summary>
        /// <returns>list of ClientUser</returns>
        public IList<ClientUser> GetAllClientUsers()
        {
            IList<ClientUser> clientList = new List<ClientUser>();
            try
            {
                clientList = _dbContext.ClientUsers.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return clientList;
        }

        #endregion

        #region Other Calls


        /// <summary>
        ///  Fetches the list of client menus from the database based on client id.
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public IList<ClientUser> GetClientUsersByClientId(int clientId)
        {
            IList<ClientUser> clientList = new List<ClientUser>();
            try
            {
                clientList = _dbContext.ClientUsers.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return clientList;
        }

        /// <summary>
        /// Checks whether the client user exists. user id is unique for client.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public bool CheckClientUserExists(string userId, int clientId)
        {
            bool hasClient = false;
            try
            {
                ClientUser clientUserInfo = _dbContext.ClientUsers.FirstOrDefault(m => m.UserId.Equals(userId) && m.ClientId.Equals(clientId));
                if (null != clientUserInfo)
                {
                    hasClient = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return hasClient;
        }

        #endregion

    }
}
