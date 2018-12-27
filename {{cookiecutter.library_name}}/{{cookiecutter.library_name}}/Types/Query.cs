using GraphQL.Types;

namespace {{cookiecutter.library_name}}.Types
{
	public class Query : ObjectGraphType<Models.Data>
	{
		public Query(Models.Data data)
		{
			_data = data;

			Name = "Query";
			Field<StringGraphType>("name", resolve: context => "Driver.Project");
			Field<IntGraphType>("base64DataCount", resolve: context => _data.Base64Data.Count);
			Field<Types.Base64DataType>("base64Data",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" }),
				resolve: context =>
				{
					var name = context.GetArgument<string>("name");
					if (_data.Base64Data.ContainsKey(name)) return _data.Base64Data[name];
					return null;
				});
		}

		private readonly Models.Data _data;
	}
}