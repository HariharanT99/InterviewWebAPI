using IBLL;

namespace API.Controllers
{
    public class GenericController
    {
        protected IService Service { get; set; }

        public GenericController(IService service)
        {
            this.Service = service;
        }
    }
}