using GraphQL.Types;

namespace {{cookiecutter.library_name}}.Types
{
	public class Base64DataType : ObjectGraphType<Models.Base64Data>
	{
		public Base64DataType()
		{
			Name = "Base64Data";
			Field(data => data.Name).Description("The name of the binary data");
			Field(data => data.Base64).Description("The base64 encoded binary data");
		}
	}
}