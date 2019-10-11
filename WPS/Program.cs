using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using WPS.Models;

namespace WPS
{
	class Program
	{
		static async Task Main()
		{
			using (var client = WpsClient.CreateClient(getToken()))
			{
				IProductervice productService = new ProductService(client);
				var product = await productService.GetById(1);
				Console.WriteLine(product);

				// var products = await productService.List();

				File.WriteAllText("../../../config.json", "test");
			}
		}

		static string getToken()
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
