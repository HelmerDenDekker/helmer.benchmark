using System.Net;
using Helmer.Benchmark.Application.Code.V1.Extensions;

namespace Helmer.Benchmark.Application.Code.V1;

public static class ResultTest
{
	public static Result TestCreateCommandType()
	{
		return Result.Conflict;
	}

	public static Result<Guid> TestCreateQueryType()
	{
		var guid = Guid.NewGuid();
		var result = Result.Ok.DownCast(guid);

		return result;
	}

	public static string TestCompareLogic()
	{
		var commandResult = TestCreateCommandType();

		var valueResult = TestCreateQueryType();

		if (commandResult.StatusCode == valueResult.StatusCode)
			return "same";

		var result = TestCreateQueryType();

		if (!result.IsSuccess)
			return "failure";

		if (result.StatusCode == HttpStatusCode.OK)
			return "ok";

		return "success";
	}
}