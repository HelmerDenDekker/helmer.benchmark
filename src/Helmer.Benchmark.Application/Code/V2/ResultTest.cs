using Helmer.Benchmark.Application.Code.V2.Extensions;

namespace Helmer.Benchmark.Application.Code.V2;

public static class ResultTest
{
	public static Result TestCreateCommandType()
	{
		return Result.Conflict;
	}

	public static ValueResult<Guid> TestCreateQueryType()
	{
		var guid = Guid.NewGuid();
		var result = ValueResult<Guid>.Ok(guid);

		return result;
	}

	public static string TestCompareLogic()
	{
		var commandResult = TestCreateCommandType();

		var valueResult = TestCreateQueryType();

		if (commandResult == valueResult.Result)
			return "same";

		if (!valueResult.Result.IsSuccess())
			return "failure";

		if (valueResult.Result == Result.Ok)
			return "ok";

		return "success";
	}
}
