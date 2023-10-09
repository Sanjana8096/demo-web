using WebReports.Models;

namespace WebReports.Interfaces
{
    public interface IClientUserService
    {

        #region Default CRUD Calls

        /// <summary>
        /// Creates a client user in the database
        /// </summary>
        /// <param name="clientUserInfo"></param>
        /// <returns>ClientUser data</returns>
        ClientUser CreateClientUser(ClientUser clientUserInfo);

        /// <summary>
        /// Edits client user in the database
        /// </summary>
        /// <param name="clientUserInfo"></param>
        /// <returns>ClientsData</returns>
        ClientUser EditClientUser(ClientUser clientUserInfo);

        /// <summary>
        /// Deletes client user from the database
        /// </summary>
        /// <param name="id"></param>
        bool DeleteClientUser(int id);

        /// <summary>
        /// Fetches client user from the database based on id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClientsData</returns>
        ClientUser GetClientUserById(int id);

        /// <summary>
        /// Fetches the list of all client users from the database.
        /// </summary>
        /// <returns>list of ClientUser</returns>
        IList<ClientUser> GetAllClientUsers();

        #endregion

        #region Other Calls


        /// <summary>
        ///  Fetches the list of client users from the database based on client id.
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        IList<ClientUser> GetClientUsersByClientId(int clientId);

        /// <summary>
        /// Checks whether the client user exists. user id is unique for client.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        bool CheckClientUserExists(string userId, int clientId);

        #endregion

    }
}
