using Newtonsoft.Json;
using System;

public class Product
{
	public long Id { get; set; }

	[JsonProperty(PropertyName = "designation_id")]
	public long? DesignationId { get; set; }

	public string Name { get; set; }

	[JsonProperty(PropertyName = "alternate_name")]
	public string AlternateName { get; set; }

	[JsonProperty(PropertyName = "care_instruction")]
	public string CareInstructions { get; set; }

	public string Description { get; set; }

	public long Sort { get; set; }

	[JsonProperty(PropertyName = "image_360_id")]
	public long? Image360Id { get; set; }

	[JsonProperty(PropertyName = "image_360_preview_id")]
	public long? Image360PreviewId { get; set; }

	[JsonProperty(PropertyName = "size_chart_id")]
	public long? SizeChartId { get; set; }

	[JsonProperty(PropertyName ="created_at")]
	public DateTimeOffset CreatedAt { get; set; }

	[JsonProperty(PropertyName ="updated_at")]
	public DateTimeOffset UpdatedAt { get; set; }

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this, Formatting.Indented);
	}
}