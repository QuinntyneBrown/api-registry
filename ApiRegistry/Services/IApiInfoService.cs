using ApiRegistry.Dtos;
using System.Collections.Generic;

namespace ApiRegistry.Services
{
    public interface IApiInfoService
    {
        ApiInfoAddOrUpdateResponseDto AddOrUpdate(ApiInfoAddOrUpdateRequestDto request);
        ICollection<ApiInfoDto> Get();
        ApiInfoDto GetById(int id);
        dynamic Remove(int id);
    }
}
