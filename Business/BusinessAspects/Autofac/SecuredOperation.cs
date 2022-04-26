using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;
using Business.Constants;
using Microsoft.AspNetCore.Http;
using Core.Extensions;

namespace Business.BusinessAspects.Autofac
{
    //SecuredOperation JWT için
    //Authorization aspect'leri business katmanına yazılır.
    //Çünkü her projenin yetkilendirme algoritması değişebilir.
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        //HttpContextAccessor bir istek yapılıyor ve yapılan her istek için bir HttpContext oluşur

        public SecuredOperation(string roles)
        {
            //roles.Split(','); demek metni , ile ayırıp bir array[]'e atıyor. 
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            //ServiceTool injection altyapımızı okumaya yarayan bir araç olacak.

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            //o anki kullanıcının claim rollerine bak 
            foreach (var role in _roles)
            {
                //Bu kullanıcının rollerini gez ve eğer kullanıcının rolleri arasında ilgili rol varsa metodu çalıştırmaya devam eder.
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
            //Yoksa hata fırlatır(Yetkiniz yok).
        }
    }
}
