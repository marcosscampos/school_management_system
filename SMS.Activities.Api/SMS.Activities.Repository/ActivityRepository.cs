using SMS.Activities.Domain.Abstractions.Repositories;
using SMS.Activities.Domain.Models;
using SMS.Activities.Repository.Context;

namespace SMS.Activities.Repository;

public class ActivityRepository : BaseRepository<Activity>, IActivityRepository
{
    public ActivityRepository(ApplicationDbContext context) : base(context)
    {
    }
}