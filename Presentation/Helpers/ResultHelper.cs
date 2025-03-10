using Portfolio.Core.Utilities.Results.ComplexTypes;
using IResult = Portfolio.Core.Utilities.Results.Abstract.IResult;

namespace Presentation.Helpers;

public static class ResultHelper
{
    public static bool IsSuccess(IResult result) => result.ResultStatus == ResultStatus.Success;
    public static bool IsSuccess(ResultStatus resultStatus) => resultStatus == ResultStatus.Success;
}
