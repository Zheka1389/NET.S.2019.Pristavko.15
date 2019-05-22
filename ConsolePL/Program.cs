using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePL
{
    public class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigureResolver();
        }

        public static void Main(string[] args)
        {
            IBankAccountService accountService = Resolver.Get<IBankAccountService>();

            accountService.Open("Petrov1", "Stiv1", 200, GradingType.Gold);
            accountService.Open("Petrov2", "Stiv2", 230, GradingType.Platinum);
            accountService.Open("Petrov3", "Stiv3", 250, GradingType.Platinum);
            accountService.Open("Petrov4", "Stiv4", 300, GradingType.Base);
            accountService.Open("Petrov5", "Stiv5", 350, GradingType.Base);

            Display(accountService);
            Console.ReadLine();
            foreach (var account in accountService.GetAll())
            {
                accountService.Refill(account.Id, 5);
            }

            Display(accountService);
            Console.ReadLine();
            foreach (var account in accountService.GetAll())
            {
                accountService.Withdrawal(account.Id, 5);
            }

            Display(accountService);

            Console.ReadLine();
        }

        private static void Display(IBankAccountService accountService)
        {
            foreach (var account in accountService.GetAll())
            {
                Console.WriteLine(account);
            }
        }
        
    }
}
