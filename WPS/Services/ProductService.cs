using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WPS.Models;

namespace WPS
{
	public interface IProductervice
	{
		Task<List<Product>> List();
		Task<Product> GetById(long id);
		Task<int> Count();
	}
	public class ProductService : IProductervice
	{
		private readonly string URL = "products";
		private HttpClient _Client;

		public ProductService(HttpClient client)
		{
			_Client = client;
		}

		public async Task<List<Product>> List() => await _Client.GetResultPaginateAsync<Product>(URL);

		public async Task<Product> GetById(long id) => (await _Client.GetResultAsync<RootObject<Product>>($"{URL}/{id}")).Data ?? null;

		public async Task<int> Count() => await _Client.GetResultAsync<int>($"{URL}?countOnly=true");
	}
}
