using ApiRegistry.Dtos;
using ApiRegistry.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ApiRegistry.Controllers
{
    [Authorize]
    [RoutePrefix("api/apiInfo")]
    public class ApiInfoController : ApiController
    {
        public ApiInfoController(IApiInfoService apiInfoService)
        {
            _apiInfoService = apiInfoService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(ApiInfoAddOrUpdateResponseDto))]
        public IHttpActionResult Add(ApiInfoAddOrUpdateRequestDto dto) { return Ok(_apiInfoService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(ApiInfoAddOrUpdateResponseDto))]
        public IHttpActionResult Update(ApiInfoAddOrUpdateRequestDto dto) { return Ok(_apiInfoService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<ApiInfoDto>))]
        public IHttpActionResult Get() { return Ok(_apiInfoService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(ApiInfoDto))]
        public IHttpActionResult GetById(int id) { return Ok(_apiInfoService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_apiInfoService.Remove(id)); }

        protected readonly IApiInfoService _apiInfoService;


    }
}
