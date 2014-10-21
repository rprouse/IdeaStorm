using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;

namespace IdeaStorm.Models
{
    public interface IRepository
    {
        string Metadata { get; }
        SaveResult SaveChanges(JObject saveBundle);
        IQueryable<Idea> Ideas();
        IQueryable<Experiment> Experiments();
    }
}