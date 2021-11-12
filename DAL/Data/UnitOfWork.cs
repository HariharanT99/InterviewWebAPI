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
            _connection = new SqlConnection(connectionString);

            ApplicantRepository = new ApplicantRepository(_connection);

        }
    }
}