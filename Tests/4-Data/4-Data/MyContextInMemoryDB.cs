using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Tests._4_Data
{
    public class MyContextInMemoryDB
    {
        public MyContext CreateInMemoryMyContext()
        {
            DbContextOptions<MyContext> options;
            var builder = new DbContextOptionsBuilder<MyContext>();
            builder.UseInMemoryDatabase("InMemoryDatabase");
            options = builder.Options;

            MyContext dbContext = new MyContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            return dbContext;
        }

    }
}
