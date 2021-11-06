using DAL.Data;
using IBLL;
using IDAL.IConfiguration;

namespace BLL
{
    public class Service : IService
    {
        private readonly IUnitOfWork _uow;

        public Service(string connectionString)
        {
            this._uow = new UnitOfWork(connectionString);
        }

    }
}