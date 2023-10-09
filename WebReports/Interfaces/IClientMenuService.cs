using WebReports.Models;

namespace WebReports.Interfaces
{
    public interface IClientMenuService
    {

        #region Default CRUD Calls

        /// <summary>
        /// Creates a client menu in the database
        /// </summary>
        /// <param name="clientMenuInfo"></param>
        /// <returns>ClientMenu data</returns>
        ClientMenu CreateClientMenu(ClientMenu clientMenuInfo);

        /// <summary>
        /// Edits client menu in the database
        /// </summary>
        /// <param name="clientMenuInfo"></param>
        /// <returns>ClientsData</returns>
        ClientMenu EditClientMenu(ClientMenu clientMenuInfo);

        /// <summary>
        /// Deletes client menu from the database
        /// </summary>
        /// <param name="id"></param>
        bool DeleteClientMenu(int id);

        /// <summary>
        /// Fetches client menu from the database based on id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClientsData</returns>
        ClientMenu GetClientMenuById(int id);

        /// <summary>
        /// Fetches the list of all client menus from the database.
        /// </summary>
        /// <returns>list of ClientMenu</returns>
        IList<ClientMenu> GetAllClientMenus();

        #endregion

        #region Other Calls


        /// <summary>
        ///  Fetches the list of client menus from the database based on client id.
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        IList<ClientMenu> GetClientMenusByClientId(int clientId);

        /// <summary>
        /// Checks whether the client menu exists. Workspace id, report id is unique for client.
        /// </summary>
        /// <param name="workspaceId"></param>
        /// <param name="reportId"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        bool CheckClientMenuExists(string workspaceId, string reportId, int clientId);

        #endregion

    }
}
