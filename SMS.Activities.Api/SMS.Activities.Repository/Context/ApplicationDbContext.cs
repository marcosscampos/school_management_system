using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SMS.Activities.Domain.Models;

namespace SMS.Activities.Repository.Context;

public class ApplicationDbContext : DbContext
{
    private DbSet<Activity> Activities;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}