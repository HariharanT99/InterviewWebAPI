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
        public IApplicantRepository ApplicantRepository { get; private set; }
        public IInterviewRepository InterviewRepository { get; private set; }
        public IDesignationRepository DesignationRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public UnitOfWork(string connectionString)
        {
            _connection = new SqlConnection(connectionString);

            ApplicantRepository = new ApplicantRepository(_connection);
            InterviewRepository = new InterviewRepository(_connection);
            DesignationRepository = new DesignationRepository(_connection);
            UserRepository = new UserRepository(_connection);
        }
    }
}