namespace ApiRegistry.Data
{
    public interface IUow
    {
        IRepository<Models.ApiInfo> ApiInfos { get; }
        IRepository<Models.User> Users { get; }
        IRepository<Models.Role> Roles { get; }

        void SaveChanges();
    }
}
