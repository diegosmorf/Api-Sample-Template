using Api.Cqrs.Template.Core.Contract.Repository;
using System;

namespace Api.Sample.Template.Database.Repositories
{
    public class SQLUnitOfWork : IUnitOfWork
    {
        public bool Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
