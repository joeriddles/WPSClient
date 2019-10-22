using System.Collections.Generic;

namespace WPS.Models
{
	public class RootObjects<BaseModel>
	{
		public List<BaseModel> Data;
		public Meta Meta;
	}
}
