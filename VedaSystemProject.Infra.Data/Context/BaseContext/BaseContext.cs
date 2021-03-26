using Microsoft.EntityFrameworkCore;

namespace VedaSystemProject.Infra.Data.Context.BaseContext
{
    public class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        public BaseContext(DbContextOptions<TContext> options) : base(options) { }
    }
}
