using PrintManagement.Application.ImplementServices;
using PrintManagement.Application.InterfaceServices;
using PrintManagement.Domain.Entities;
using PrintManagement.Domain.InterfaceRepositories.InterfaceBase;
using PrintManagement.Infrastructure.DataContexts;
using PrintManagement.Infrastructure.ImplementRepositories.ImplementBase;

namespace PrintManagement.Api.Config.ServiceOther
{
    public static class OtherService
    {
        public static void Other(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IBaseReposiroty<User>, BaseRepository<User>>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IDbContext, ApplicationDbContext>();
            services.AddScoped<IShippingMethodService, ShippingMethodService>();
            services.AddScoped<IDesignService, DesignService>();
            services.AddScoped<ICustomerFeedbackService, CustomerFeedbackService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IImportCouponService, ImportCouponService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IResourceService, ResourceService>();
            services.AddScoped<IPrintJobService, PrintJobService>();
            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<IKPIService, KPIService>();
            services.AddScoped<IResourceTypeService, ResourceTypeService>();
            services.AddScoped<IStatisticService, StatisticService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IBlacklistedTokenService, BlacklistedTokenService>();
        }
    }
}
