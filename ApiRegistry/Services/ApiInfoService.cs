using System;
using System.Collections.Generic;
using ApiRegistry.Data;
using ApiRegistry.Dtos;
using System.Data.Entity;
using System.Linq;
using ApiRegistry.Models;

namespace ApiRegistry.Services
{
    public class ApiInfoService : IApiInfoService
    {
        public ApiInfoService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.ApiInfos;
            _cache = cacheProvider.GetCache();
        }

        public ApiInfoAddOrUpdateResponseDto AddOrUpdate(ApiInfoAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new ApiInfo());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new ApiInfoAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<ApiInfoDto> Get()
        {
            ICollection<ApiInfoDto> response = new HashSet<ApiInfoDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new ApiInfoDto(entity)); }    
            return response;
        }


        public ApiInfoDto GetById(int id)
        {
            return new ApiInfoDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<ApiInfo> _repository;
        protected readonly ICache _cache;
    }
}
