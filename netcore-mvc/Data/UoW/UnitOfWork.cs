using Data.Models;
using Data.Repositories;
using netcore_mvc.Data;
using System;
using System.Threading.Tasks;

namespace Data.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            SettingsRepository ??= new GenericRepository<Setting>(_context);
        }

        public IGenericRepository<Setting> SettingsRepository { get; set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}