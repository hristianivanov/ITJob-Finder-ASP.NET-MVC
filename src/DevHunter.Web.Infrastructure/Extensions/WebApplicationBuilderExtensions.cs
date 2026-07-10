namespace DevHunter.Web.Infrastructure.Extensions
{
    using System.Linq;
    using System.Reflection;

    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Common;
    using Middlewares;

    public static class WebApplicationBuilderExtensions
    {
        /// <summary>
        /// This method registers all services with their interfaces and implementations of given assembly.
        /// The assembly is taken from the type of any service implementation provided.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, Type serviceType, IConfiguration configuration)
        {
            ConfigureCloudinaryService(services, configuration);

            ConfigureEmailService(services, configuration);

            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provided!");
            }

            Type[] serviceTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();

            foreach (Type implementationType in serviceTypes)
            {
                Type? interfaceType = implementationType.GetInterface($"I{implementationType.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No interface is provided for the service with name: {implementationType.Name}");
                }

                services.AddScoped(interfaceType, implementationType);
            }

            return services;
        }

        public static IApplicationBuilder EnableOnlineUsersCheck(this IApplicationBuilder app) 
            => app.UseMiddleware<OnlineUsersMiddleware>();


        private static void ConfigureEmailService(IServiceCollection services, IConfiguration configuration)
        {
            var emailConfig = configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfig>();

            if (emailConfig == null)
            {
                throw new InvalidOperationException("Email configuration is missing.");
            }

            services.AddSingleton(emailConfig);
        }

        private static void ConfigureCloudinaryService(IServiceCollection services, IConfiguration configuration)
        {
            var cloudName = configuration.GetValue<string>("AccountSettings:CloudName");
            var apiKey = configuration.GetValue<string>("AccountSettings:ApiKey");
            var apiSecret = configuration.GetValue<string>("AccountSettings:ApiSecret");

            if (string.IsNullOrWhiteSpace(cloudName)
                || string.IsNullOrWhiteSpace(apiKey)
                || string.IsNullOrWhiteSpace(apiSecret))
            {
                throw new ArgumentException("Please specify your Cloudinary account Information");
            }

            services.AddSingleton(new Cloudinary(new Account(cloudName, apiKey, apiSecret)));
        }
    }
}
