using IDAL.IRepository;

namespace IDAL.IConfiguration
{
    public interface IUnitOfWork
    {
        IApplicantRepository ApplicantRepository { get; }
        IInterviewRepository InterviewRepository { get; }
        IDesignationRepository DesignationRepository { get; }
        IUserRepository UserRepository { get; }
    }
}