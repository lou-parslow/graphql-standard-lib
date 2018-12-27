using System.Collections.Generic;

namespace {{cookiecutter.library_name}}.Models
{
	public class Data
	{
		public Dictionary<string, Base64Data> Base64Data { get; } = new Dictionary<string, Base64Data>();
	}
}