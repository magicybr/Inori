
using System.Threading;
using System.Threading.Tasks;
using Inori.Domain.SeedWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Inori.Domain.Infrastructure
{
    public class InoriDbContext : DbContext, IUnitOfWork
    {
        public InoriDbContext(DbContextOptions<InoriDbContext> options) : base(options)
        {

        }

        public InoriDbContext(DbContextOptions<InoriDbContext> options, IMediator mediator)
            : base(options)
        {

        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 开启延迟加载
            // optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

    public class InoriContextDesignFactory : IDesignTimeDbContextFactory<InoriDbContext>
    {
        public InoriDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InoriDbContext>()
                .UseSqlServer("");

            return new InoriDbContext(optionsBuilder.Options, new NoMediator());
        }

        class NoMediator : IMediator
        {
            public Task Publish(object notification, CancellationToken cancellationToken = default)
            {
                throw new System.NotImplementedException();
            }

            public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
            {
                throw new System.NotImplementedException();
            }

            public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
            {
                throw new System.NotImplementedException();
            }

            public Task<object> Send(object request, CancellationToken cancellationToken = default)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}