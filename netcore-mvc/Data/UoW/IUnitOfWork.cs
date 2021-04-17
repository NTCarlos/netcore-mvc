using Data.Models;
using Data.Repositories;
using System.Threading.Tasks;

namespace Data.UoW
{
    public interface IUnitOfWork
    {
        IGenericRepository<Setting> SettingsRepository { get; set; }
        Task<int> CommitAsync();
    }
}