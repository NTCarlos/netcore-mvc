using Data.Models;
using Data.Repositories;
using Microsoft.Extensions.Logging;
using Services.DTO;
using Services.Exceptions.BadRequest;
using Services.Exceptions.NotFound;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class SettingService : ISettingService
    {
        private readonly IGenericRepository<Setting> _repo;
        private readonly ILogger _logger;
        public SettingService(IGenericRepository<Setting> repo, ILogger<SettingService> logger)
        {
            _repo = repo ?? throw new ArgumentNotFound(nameof(repo));
            _logger = logger ?? throw new ArgumentNotFound(nameof(logger));
        }
        public async Task<IEnumerable<Setting>> GetAll()
        {
            var settings = await _repo.GetAllAsync();
            return settings;
        }
        public async Task<Setting> Get(int id)
        {
            if(id <= 0)
            {
                _logger.LogError("A Setting with that Id was not found.");
                throw new SettingNotFound();
            }
            var setting = await _repo.FirstOrDefaultAsync(x => x.Id == id);

            if(setting == null)
            {
                _logger.LogError("A Setting with that Id was not found.");
                throw new SettingNotFound();
            }
            return setting;
        }
        public async Task<Setting> Add(SettingDto setting)
        {
            var findSetting = _repo.FirstOrDefaultAsync(x => x.Key == setting.Key).Result;
            if (findSetting != null)
            {
                _logger.LogError("A Setting with that Key already exist.");
                throw new KeyAlreadyExistException();
            }

            var newSetting = new Setting
            {
                Key = setting.Key,
                Value = setting.Value
            };

            _repo.Add(newSetting);
            await _repo.SaveChangesAsync();

            return newSetting;
        }
        public async Task<Setting> Update(SettingDto setting)
        {
            var findSetting = _repo.FirstOrDefaultAsync(x => x.Id == setting.Id).Result;
            if (findSetting == null)
            {
                _logger.LogError("A Setting with that Id was not found.");
                throw new SettingNotFound();
            }

            findSetting.Key = setting.Key;
            findSetting.Value = setting.Value;

            _repo.Update(findSetting);
            await _repo.SaveChangesAsync();

            return findSetting;
        }
        public async Task<Setting> Delete(int id)
        {
            var findSetting = _repo.FirstOrDefaultAsync(x => x.Id == id).Result;
            if (findSetting == null)
            {
                _logger.LogError("A Setting with that Id was not found.");
                throw new SettingNotFound();
            }

            _repo.Delete(findSetting);
            await _repo.SaveChangesAsync();

            return findSetting;
        }
    }
}
