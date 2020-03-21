using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.Internal.DataAccess
{
    /// <summary>
    /// Provides access to a sql server db
    /// </summary>
    internal class SqlDataAccess
    {
        /// <summary>
        /// Retrieves a connection string for our db based on configuration file
        /// </summary>
        /// <param name="name">A connection string name to look for in configuration file</param>
        /// <returns>the connection string</returns>
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// Generic method to load data from our SQL database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="storedProceure"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        public List<T> LoadData<T, U>(string storedProceure, U parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(storedProceure, parameters, 
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }


        /// <summary>
        /// Generic method to save data to our SQL database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProceure"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionStringName"></param>
        public void SaveData<T>(string storedProceure, T parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection())
            {
                connection.Execute(storedProceure, parameters,
                    commandType: CommandType.StoredProcedure);              
            }
        }


    }
}
