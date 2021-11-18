using IDAL.IRepository;

namespace IDAL.IConfiguration
{
    public interface IUnitOfWork
    {
        IApplicantRepository ApplicantRepository { get; }

        IInterviewRepository InterviewRepository { get; }

        IInterviewerReviewRepository InterviewerReviewRepository { get; }

        IDesignationRepository DesignationRepository { get; }
        
        IUserRepository UserRepository { get; }
    }
}