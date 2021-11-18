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

        public IInterviewerReviewRepository InterviewerReviewRepository { get; private set; }

        public UnitOfWork(string connectionString)
        {
            this._connection = new SqlConnection(connectionString);

            this.ApplicantRepository = new ApplicantRepository(this._connection);

            this.InterviewRepository = new InterviewRepository(this._connection);

            this.InterviewerReviewRepository = new InterviewerReviewRepository(this._connection);

            this.UserRepository = new UserRepository(this._connection);
        }
    }
}