using ApiRegistry.Models;

namespace ApiRegistry.Dtos
{
    public class ApiInfoDto
    {
        public ApiInfoDto(ApiInfo entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            SwaggerUri = entity.SwaggerUri;

        }

        public ApiInfoDto() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SwaggerUri { get; set; }
    }
}
