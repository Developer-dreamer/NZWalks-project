using NewZealandWalks.Data;

namespace NewZealandWalks.Repositories;

public class SQLWalkRepository : IWalkRepository
{
    private readonly NzWalksDbContext _dbContext;
    
    public SQLWalkRepository(NzWalksDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
}