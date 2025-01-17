﻿using Data.Models;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISettingService
    {
        public Task<IEnumerable<Setting>> GetAll();
        public Task<Setting> Add(SettingDto setting);
        public Task<Setting> Get(int id);
        public Task<Setting> Update(SettingDto setting);
        public Task<Setting> Delete(int id);
    }
}
