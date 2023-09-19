using System.Collections.Generic;
using WebReports.Models;

namespace WebReports.Interfaces
{
    public interface IClientService
    {

        #region Default CRUD Calls

        /// <summary>
        /// Creates an client in the database
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <returns>ClientsData</returns>
        Client CreateClient(Client clientInfo);

        /// <summary>
        /// Edits client in the database
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <returns>ClientsData</returns>
        Client EditClient(Client clientInfo);

        /// <summary>
        /// Deletes client from the database
        /// </summary>
        /// <param name="id"></param>
        bool DeleteClient(int id);

        /// <summary>
        /// Fetches client from the database based on id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClientsData</returns>
        Client GetClientById(int id);

        /// <summary>
        /// Fetches the list of clients from the database.
        /// </summary>
        /// <returns>list of Client</returns>
        IList<Client> GetAllClients();

        #endregion

        #region Other Calls

        #endregion

    }
}
