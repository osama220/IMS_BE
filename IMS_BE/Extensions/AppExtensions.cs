
using Swashbuckle.AspNetCore.SwaggerUI;

namespace IMS_BE.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocExpansion(DocExpansion.None);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IMS_BE");
                c.DocumentTitle = "IMS WebApi";
                //c.RoutePrefix = string.Empty;
            });
        }

    }
}
