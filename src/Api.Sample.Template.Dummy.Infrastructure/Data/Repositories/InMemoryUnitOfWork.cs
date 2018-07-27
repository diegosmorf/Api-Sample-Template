using Api.Cqrs.Template.Core.Contract.Repository;
using System;

namespace Api.Sample.Template.Dummy.Infrastructure.Data.Repositories
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        public bool Commit()
        {
            Console.WriteLine("Commit");
            return true;
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");            
        }
    }
}