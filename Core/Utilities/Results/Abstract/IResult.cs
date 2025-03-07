using Core.Entities.Concrete;
using Portfolio.Core.Utilities.Results.ComplexTypes;

namespace Portfolio.Core.Utilities.Results.Abstract;

public interface IResult
{
    public ResultStatus ResultStatus { get; }
    public string Message { get; }
    public Exception Exception { get; }
    public IEnumerable<ValidationError> ValidationErrors { get; }
}