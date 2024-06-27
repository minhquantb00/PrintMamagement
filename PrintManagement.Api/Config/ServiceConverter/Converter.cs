using PrintManagement.Application.Payloads.Mappers;

namespace PrintManagement.Api.Config.ServiceConverter
{
    public static class Converter
    {
        public static void Convert(this IServiceCollection services)
        {
            services.AddScoped<ProjectConverter>();
            services.AddScoped<DesignConverter>();
            services.AddScoped<UserConverter>();
            services.AddScoped<CustomerConverter>();
            services.AddScoped<DesignConverter>();
            services.AddScoped<CustomerFeedbackConverter>();
            services.AddScoped<ResourcePropertyDetailConverter>();
            services.AddScoped<ResourcePropertyConverter>();
            services.AddScoped<TeamConverter>();
            services.AddScoped<ResourceConverter>();
            services.AddScoped<ImportCouponConverter>();
            services.AddScoped<NotificationConverter>();
            services.AddScoped<DeliveryConverter>();
            services.AddScoped<PrintJobConverter>();
            services.AddScoped<ResourceForPrintJobConverter>();
            services.AddScoped<ConfirmReceiptConverter>();
            services.AddScoped<KPIConverter>();
            services.AddScoped<ResourceTypeConverter>();
        }
    }
}
