using System.Collections.Generic;
using WebReports.Models;
using WebReports.Interfaces;
using WebReports.Helpers;


namespace WebReports.Repository
{
    public class ClientRepository : IClientRepository
    {
        #region Private Variables

        /// <summary>
        /// Private variable used for logging database operations
        /// </summary>
        private ILogger<ClientRepository> _logger;

        private readonly BSWebReportsDbContext _dbContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public ClientRepository(ILogger<ClientRepository> logger, BSWebReportsDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
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

                clientInfo.CreatedBy = clientInfo.LastUpdatedBy = "95c8645d-9059-4bfb-a4d3-42dfc1b04a21";
                clientInfo.CreatedOn = clientInfo.LastUpdatedOn=DateTime.Now;
                _dbContext.Add(clientInfo);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return clientInfo;
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

                //clientInfo.CreatedBy = 
                //clientInfo.CreatedOn = DateTime.Now;
                _dbContext.Update(clientInfo);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return clientInfo;
        }

        /// <summary>
        /// Deletes client from the database
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteClient(int id)
        {
            bool isSuccess = false;
            try
            {
                Client clientInfo = _dbContext.Clients.FirstOrDefault(m => m.Id == id);
                if (clientInfo != null)
                {
                    _dbContext.Clients.Remove(clientInfo);
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
        /// Fetches client from the database based on id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClientsData</returns>
        public Client GetClientById(int id)
        {
            Client clientInfo = null;
            try
            {
                clientInfo = _dbContext.Clients.FirstOrDefault(m => m.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return clientInfo;
        }

        /// <summary>
        /// Fetches the list of clients from the database.
        /// </summary>
        /// <returns>list of Client</returns>
        public IList<Client> GetAllClients()
        {
            IList<Client> clientList = new List<Client>();
            try
            {
                clientList = _dbContext.Clients.ToList();
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
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckClientExists(string name)
        {
            bool hasClient = false;
            try
            {
                Client clientInfo = _dbContext.Clients.FirstOrDefault(m => m.Name.Equals(name));
                if (null != clientInfo)
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
