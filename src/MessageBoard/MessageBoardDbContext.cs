using Microsoft.EntityFrameworkCore;

namespace MessageBoard
{
    public class MessageBoardDbContext : DbContext
    {
        // TODO add models

        public MessageBoardDbContext(DbContextOptions<MessageBoardDbContext> options)
            : base(options)
        {
        }
    }
}
