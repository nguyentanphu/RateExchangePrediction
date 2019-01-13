using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
			services.AddScoped<IOpenExchangeCache, OpenExchangeCache>();
			services.AddScoped<HttpClient, HttpClient>();
		    services.AddSingleton<OpenExchangeCache, OpenExchangeCache>();
			services.AddScoped<Form1, Form1>();
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
