using Kafedra.Application.DTOs;
using Kafedra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Business.Services.Interfaces
{
    public interface ISettingService
    {
        public PagenatedListDto<Setting> GetPaginateSettings(int page );
        public void UpdateSetting( Setting setting );
    }
}
