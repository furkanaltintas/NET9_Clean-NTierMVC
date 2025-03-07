using Core.Entities.Concrete;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;

namespace Portfolio.Core.Utilities.Results.Concrete;

public class Result : IResult
{
    public Result(
        ResultStatus resultStatus,
        string message = null,
        Exception exception = null,
        IEnumerable<ValidationError> validationErrors = null)
    {
        ResultStatus = resultStatus;
        Message = message;
        Exception = exception;
        ValidationErrors = validationErrors;
    }

    public ResultStatus ResultStatus { get; }
    public string Message { get; }
    public Exception Exception { get; }
    public IEnumerable<ValidationError> ValidationErrors { get; }
}