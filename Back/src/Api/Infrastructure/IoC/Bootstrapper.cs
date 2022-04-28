using Azul.Framework.Api.Ioc;
using MediatR;
using SimpleInjector;

namespace Api.Infrastructure.IoC
{
    public class Bootstrapper : BaseApiDependencyInjectionBootstrap
    {
        private const string BankAccountConnection = "BankAccount";

        public override void Inject(Container container)
        {
            base.Inject(container);
        }
    }
}
