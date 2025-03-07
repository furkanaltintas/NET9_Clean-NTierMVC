using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        // Metot çalışmadan önce çalışacak
        protected virtual void OnBefore(IInvocation invocation) { }


        // Metot çalıştıktan sonra çalışacak
        protected virtual void OnAfter(IInvocation invocation) { }


        // Metot hata verdiğinde çalışacak
        protected virtual void OnException(IInvocation invocation, Exception e) { }


        // Metot başarılı ise çalışacak
        protected virtual void OnSuccess(IInvocation invocation) { }


        public override void Intercept(IInvocation invocation)
        {
            bool isSuccess = true;

            OnBefore(invocation);

            try
            {
                invocation.Proceed(); // Operasyonu çalıştıracak
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }

            OnAfter(invocation);
        }
    }
}