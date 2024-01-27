using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewMovieData.Model.Contracts;
using ViewMovieData.ViewModel.Repositories;

namespace ViewMovieData.View.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            
            services.AddScoped<IMovieRepository,MovieRepository>();

            return services;
        }
    }
}
