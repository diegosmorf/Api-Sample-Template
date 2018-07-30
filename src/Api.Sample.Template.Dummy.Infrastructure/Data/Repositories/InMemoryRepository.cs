using Api.Domain.Contracts.Core.Entities;
using Api.Cqrs.Template.Core.Contract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Api.Sample.Template.Mock.Infrastructure.Data.Repositories
{
    public class InMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : IDomainEntity
    {
        public readonly List<TEntity> Repository = new List<TEntity>();

        public bool Update(TEntity instance)
        {
            Delete(instance.Id);
            return Insert(instance);
        }

        public bool Delete(Guid id)
        {
            Repository.RemoveAll(x => x.Id == id);
            return true;
        }

        public bool Insert(TEntity instance)
        {
            Repository.Add(instance);

            return true;
        }

        public void Dispose()
        {
            Repository.Clear();
        }

        public void Insert(IEnumerable<TEntity> instances)
        {
            instances.Select(x => this.Insert(x));
        }

        public void Delete(IEnumerable<Guid> ids)
        {
            ids.Select(x => this.Delete(x));
        }

        public void Update(IEnumerable<TEntity> instances)
        {
            instances.Select(x => this.Update(x));
        }
        public TEntity Find(Expression<Func<TEntity, bool>> expressao)
        {
            if (Repository.Any())
            {
                return Repository.AsQueryable().First(expressao);
            }
            return default(TEntity);
        }

        public IEnumerable<TEntity> All()
        {
            return Repository;
        }

        public IEnumerable<TEntity> FindList(Expression<Func<TEntity, bool>> expressao)
        {
            return Repository.AsQueryable().Where(expressao);
        }
        
        public TEntity FindById(Guid id)
        {
            return Repository.AsQueryable().FirstOrDefault(x=> x.Id == id);
        }
    }
}