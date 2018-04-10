﻿using DNIC.Erechtheion.Core.Configuration;
using DNIC.Erechtheion.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNIC.Erechtheion.EntityFrameworkCore
{
	public class RepositorySeedData : IRepositorySeedData
	{
		public void EnsureSeedData(IServiceProvider serviceProvider)
		{
			Console.WriteLine("Seeding database...");
			var configuration = serviceProvider.GetRequiredService<IErechtheionConfiguration>();

			using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				if ((configuration.AuthenticationMode & AuthenticationMode.Self) == AuthenticationMode.Self)
				{
					using (var context = scope.ServiceProvider.GetRequiredService<ErechtheionIdentityDbContext>())
					{
						context.Database.Migrate();
					}
				}

				using (var context = scope.ServiceProvider.GetRequiredService<ErechtheionDbContext>())
				{
					context.Database.Migrate();
					if (!context.Topic.Any())
					{
						context.Topic.Add(new Domain.Entities.Topic
						{
							Name = "topic1"
						});
						context.Topic.Add(new Domain.Entities.Topic
						{
							Name = "topic2"
						});
						context.SaveChanges();
					}
				}
			}

			Console.WriteLine("Done seeding database.");
			Console.WriteLine();
		}
	}
}