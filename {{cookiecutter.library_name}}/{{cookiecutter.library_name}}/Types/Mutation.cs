using GraphQL.Types;

namespace {{cookiecutter.library_name}}.Types
{
	public class Mutation : ObjectGraphType
	{
		public Mutation(Models.Data data)
		{
			Name = "Mutation";

			Field<Types.Base64DataType>(
				"insertBase64Data",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "name" },
					new QueryArgument<StringGraphType> { Name = "base64" }
				),
				resolve: context =>
				{
					var m = new Models.Base64Data
					{
						Name = context.GetArgument<string>("name"),
						Base64 = context.GetArgument<string>("base64")
					};
					data.Base64Data[m.Name] = m;
					return m;
				});
		}
	}
}