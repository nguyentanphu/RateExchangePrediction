using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExchangeRatePrediction.Application;
using ExchangeRatePrediction.Application.Contract;
using ExchangeRatePrediction.Application.Data;
using ExchangeRatePrediction.Application.OpenExchangeRates;
using Microsoft.Extensions.DependencyInjection;

namespace RateExchangePrediction.Presentation
{
	static class Program
	{
		private static IServiceProvider ServiceProvider { get; set; }

		private static void ConfigureServices()
		{
			var services = new ServiceCollection();
			services.AddScoped<IPredictionService, PredictionService>();
			services.AddScoped<IOpenExchangeClient, OpenExchangeRatesClient>();
			services.AddSingleton<IOpenExchangeCache, OpenExchangeCache>();
			services.AddScoped<HttpClient, HttpClient>();
			services.AddScoped<Form1, Form1>();

		    ThreadPool.GetMaxThreads(out _, out var maxIOThreadCount);
		    int maxIOThreadForApp = maxIOThreadCount / 2;

		    services.AddScoped(provider => new SemaphoreSlim(maxIOThreadForApp));
			ServiceProvider = services.BuildServiceProvider();
		}
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			ConfigureServices();
			Application.Run(ServiceProvider.GetService<Form1>());
		}
	}
}
