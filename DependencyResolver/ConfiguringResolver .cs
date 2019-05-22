namespace DependencyResolver
{
    using BLL.Interface.Interfaces;
    using BLL.ServiceImplementation;
    using DAL.EF.Repositories;
    using DAL.Interface.Interfaces;
    using Ninject;

    public static class ConfiguringResolver
    {
        public static void ConfigureResolver(this IKernel kernel)
        {
            kernel.Bind<IRepository>().To<AccountsDbStorage>();
            kernel.Bind<IBankAccountService>().To<BankAccountService>();
            kernel.Bind<IBonusCounter>().To<BonusCounter>();
            kernel.Bind<IGenerator>().To<Generator>();
        }
    }
}
