using System.Data;
using IDAL.IConfiguration;
using Microsoft.Data.SqlClient;

namespace DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;

        public UnitOfWork(string connectionString)
        {
            this._connection = new SqlConnection(connectionString);
        }
    }
}