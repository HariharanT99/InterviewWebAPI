using System.Data;
using DAL.Repository;
using IDAL.IConfiguration;
using IDAL.IRepository;
using Microsoft.Data.SqlClient;

namespace DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;

        public IApplicantRepository ApplicantRepository { get; set; }

        public UnitOfWork(string connectionString)
        {
            this._connection = new SqlConnection(connectionString);

            this.ApplicantRepository = new ApplicantRepository(this._connection);
        }
    }
}