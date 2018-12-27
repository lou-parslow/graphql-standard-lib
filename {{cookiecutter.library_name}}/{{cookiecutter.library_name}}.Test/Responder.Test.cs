using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace {{cookiecutter.library_name}}
{
	[TestFixture]
	public class ResponderTest
	{
		[Test]
		[TestCase("badQuery")]
		public static void Query(string test_name)
		{
			// Request
			var request = GetQueryRequest(test_name);
			Assert.NotNull(request, $"request {test_name}");

			// Expected Response
			var expected_response = GetQueryResponse(test_name);
			Assert.NotNull(request, $"expected response {test_name}");

			var filename = $"{Path.GetTempPath()}\\test.db".Replace("\\\\", "\\");
			if (File.Exists(filename)) File.Delete(filename);

			var response = new Responder().Respond(request);
			Assert.AreEqual(expected_response, response, $"response {test_name}");
		}

		[Test]
		public static void Base64Data()
		{
			var responder = new Responder();
			var response = responder.Respond(GetQueryRequest("base64DataCount_0"));
			var expected_response = GetQueryResponse("base64DataCount_0");
			Assert.AreEqual(expected_response, response, "response base64DataCount_0");
			var base64_fragment = "iVBORw0KGgoAAAANSUhEUg";

			response = responder.Respond(GetMutationRequest("insertBase64Data"));
			Assert.True(response.Contains("graphql.png"));
			Assert.True(response.Contains(base64_fragment));

			response = responder.Respond(GetQueryRequest("base64Data"));
			Assert.True(response.Contains("graphql.png"));
			Assert.True(response.Contains(base64_fragment));
		}

		public static string GetQueryRequest(string test_name)
		{
			return new StreamReader(
				typeof(ResponderTest).Assembly
				.GetManifestResourceStream(
				$"{{cookiecutter.library_name}}.Test.Queries.{test_name}.graphql"))
				.ReadToEnd();
		}

		public static string GetQueryResponse(string test_name)
		{
			return new StreamReader(
				typeof(ResponderTest).Assembly
				.GetManifestResourceStream(
				$"{{cookiecutter.library_name}}.Test.Queries.{test_name}.json"))
				.ReadToEnd();
		}

		public static string GetMutationRequest(string test_name)
		{
			return new StreamReader(
				typeof(ResponderTest).Assembly
				.GetManifestResourceStream(
				$"{{cookiecutter.library_name}}.Test.Mutations.{test_name}.graphql"))
				.ReadToEnd();
		}

		public static string GetMutationResponse(string test_name)
		{
			return new StreamReader(
				typeof(ResponderTest).Assembly
				.GetManifestResourceStream(
				$"{{cookiecutter.library_name}}.Test.Mutations.{test_name}.json"))
				.ReadToEnd();
		}
	}
}