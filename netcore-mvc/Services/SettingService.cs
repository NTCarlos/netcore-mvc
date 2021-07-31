using Data.Models;
using Microsoft.Extensions.Logging;
using Common.DTO;
using Common.Exceptions.BadRequest;
using Common.Exceptions.NotFound;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.UoW;

namespace Services
{
    public class SettingService : ISettingService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger _logger;
        public SettingService(IUnitOfWork uow, ILogger<SettingService> logger)
        {
            _uow = uow;
            _logger = logger ?? throw new ArgumentNotFound(nameof(logger));
        }
        public async Task<IEnumerable<Setting>> GetAll()
        {
            var settings = await _uow.SettingsRepository.GetAllAsync();
            return settings;
        }
        public async Task<Setting> Get(int id)
        {
            if(id <= 0)
            {
                _logger.LogError("A Setting with that Id was not found.");
                throw new SettingNotFound();
            }
            var setting = await _uow.SettingsRepository.FirstOrDefaultAsync(x => x.Id == id);

            if(setting == null)
            {
                _logger.LogError("A Setting with that Id was not found.");
                throw new SettingNotFound();
            }
            return setting;
        }
        public async Task<Setting> Add(SettingDto setting)
        {
            var findSetting = _uow.SettingsRepository.FirstOrDefaultAsync(x => x.Key == setting.Key).Result;
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

            _uow.SettingsRepository.Add(newSetting);
            await _uow.CommitAsync();

            return newSetting;
        }
        public async Task<Setting> Update(SettingDto setting)
        {
            var findSetting = _uow.SettingsRepository.FirstOrDefaultAsync(x => x.Id == setting.Id).Result;
            if (findSetting == null)
            {
                _logger.LogError("A Setting with that Id was not found.");
                throw new SettingNotFound();
            }

            findSetting.Key = setting.Key;
            findSetting.Value = setting.Value;

            _uow.SettingsRepository.Update(findSetting);
            await _uow.CommitAsync();

            return findSetting;
        }
        public async Task<Setting> Delete(int id)
        {
            var findSetting = _uow.SettingsRepository.FirstOrDefaultAsync(x => x.Id == id).Result;
            if (findSetting == null)
            {
                _logger.LogError("A Setting with that Id was not found.");
                throw new SettingNotFound();
            }

            _uow.SettingsRepository.Delete(findSetting);
            await _uow.CommitAsync();

            return findSetting;
        }
    }
}
