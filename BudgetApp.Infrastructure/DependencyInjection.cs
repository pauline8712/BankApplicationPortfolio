using BudgetApp.Infrastructure.Data; //Hämtar in AppDbContext som finns i Data-mappen.
using Microsoft.EntityFrameworkCore; //Hämtar in UseSqlServer som talar om att jag använder SQL Server som databas
using Microsoft.Extensions.Configuration; //Hämtar in IConfiguration som används för att hämta connection string från appsettings.json
using Microsoft.Extensions.DependencyInjection; //Hämtar in IServiceCollection som används för att registrera tjänster i Dependency Injection container.

namespace BudgetApp.Infrastructure
{
    //Har med Dependency Injection så att .NET vet vad som finns registrerat i Infrastrukturen. 
    //Då vet .NET att varje gång man behöver AppDbContext så ska den skapa och leverera en automatiskt. 
    public static class DependencyInjection //behöver inte skapa ett objekt av klassen
    {
        public static IServiceCollection AddInfrastructure( //Själva listan av allt som registrerades i DI
            this IServiceCollection services,
            IConfiguration configuration) //Läser allt som står i appsettings.json. 
        {

            //Registrerar AppDbContext som tjänst i DI-systemet
            //UseSqlServer talar om att det är Sql server som används. 
            //hämtar databas-adressen från appsettings.json
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
} //Nu när t.ex. ett repository säger "jag behöver en AppDbContext" i sin konstruktor –
  //slår DI upp i registret, hittar den och levererar den automatiskt.
  //Bra att veta är att all databaskommunikation samlas på ett ställe med repository. 
  //För att det är en brygga mellan application och databas. 

