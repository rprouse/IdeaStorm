using System.Linq;
using System.Web.Http;
using Breeze.ContextProvider;
using Breeze.WebApi2;
using IdeaStorm.Models;
using Newtonsoft.Json.Linq;

namespace IdeaStorm.Controllers
{
    [BreezeController]
    public class ApiController : System.Web.Http.ApiController
    {
        private readonly IRepository _repository;

        public ApiController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public string Metadata()
        {
            return _repository.Metadata;
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _repository.SaveChanges(saveBundle);
        }

        [HttpGet]
        public IQueryable<Idea> Ideas()
        {
            return _repository.Ideas();
        }

        [HttpGet]
        public IQueryable<Experiment> Experiments()
        {
            return _repository.Experiments();
        }
    }
}
