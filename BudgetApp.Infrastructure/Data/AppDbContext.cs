using BudgetApp.Domain.Entities; //Hämta in allt som finns i Enities mappen i Domain projektet. 
using Microsoft.EntityFrameworkCore; // Hämtar in alla klasser DbContext och Dbset från EF Core biblioteket.

//DbContext hanterar all kommunikation med databasen. Och min AppDbContext ärver från DbContext klassen i EF Core.
//Dbset är EF Copres klass som representerar en tabell i databasen. Varje Dbset i AppDbContext representerar en tabell i databasen som kommer att skapas baserat på mina entiteter (Budget, Category, Transactions).

namespace BudgetApp.Infrastructure.Data //talar om var i projektet den här klassen bor
{
    public class AppDbContext : DbContext //Min AppDbContext klass ärver från DbContext klassen i EF Core. För att den hanterar all kommunikation med databasen
    {
        //Konstruktor - en metoden som körs när en instans av klassen skapas. Den tar emot DbContextOptions som innehåller konfigurationen för databaskopplingen och skickar den vidare till bas-klassen (DbContext) genom att använda base(options).
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Varje DbSet representerar en tabell i databasen. 
        //EF tittar på dina entiteter och skapar tabellerna automatiskt utifrån dem när du kör en migration.
        //Migration betyder att det är EF Core sätt att översätta mina Csharp klasser till databastabeller
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Amount).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(200);
            });
        }
    }
}