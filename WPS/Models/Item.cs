using Newtonsoft.Json;
using System;

namespace WPS.Models
{
	public class Item : BaseModel
	{
		[JsonProperty("brand_id")]
		public long BrandId { get; set; }

		[JsonProperty("country_id")]
		public long CountryId { get; set; }

		[JsonProperty("product_id")]
		public long ProductId { get; set; }

		public string Sku { get; set; }

		public string Name { get; set; }

		[JsonProperty("list_price")]
		public string ListPrice { get; set; }

		[JsonProperty("standard_dealer_price")]
		public string StandardDealerPrice { get; set; }

		[JsonProperty("supplier_product_id")]
		public string SupplierProductId { get; set; }

		public long Length { get; set; }

		public long Width { get; set; }

		public long Height { get; set; }

		public long Weight { get; set; }

		public object Upc { get; set; }

		[JsonProperty("superseded_sku")]
		public object SupersededSku { get; set; }

		[JsonProperty("status_id")]
		public string StatusId { get; set; }

		public string Status { get; set; }

		[JsonProperty("has_map_policy")]
		public bool HasMapPolicy { get; set; }

		public long Sort { get; set; }

		[JsonProperty("published_at")]
		public DateTimeOffset PublishedAt { get; set; }
	}
}
