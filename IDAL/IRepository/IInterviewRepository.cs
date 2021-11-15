using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace IDAL.IRepository
{
    public interface IInterviewRepository
    {
        Task<ResponseViewModel<bool>> PromoteApplicant(PromoteApplicantViewModel model);
    }
}
