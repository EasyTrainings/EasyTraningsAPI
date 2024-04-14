namespace EasyTraningsAPI.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddCustomCorsPolicy(this IServiceCollection services, string policyName = "DefaultCorsPolicy")
    {
        services.AddCors(options =>
        {
            options.AddPolicy(policyName, builder =>
            {
                builder.WithOrigins("http://localhost:5274") 
                    .AllowAnyMethod() 
                    .AllowAnyHeader() 
                    .AllowCredentials(); 
            });
        });

        return services;
    }
}