namespace Gateways.Data.Repositories
{
    public abstract class BaseRepository 
    {
        private readonly GatewaysContext _context;
        public BaseRepository(GatewaysContext context)
        {
            _context = context;
        }
        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
