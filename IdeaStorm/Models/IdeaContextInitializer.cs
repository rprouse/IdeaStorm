using System.Collections.Generic;
using System.Data.Entity;

namespace IdeaStorm.Models
{
    public class IdeaContextInitializer : DropCreateDatabaseIfModelChanges<IdeaContext>
    {
        protected override void Seed(IdeaContext context)
        {
            var ideas = new List<Idea>
            {
                new Idea { Name = "Time tracking software", Description = "aimed at sole web/software developers. Check out http://forum.freelanceswitch.com/ for what others are currently using to gauge demand. FreshBooks is fairly heavy into this market." },
                new Idea { Name = "Resume template", Description = "hosting and automatic mailing with cover letters" },
                new Idea { Name = "Online restaurant website creation and hosting", Description = "Create website from templates\r\nMenus\r\nCoupons\r\nReservations?\r\nMailing lists?\r\nDaily specials\r\nIntegration with twitter\r\nCreate free wordpress templates for restaurants and host on the mini-sales site to draw links and potential subscribers.\r\n\r\nWhat's the best way to make a web site if you're a real estate agent, or a restaurant, or a lawyer? There still don't seem to be canonical answers.\r\n\r\nObviously the way to build this is to write a flexible site builder, then write layers on top to produce different variants. Hint: The key to making a site builder for end-users is to make software that lets people with no design ability produce things that look good—or at least professional." },
                new Idea { Name = "Senior Checkin", Description = "Software for seniors to check in with their kids allowing them to stay in their homes longer" },
                new Idea { Name = "Recruiting software", Description = "Software for small 1-4 person recruiting firms to aid in the search for candidates, tracking jobs and sendouts." },
                new Idea { Name = "Wine distribution", Description = "website for small wineries to sell their wine. We would take the orders and pass them on to the wineries to fulfill meaning we don't need to maintain any inventory." },
                new Idea { Name = "Idea Trackr (Vault)", Description = "Website to track business ideas, notes, pros, cons, market research. Eventually, add ability to share ideas, look for investors, look for partners, ask for comments on ideas?" },
            };
            //ideas[4].Experiments.Add(new Experiment { Sequence = 1, Customer = "Small recruiting firms", Problem = "Need to track prospects, jobs, etc", Solution = "Software!", RiskiestAssumptions = "Already have adaquate software" });
            //ideas[6].Experiments.Add(new Experiment { Sequence = 1, Customer = "Entrepreneurs", Problem = "Need a way to track and validate ideas", Solution = "Software to track ideas, flesh them out and run experiments on them", RiskiestAssumptions = "Are they willing to pay for the service?" });
            ideas.ForEach(i => context.Ideas.Add(i));
            context.SaveChanges();

            var experiments = new List<Experiment>
            {
                new Experiment { IdeaId = ideas[4].Id, Sequence = 1, Customer = "Small recruiting firms", Problem = "Need to track prospects, jobs, etc", Solution = "Software!", RiskiestAssumptions = "Already have adaquate software" },
                new Experiment { IdeaId = ideas[6].Id, Sequence = 1, Customer = "Entrepreneurs", Problem = "Need a way to track and validate ideas", Solution = "Software to track ideas, flesh them out and run experiments on them", RiskiestAssumptions = "Are they willing to pay for the service?"}
            };
            experiments.ForEach(e => context.Experiments.Add(e));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}