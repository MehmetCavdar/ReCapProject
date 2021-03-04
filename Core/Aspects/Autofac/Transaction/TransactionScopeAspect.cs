using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)  // invaocation buraya göerilen metot demektir. O metot yerine bu metot çalışır
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();  // Sorun çıkmazsa ilerler
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose();  // sorun çıkarsa iptal olur
                    throw;
                }
            }
        }
    }
}
