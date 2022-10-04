using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SMS.Submissions.Domain.Models;

namespace SMS.Submissions.Repository.Context;

public class ApplicationDbContext : DbContext
{
    private DbSet<Submission> Submissions;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}