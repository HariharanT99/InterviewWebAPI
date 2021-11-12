using DAL.Data;
using IBLL;
using IDAL.IConfiguration;

namespace BLL
{
    public class Service : IService
    {
        private readonly IUnitOfWork _uow;
        public IAdminService AdminService { get; private set; }

        public Service(string connectionString)
        {
            this._uow = new UnitOfWork(connectionString);

            this.AdminService = new AdminService(this._uow);
        }

    }
}