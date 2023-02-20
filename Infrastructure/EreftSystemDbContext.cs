using Core.Entities;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;

namespace Infrastructure
{
    public class EreftSystemDbContext : DbContext, IEntitiesContext
    {
        protected readonly IConfiguration Configuration;

    public EreftSystemDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        // options.UseInMemoryDatabase("TestDb");

        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<Core.Entities.Category> Category { get; set; }
    public DbSet<Group> Group { get; set; }
    public DbSet<MenuItem> MenuItem { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<OrderStatus> OrderStatus { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderMenuItem> OrderMenuItem { get; set; }


     private DbTransaction _transaction;

    public void BeginTransaction()
    {
        if (this.Database.GetDbConnection().State == ConnectionState.Open)
        {
            return;
        }
        this.Database.GetDbConnection().Open();
        _transaction = this.Database.GetDbConnection().BeginTransaction();
    }

    public int Commit()
    {
        var saveChanges = SaveChanges();
        _transaction.Commit();
        return saveChanges;
    }

    public Task<int> CommitAsync()
    {
        var saveChangesAsync = SaveChangesAsync();
        _transaction.Commit();
        return saveChangesAsync;
    }

    public override void Dispose()
    {
        base.Dispose();
    }

    public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
    {
        throw new NotImplementedException();
    }

    public void Rollback()
    {
        _transaction.Rollback();
    }

    public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        => base.Set<TEntity>();

    public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters) where TElement : class
        => base.Set<TElement>().FromSqlRaw(sql, parameters).AsEnumerable();






}
}
