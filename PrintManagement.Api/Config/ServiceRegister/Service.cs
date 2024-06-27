using PrintManagement.Domain.Entities;
using PrintManagement.Domain.InterfaceRepositories.InterfaceBase;
using PrintManagement.Domain.InterfaceRepositories.InterfaceUser;
using PrintManagement.Infrastructure.ImplementRepositories.ImplementBase;
using PrintManagement.Infrastructure.ImplementRepositories.ImplementUser;

namespace PrintManagement.Api.Config.ServiceRegister
{
    public static class Service
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository<User>, UserRepository<User>>();
            services.AddScoped<IBaseReposiroty<RefreshToken>, BaseRepository<RefreshToken>>();
            services.AddScoped<IBaseReposiroty<ConfirmEmail>, BaseRepository<ConfirmEmail>>();
            services.AddScoped<IBaseReposiroty<Customer>, BaseRepository<Customer>>();
            services.AddScoped<IBaseReposiroty<Project>, BaseRepository<Project>>();
            services.AddScoped<IBaseReposiroty<Design>, BaseRepository<Design>>();
            services.AddScoped<IBaseReposiroty<ImportCoupon>, BaseRepository<ImportCoupon>>();
            services.AddScoped<IBaseReposiroty<Team>, BaseRepository<Team>>();
            services.AddScoped<IBaseReposiroty<ResourceProperty>, BaseRepository<ResourceProperty>>();
            services.AddScoped<IBaseReposiroty<ResourcePropertyDetail>, BaseRepository<ResourcePropertyDetail>>();
            services.AddScoped<IBaseReposiroty<Resource>, BaseRepository<Resource>>();
            services.AddScoped<IBaseReposiroty<Permissions>, BaseRepository<Permissions>>();
            services.AddScoped<IBaseReposiroty<Role>, BaseRepository<Role>>();
            services.AddScoped<IBaseReposiroty<ShippingMethod>, BaseRepository<ShippingMethod>>();
            services.AddScoped<IBaseReposiroty<PrintJob>, BaseRepository<PrintJob>>();
            services.AddScoped<IBaseReposiroty<ResourceForPrintJob>, BaseRepository<ResourceForPrintJob>>();
            services.AddScoped<IBaseReposiroty<Notification>, BaseRepository<Notification>>();
            services.AddScoped<IBaseReposiroty<Delivery>, BaseRepository<Delivery>>();
            services.AddScoped<IBaseReposiroty<ConfirmReceiptOfGoodsFromCustomer>, BaseRepository<ConfirmReceiptOfGoodsFromCustomer>>();
            services.AddScoped<IBaseReposiroty<KeyPerformanceIndicators>, BaseRepository<KeyPerformanceIndicators>>();
            services.AddScoped<IBaseReposiroty<ResourceType>, BaseRepository<ResourceType>>();
            services.AddScoped<IBaseReposiroty<Bill>, BaseRepository<Bill>>();
        }
    }
}
