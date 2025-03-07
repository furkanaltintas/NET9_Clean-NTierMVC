using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Core.Utilities.Business;

public class BusinessRules
{
    // İş Kurallarını Çalıştır

    public static Result Run(params IResult[] logics)
    {
        var resultError = ResultError(logics);
        return resultError.Item1 ? new Result(ResultStatus.Error, resultError.Item2) : null;
    }

    public static DataResult<T> Run<T>(params IResult[] logics)
    {
        var resultError = ResultError(logics);
        return resultError.Item1 ? new DataResult<T>(ResultStatus.Error, resultError.Item2) : null;
    }

    private static (bool, string) ResultError(params IResult[] logics)
    {
        var errorResults = logics.Where(x => x.ResultStatus != ResultStatus.Success).ToList(); // IsSuccess değeri false olanları getirdi
        var hasError = errorResults.Any(); // errorResult değeri var mı kontrol edildi var ise hasError true oldu
        var messages = string.Join("\n", errorResults.Select(x => x.Message)); // Join ile birleştirme yapılarak aralara \n ifadesi konuldu
        return (hasError, messages);
    }
}
