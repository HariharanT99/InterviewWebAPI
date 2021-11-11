using System.Data;
using IDAL.IRepository;

namespace DAL.Repository
{
    public class GenericRepository : IGenericRepository
    {

        protected IDbConnection Connection { get; private set; }

        public GenericRepository(IDbConnection connection)
        {
            this.Connection = connection;
        }

    }
}