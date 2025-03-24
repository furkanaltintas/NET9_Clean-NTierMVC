using Business.Constants;
using Business.Modules.Blogs.Constants;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;
using System.Linq.Expressions;

namespace Business.Modules.Blogs.Rules;

public class BlogBusinessRules(IRepository repository) : BaseBusinessRules
{
    public async Task<IResult> BlogNotExist(Expression<Func<Blog, bool>> expression)
    {
        //Blog? blog = await repository.GetRepository<Blog>().GetAsync(predicate: expression);

        //if (blog == null) return new Result(ResultStatus.Error, Messages.InvalidValue(BlogsMessages.Blog));
        //return new Result(ResultStatus.Success);

        return await repository.GetRepository<Blog>().GetAsync(predicate: expression) is not null
            ? new Result(ResultStatus.Success)
            : new Result(ResultStatus.Error, Messages.InvalidValue(BlogsMessages.Blog));
    }

    public async Task<IDataResult<TEntity>> BlogNotExist<TEntity>(Expression<Func<Blog, bool>> expression)
    {
        //Blog? blog = await repository.GetRepository<Blog>().GetAsync(predicate: expression);

        //if (blog == null) return new DataResult<TEntity>(ResultStatus.Error, Messages.InvalidValue(BlogsMessages.Blog));
        //return new DataResult<TEntity>(ResultStatus.Success);

        return await repository.GetRepository<Blog>().GetAsync(predicate: expression) is not null
            ? new DataResult<TEntity>(ResultStatus.Success)
            : new DataResult<TEntity>(ResultStatus.Error, Messages.InvalidValue(BlogsMessages.Blog));
    }
}