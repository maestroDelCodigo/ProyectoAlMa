using System.Threading.Tasks;

namespace ApiEjemplo
{
    public interface IMyApi
    {
        Task<bool> UserExist(string userId);
    }
}