using BeezyTest.DomainServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using BeezyTest.TmdbServices.Config;
using BeezyTest.TmdbServices.DataProviders;
using BeezyTest.TmdbServices.DataProviders.Cache;
using BeezyTest.TmdbServices.Services;

namespace BeezyTest.TmdbServices.Extensions
{
	public static class ServiceExtension
	{
		public static IServiceCollection AddTmdbServices(this IServiceCollection services, Action<TmdbConfigBuilder> configBuilder)
		{
			services
				.AddSingleton<TmdbConfig>((context) =>
				{
					var builderInstance = new TmdbConfigBuilder();
					configBuilder.Invoke(builderInstance);
					return builderInstance.Config;
				})
				.AddSingleton(typeof(ITmdbClient), typeof(TmdbClient))
				.AddScoped(typeof(IMovieSearchService), typeof(TmdbMovieSearchService))
				.AddAllOfType(typeof(IIdNamePair), new[] { typeof(ServiceExtension).Assembly })
				.AddTransient(typeof(SimpleCache<>))
				.AddTransient<GenreProvider>()
				.AddTransient<KeywordProvider>()
				.AddTransient<MovieProvider>();
			return services;
		}
		public static IServiceCollection AddAllOfType(this IServiceCollection services, Type interfaceType, Assembly[] assemblies, ServiceLifetime lifetime = ServiceLifetime.Transient)
		{
			var implementations = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(interfaceType)));
			foreach (var type in implementations)
			{
				services.Add(new ServiceDescriptor(interfaceType, type, lifetime));
			}
			return services;
		}
	}
}
