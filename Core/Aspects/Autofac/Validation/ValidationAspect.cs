using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation;

public class ValidationAspect : MethodInterception
{
    Type _validatorType;
    public ValidationAspect(Type validatorType)
    {
        // Gönderilen validatorType, bir IValidator türünde değilse
        if (!typeof(IValidator).IsAssignableFrom(validatorType))
        {
            throw new System.Exception(AspectMessages.WrongValidationType);
        }

        _validatorType = validatorType;
    }

    protected override void OnBefore(IInvocation invocation)
    {
        var validator = Activator.CreateInstance(_validatorType) as IValidator; // Bir tane IValidator instantiation oluşturuyor.
        // _validatorType değişkeninin belirttiği türden yeni bir nesne oluşturur.

        var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // Çıktı: Product
        // _validatorType => ProductValidator onun BaseType'ı AbstractValidator. Arguments olarak ilk olanı seçiyoruz zaten 1 tane kullandık.
        // _validatorType.BaseType => _validatorType tarafından temsil edilen türün üst sınıfını alır. Bu _validatorType türünün miras aldığı veya türediği sınıfı temsil eder.
        // GetGenericArguments() => Bir türün generic argümanlarını (tip parametrelerini) döndürür. Örneğin, bir sınıf 'List<string>' ise, generic argüman 'string' olur.
        // [0] => Bu ifade, generic argümanların dizisinden ilk öğeyi seçer. Bu, '_validatorType' tarafından temsil edilen türün ilk generic argümanını alır.
        // ProductValidator : AbstractValidator<Product>

        var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // Git methodun argümanlarına bak.
        foreach (var entity in entities)
        {
            ValidationTool.Validate(validator, entity);
        }
    }
}