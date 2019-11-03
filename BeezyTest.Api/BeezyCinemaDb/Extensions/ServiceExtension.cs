using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using BeezyTest.DomainServices;
using BeezyTest.BeezyCinemaDb.Models;

namespace BeezyTest.BeezyCinemaDb.Extensions
{
	public static class ServiceExtension
	{
		public static IServiceCollection AddBeezyCinemaServices(this IServiceCollection services, Action<DbContextOptionsBuilder> dbOptions)
		{

			services
				.AddDbContext<BeezyCinemaContext>(dbOptions)
				.AddScoped(typeof(IBoxOfficeService), typeof(BeezyCinemaClient));
			return services; 
		}
	}
}
