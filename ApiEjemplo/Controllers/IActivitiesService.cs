using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiEjemplo.Controllers
{
    public interface IActivitiesService
    {
        Task<List<Activity>> Get();
        Task<Activity> Get(int id);
        Task Delete(int id);
        Task Update(int id, ActivityUpdate updateInfo);
        Task<int> Create(ActivityCreate act);
    }
}