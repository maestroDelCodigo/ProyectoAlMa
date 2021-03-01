using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEjemplo.Controllers;

namespace ApiEjemplo
{
    public class ActivityService : IActivitiesService
    {
        private readonly StravaContext context;

        public ActivityService(StravaContext context)
        {
            this.context = context;
        }

        public async Task<List<Activity>> Get()
        {
            return context.Activities.ToList();
        }

        public async Task<Activity> Get(int id)
        {
            return context.Activities.FirstOrDefault(a => a.Id == id);
        }

        public async Task Delete(int id)
        {
            var activity = await Get(id);
            context.Activities.Remove(activity);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, ActivityUpdate updateInfo)
        {
            var activity = await Get(id);
            activity.FinishDate = updateInfo.FinishDate;
            activity.StartDate = updateInfo.StartDate;
            await context.SaveChangesAsync();
        }

        public async Task<int> Create(ActivityCreate act)
        {
            var activity = new Activity
            {
                FinishDate = act.FinishDate,
                StartDate = act.StartDate, 
                Creator = "Yo", 
            };

            context.Activities.Add(activity);
            await context.SaveChangesAsync();
            
            return activity.Id;
        }
    }
}