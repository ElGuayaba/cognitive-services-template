using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Namespace.ProjectName.Persistence.Contract;
using Namespace.ProjectName.Persistence.Contract.Repository;
using Namespace.ProjectName.Persistence.Implementation.Context;

namespace Namespace.ProjectName.Persistence.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ProjectNameDbContext Context;
        
        protected readonly ILogger<UnitOfWork> Logger;
        
        private bool _disposed;
        
        public IAuthorRepository AuthorRepository { get; set; }
        public IBlogRepository BlogRepository { get; set; }
        public IPostRepository PostRepository { get; set; }

        public UnitOfWork(ProjectNameDbContext context, ILogger<UnitOfWork> logger, IAuthorRepository authorRepository, IBlogRepository blogRepository, IPostRepository postRepository)
        {
            Context = context;
            Logger = logger;
            AuthorRepository = authorRepository;
            BlogRepository = blogRepository;
            PostRepository = postRepository;
        }

        public async Task SaveAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
                Logger.LogInformation("Database save operation finished correctly");
            }
            catch (DbUpdateConcurrencyException exception)
            {
                Logger.LogError(exception, "Database save operation failed ");

                throw;
            }
            catch (DbUpdateException exception)
            {
                Logger.LogError(exception, "Database save operation failed ");

                throw;
            }
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}