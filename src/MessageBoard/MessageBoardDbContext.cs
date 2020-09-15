using MessageBoard.Model;
using Microsoft.EntityFrameworkCore;

namespace MessageBoard
{
    public class MessageBoardDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        public MessageBoardDbContext(DbContextOptions<MessageBoardDbContext> options)
            : base(options)
        {
        }
    }
}
