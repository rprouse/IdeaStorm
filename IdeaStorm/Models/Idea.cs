using System;
using System.Collections.Generic;

namespace IdeaStorm.Models
{
    public class Idea
    {
        public Idea()
        {
            Experiments = new List<Experiment>();
            Date = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ValueProposition { get; set; }
        public string TargetMarket { get; set; }
        public string UniqueSellingPropositon { get; set; }
        public string RevenueModel { get; set; }
        public string Competitors { get; set; }
        public string StartupCosts { get; set; }
        public string BarriersToEntry { get; set; }
        public string NameIdeas { get; set; }
        public string NicheEvaluation { get; set; }
        public string Pros { get; set; }
        public string Cons { get; set; }
        public string Feedback { get; set; }
        public int Rating { get; set; }

        public virtual ICollection<Experiment> Experiments { get; set; } 
    }
}