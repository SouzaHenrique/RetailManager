using RMDataManager.Library.Internal.DataAccess;
using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    /// <summary>
    /// Access User data in a SQL database
    /// </summary>
    public class UserData
    {
        /// <summary>
        /// Gets a user information based on it's id
        /// </summary>
        /// <param name="Id">The user's id</param>
        /// <returns></returns>
        public List<UserModel> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = Id };

            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "RMData");

            return output;                
        }
    }
}
