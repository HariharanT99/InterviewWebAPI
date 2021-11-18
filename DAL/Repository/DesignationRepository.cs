using Dapper;
using IDAL.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace DAL.Repository
{
    public class DesignationRepository : GenericRepository, IDesignationRepository
    {
        public DesignationRepository(IDbConnection connection) : base(connection) { }

        public async Task<ResponseViewModel<List<DesignationViewModel>>> GetAllDesignation()
        {
            ResponseViewModel<List<DesignationViewModel>> result = new();
            try
            {
                var sp = "uspGetDesignation";

                var designationList = new List<DesignationViewModel>();

                var data = await Connection.QueryAsync<DesignationViewModel>(sp);

                designationList = data.ToList();

                result.Data = designationList;
            }
            catch (Exception)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Something went wrong";
                result.Error.ErrorCode = 500;
            }
            return result;
        }
    }
}
