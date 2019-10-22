using Newtonsoft.Json;

namespace WPS.Models
{
	public class Product : BaseModel
	{
		[JsonProperty("designation_id")]
		public long? DesignationId { get; set; }

		public string Name { get; set; }

		[JsonProperty("alternate_name")]
		public string AlternateName { get; set; }

		[JsonProperty("care_instruction")]
		public string CareInstructions { get; set; }

		public string Description { get; set; }

		public long Sort { get; set; }

		[JsonProperty("image_360_id")]
		public long? Image360Id { get; set; }

		[JsonProperty("image_360_preview_id")]
		public long? Image360PreviewId { get; set; }

		[JsonProperty("size_chart_id")]
		public long? SizeChartId { get; set; }
	}
}
