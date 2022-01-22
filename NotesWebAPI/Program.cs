using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NotesWebAPI
{
	public class Program
	{
		public const string BaseHttpUrl = "http://localhost:57199/";
		public const string BaseHttpsUrl = "https://localhost:44386/";
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					var p = Directory.GetCurrentDirectory();

                    webBuilder.UseContentRoot(p);
					webBuilder.UseStartup<Startup>();
					
				});
	}
}
