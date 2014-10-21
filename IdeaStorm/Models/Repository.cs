using System.Linq;
using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Newtonsoft.Json.Linq;

namespace IdeaStorm.Models
{
    public class Repository : IRepository
    {
        private readonly EFContextProvider<IdeaContext> _contextProvider = new EFContextProvider<IdeaContext>();

        public string Metadata { get { return _contextProvider.Metadata(); } }

        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }

        public IQueryable<Idea> Ideas()
        {
            return _contextProvider.Context.Ideas;
        }

        public IQueryable<Experiment> Experiments()
        {
            return _contextProvider.Context.Experiments;
        }
    }
}