using System;

namespace IdeaStorm.Models
{
    public class Experiment
    {
        public Experiment()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Sequence { get; set; }
        public string Customer { get; set; }
        public string Problem { get; set; }
        public string Solution { get; set; }
        public string RiskiestAssumptions { get; set; }
        public string Method { get; set; }
        public string SuccessCriteria { get; set; }
        public string Result { get; set; }
        public string Decision { get; set; }
        public string Learning { get; set; }
        public bool Completed { get; set; }

        public int IdeaId { get; set; }

        public virtual Idea Idea { get; set; }
    }
}