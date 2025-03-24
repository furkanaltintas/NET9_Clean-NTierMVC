using Core.Helpers.Validators.Abstract;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Helpers.Validators.Concrete;

public class ValidatorGetFactory : IValidatorGetFactory
{
    private readonly IServiceProvider _serviceProvider;
    public ValidatorGetFactory(IServiceProvider serviceProvider) { _serviceProvider = serviceProvider; }
    public IValidator<T> GetValidator<T>() => _serviceProvider.GetRequiredService<IValidator<T>>();
}