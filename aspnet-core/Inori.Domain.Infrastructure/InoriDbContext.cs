
using Inori.Domain.Infrastructure.EntityConfigurations;
using Inori.Domain.Models.Catalogs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Threading;
using System.Threading.Tasks;

namespace Inori.Domain.Infrastructure
{
    public class InoriDbContext : DbContext
    {

        public InoriDbContext(DbContextOptions<InoriDbContext> options) : base(options)
        {

        }

        //public InoriDbContext(DbContextOptions<InoriDbContext> options, IMediator mediator)
        //    : base(options)
        //{

        //}

        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // 开启延迟加载
            // optionsBuilder.UseLazyLoadingProxies();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());

            modelBuilder.Seed();
        }
    }

    public class InoriContextDesignFactory : IDesignTimeDbContextFactory<InoriDbContext>
    {
        public InoriDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InoriDbContext>()
                .UseSqlServer("Server=tcp:192.168.133.10,1433;Initial Catalog=InoriDB;User Id=sa;Password=WF1223@pass;");
                //.UseSqlServer("Server=.;Initial Catalog=InoriDB;Integrated Security=true");

            return new InoriDbContext(optionsBuilder.Options);
            //return new InoriDbContext(optionsBuilder.Options, new NoMediator());
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