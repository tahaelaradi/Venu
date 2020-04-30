using Microsoft.Extensions.Configuration;

namespace Venu.BuildingBlocks.Shared.Extensions
{
    public static class Extensions
    {
        public static TModel GetOptions<TModel>(this IConfiguration configuration, string section) where TModel : new()
        {
            var model = new TModel();
            configuration.GetSection(section).Bind(model);
            return model;    
        }
    }
}
