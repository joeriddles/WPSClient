using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WPS.Models;

namespace WPS
{
	public static class WpsClient
	{
		public static HttpClient CreateClient(string token)
		{
			HttpClient client = new HttpClient
			{
				BaseAddress = new Uri("http://api.wps-inc.com/")
			};
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			return client;
		}

		public static async Task<TResult> GetResultAsync<TResult>(this HttpClient client, string url)
		{
			HttpResponseMessage httpResponse = await client.GetAsync(url);
			if (httpResponse.IsSuccessStatusCode)
			{
				var result = await httpResponse.Content.ReadAsAsync<TResult>();
				return result;
			}
			else
			{
				Console.WriteLine($"{client.BaseAddress}{url} returned status code {httpResponse.StatusCode}.", httpResponse);
				return default;
			}
		}

		public static async Task<List<TResult>> GetResultPaginateAsync<TResult>(this HttpClient client, string url)
		{
			var results = new List<TResult>();
			var pageSizeUrl = $"{url}?page[size]=500";

			var response = await client.GetResultAsync<RootObjects<TResult>>(pageSizeUrl);
			if (response != null)
				results.AddRange(response.Data);

			while (response?.Meta?.Cursor?.Next != null)
			{
				Console.WriteLine(response.Meta.Cursor.Next);
				response = await client.GetResultAsync<RootObjects<TResult>>($"{pageSizeUrl}&page[cursor]={response.Meta.Cursor.Next}");
				results.AddRange(response.Data);
			}

			return results;
		}
	}
}
