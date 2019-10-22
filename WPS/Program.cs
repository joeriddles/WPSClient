using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using WPS.Models;
using WPS.Services;

namespace WPS
{
	class Program
	{
		static async Task Main()
		{
			/*var serviceProvider = new ServiceCollection()
				.AddSingleton<IProductService, ProductService>()
				.AddSingleton<IItemService, ItemService>()
				.BuildServiceProvider();
			IProductService productService = serviceProvider.GetService<IProductService>();*/

			using (var client = WpsClient.CreateClient(GetToken()))
			{
				var productService = BaseService<Item>.ProductService(client);

				var product = await productService.GetById(163);
				Console.WriteLine(product);

				// var products = await productService.List();
			}
		}

		static string GetToken()
		{
			string configPath = "../../../config.json";
			if (File.Exists(configPath))
			{
				var text = File.ReadAllText(configPath);
				var config = JsonConvert.DeserializeObject<Config>(text);
				return config.Token;
			}
			else
			{
				Console.WriteLine("Enter your WPS token: ");
				string token = Console.ReadLine();
				File.WriteAllText(configPath, JsonConvert.SerializeObject(new Config { Token = token }));
				return token;
			}
		}
	}
}
