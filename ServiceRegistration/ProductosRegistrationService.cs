using Examen.Model.DAO.Repository;
using Examen.Model.DAO.Services;
using Examen.Model.IDAO.IRepository;
using Examen.Model.IDAO.IServices;

namespace Examen.ServiceRegistration
{
    public static class ProductosRegistrationService
    {
        public static IServiceCollection ProductosService(this IServiceCollection services)
        {
            services.AddScoped<IProductosService, ProductosService>();
            services.AddScoped<IProductosRepository, ProductosRepository>();

            return services;
        }
    }
}
