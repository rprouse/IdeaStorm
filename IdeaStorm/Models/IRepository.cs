using System.Linq;

namespace IdeaStorm.Models
{
    public interface IRepository
    {
        IQueryable<Idea> GetAllIdeas();
        IQueryable<Idea> GetAllIdeasWithExperiments();
        Idea GetIdea(int id);
    }
}