using WebReports.Interfaces;
using WebReports.Models;

namespace WebReports.Repository
{
    public class ClientMenuRepository : IClientMenuRepository
    {

        #region Private Variables

        /// <summary>
        /// Private variable used for logging database operations
        /// </summary>
        private ILogger<ClientMenuRepository> _logger;

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
        public ClientMenuRepository(ILogger<ClientMenuRepository> logger, BSWebReportsDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
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

                clientMenuInfo.CreatedBy = clientMenuInfo.LastUpdatedBy = "95c8645d-9059-4bfb-a4d3-42dfc1b04a21";
                clientMenuInfo.CreatedOn = clientMenuInfo.LastUpdatedOn = DateTime.Now;
                _dbContext.Add(clientMenuInfo);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return clientMenuInfo;
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

                //clientMenuInfo.CreatedBy = 
                //clientMenuInfo.CreatedOn = DateTime.Now;
                _dbContext.Update(clientMenuInfo);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return clientMenuInfo;
        }

        /// <summary>
        /// Deletes client menu from the database
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteClientMenu(int id)
        {
            bool isSuccess = false;
            try
            {
                ClientMenu clientMenuInfo = _dbContext.ClientMenus.FirstOrDefault(m => m.Id == id);
                if (clientMenuInfo != null)
                {
                    _dbContext.ClientMenus.Remove(clientMenuInfo);
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
        /// Fetches client menu from the database based on id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClientsData</returns>
        public ClientMenu GetClientMenuById(int id)
        {
            ClientMenu clientMenuInfo = null;
            try
            {
                clientMenuInfo = _dbContext.ClientMenus.FirstOrDefault(m => m.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return clientMenuInfo;
        }

        /// <summary>
        /// Fetches the list of all client menus from the database.
        /// </summary>
        /// <returns>list of ClientMenu</returns>
        public IList<ClientMenu> GetAllClientMenus()
        {
            IList<ClientMenu> clientList = new List<ClientMenu>();
            try
            {
                clientList = _dbContext.ClientMenus.ToList();
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
        public IList<ClientMenu> GetClientMenusByClientId(int clientId)
        {
            IList<ClientMenu> clientList = new List<ClientMenu>();
            try
            {
                clientList = _dbContext.ClientMenus.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            return clientList;
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
            bool hasClient = false;
            try
            {
                ClientMenu clientMenuInfo = _dbContext.ClientMenus.FirstOrDefault(m => m.WorkspaceId.Equals(workspaceId) && m.ReportId.Equals(reportId) && m.ClientId.Equals(clientId));
                if (null != clientMenuInfo)
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
