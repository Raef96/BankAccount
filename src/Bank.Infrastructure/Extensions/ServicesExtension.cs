using Bank.App.Interfaces.Services;
using Bank.App.Interfaces.Repositories;
using Bank.Infrastructure.Persistance;
using Bank.Infrastructure.ServicesImpl;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Infrastructure.Extensions;

internal static class ServicesExtension
{
    public static IServiceCollection AddBankServices(this IServiceCollection services)
    {
        return services.AddRepositories()
                       .AddServices();

    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddTransient<ITransactionRepository, TransactionRepository>();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {

        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<ITransactionService, TransactionService>();

        return services;
    }
}
