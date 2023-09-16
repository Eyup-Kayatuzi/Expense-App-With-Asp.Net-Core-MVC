using MasrafUygulamasi.Application.Interfaces;
using MasrafUygulamasi.Application.Interfaces.IServices;
using MasrafUygulamasi.Application.Interfaces.Repositories.CurrencyRepo;
using MasrafUygulamasi.Application.Interfaces.Repositories.ExpenseItemRepo;
using MasrafUygulamasi.Application.Interfaces.Repositories.ExpenseRepo;
using MasrafUygulamasi.Application.Interfaces.Repositories.ExpenseTpyeRepo;
using MasrafUygulamasi.Application.Interfaces.Repositories.StateRepo;
using MasrafUygulamasi.Application.Interfaces.Repositories.UserRepo;
using MasrafUygulamasi.Persistence.Concretes;
using MasrafUygulamasi.Persistence.Context;
using MasrafUygulamasi.Persistence.Repositories;
using MasrafUygulamasi.Persistence.Repositories.CurrencyRepo;
using MasrafUygulamasi.Persistence.Repositories.ExpenseItemRepo;
using MasrafUygulamasi.Persistence.Repositories.ExpenseRepo;
using MasrafUygulamasi.Persistence.Repositories.ExpenseTypeRepo;
using MasrafUygulamasi.Persistence.Repositories.StateRepo;
using MasrafUygulamasi.Persistence.Repositories.UserRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MasrafUygulamasi.Persistence
{
    public static class ServicesRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            services.AddScoped<ICurrencyReadRepository, CurrencyReadRepository>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IExpenseTypeReadRepository, ExpenseTypeReadRepository>();
            services.AddScoped<IExpenseTypeService, ExpenseTypeService>();
            services.AddScoped<IStateReadRepository, StateReadRepository>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<IExpenseReadRepository, ExpenseReadRepository>();
            services.AddScoped<IExpenseWriteRepository, ExpenseWriteRepository>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IExpenseItemReadRepository, ExpenseItemReadRepository>();
            services.AddScoped<IExpenseItemWriteRepository, ExpenseItemWriteRepository>();
            services.AddScoped<IExpenseItemService, ExpenseItemService>();

            try
            {
                services.AddDbContext<MasrafUygulamasiDB>(options => options.UseSqlServer(Settings.ConnString));
            }
            catch (Exception)
            {

            }
            
        }
    }
}
