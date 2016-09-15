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
            GitHubRepoUri = entity.GithubRepoUri;

        }

        public ApiInfoDto() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SwaggerUri { get; set; }
        public string GitHubRepoUri { get; set; }
    }
}
