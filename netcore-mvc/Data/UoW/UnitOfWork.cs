using Data.Models;
using Data.Repositories;
using netcore_mvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UoW
{
    #region Implementation
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            SettingsRepository = SettingsRepository ?? new GenericRepository<Setting>(_context);
        }

        public IGenericRepository<Setting> SettingsRepository { get; set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
    #endregion

    #region Interface
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Setting> SettingsRepository { get; set; }

        Task<int> CommitAsync();
    }
    #endregion
}
