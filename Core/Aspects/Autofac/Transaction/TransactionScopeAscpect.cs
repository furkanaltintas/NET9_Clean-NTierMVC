using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction;

public class TransactionScopeAscpect : MethodInterception
{
    public override void Intercept(IInvocation invocation)
    {
        using (TransactionScope transactionScope = new())
        {
            try
            {
                invocation.Proceed(); // Metodu çalıştırmaya çalışır
                transactionScope.Complete(); // İşlemi kabul et ve çalıştır
            }
            catch (System.Exception ex)
            {
                transactionScope.Dispose(); // Yapılan işlemleri geri alır
                throw;
            }
        }
    }
}