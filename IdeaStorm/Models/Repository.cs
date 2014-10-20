using System.Data.Entity;
using System.Linq;

namespace IdeaStorm.Models
{
    public class Repository : IRepository
    {
        private IdeaContext _db;

        public Repository(IdeaContext db)
        {
            _db = db;
        }

        public IQueryable<Idea> GetAllIdeas()
        {
            return _db.Ideas;
        }

        public IQueryable<Idea> GetAllIdeasWithExperiments()
        {
            return _db.Ideas.Include(i => i.Experiments);
        }

        public Idea GetIdea(int id)
        {
            return _db.Ideas
                      .Include(i => i.Experiments)
                      .FirstOrDefault(i => i.Id == id);
        }
    }
}