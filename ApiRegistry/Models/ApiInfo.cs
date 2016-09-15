namespace ApiRegistry.Models
{
    public class ApiInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SwaggerUri { get; set; }
        public string GithubRepoUri { get; set; }
        public bool IsDeleted { get; set; }
    }
}
