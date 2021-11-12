using IDAL.IConfiguration;

namespace BLL
{
    public class GenericService
    {
        protected IUnitOfWork UnitOfWork;
        public GenericService(IUnitOfWork uow)
        {
            this.UnitOfWork = uow;
        }
    }
}