using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SMS.Grades.Domain.Models;

namespace SMS.Grades.Repository.Context;

public class ApplicationDbContext : DbContext
{
    private DbSet<Grade> Grades;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}