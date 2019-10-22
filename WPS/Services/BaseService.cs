using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WPS.Models;

namespace WPS.Services
{
	public interface IBaseService<T>
	{
		Task<List<T>> List();
		Task<T> GetById(long id);
		Task<int> Count();
	}

	public class BaseService<T> : IBaseService<T>
	{
		private readonly HttpClient _Client;
		private readonly string _URL;

		public static BaseService<Item> ItemService(HttpClient client) => new BaseService<Item>(client, "items");

		public static BaseService<Item> ProductService(HttpClient client) => new BaseService<Item>(client, "items");

		public BaseService(HttpClient client, string url)
		{
			_Client = client;
			_URL = url;
		}

		public async Task<List<T>> List() => await _Client.GetResultPaginateAsync<T>(_URL);

		public async Task<T> GetById(long id) => (await _Client.GetResultAsync<RootObject<T>>($"{_URL}/{id}")).Data;

		public async Task<int> Count() => await _Client.GetResultAsync<int>($"{_URL}?countOnly=true");
	}
}
