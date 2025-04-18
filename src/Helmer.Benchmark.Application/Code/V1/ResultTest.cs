using Helmer.Benchmark.Application.Code.V1.Extensions;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helmer.Benchmark.Application.Code.V1
{
    public static class ResultTest
    {
        public static Result TestCreateCommandType()
        {
            return Result.Conflict;
        }

        public static Result<Guid> TestCreateQueryType() 
        { 
            var guid = Guid.NewGuid();
            var result = Result.Ok.DownCast<Guid>(guid);
        
            return result;
        }

        public static string TestCompareLogic()
        {
            var cmndResult = TestCreateCommandType();

            var valueResult = TestCreateQueryType();

            if (cmndResult.StatusCode == valueResult.StatusCode)
            {
                return "same";
            }

            var result = TestCreateQueryType();

            if (!result.IsSuccess)
                return "failure";


            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return "ok";

            return "succes";
        }
    }
}
