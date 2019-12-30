using GrpcServer.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrpcServer.Data
{
    public class ZoneSwitchContext : DbContext
    {
        public ZoneSwitchContext(DbContextOptions<ZoneSwitchContext> options): base(options)
        {

        }
        public DbSet<TransactionEntity> TransactionEntity { get; set; }
    }
}
