using Project.identityserver.Domain.Core.Data;
using Project.identityserver.Domain.Core.Models;
using Project.identityserver.Infrastructure.Contexts.MongoDb;
using Project.identityserver.Infrastructure.Repositories;
using Project.identityserver.Repository.Test.Configuration;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Project.identityserver.Repository.Test.Tests.Repositories
{
    public abstract class GenericMongoRepository<TClientConfig,Client, Config, TEntity, ContextDB, Repository>
        where Client : MongoClient
        where Config : MongoDbContextConfig, new()
        where TEntity : Entity
        where ContextDB : MongoDbContext
        where Repository : MongoRepository<TEntity>
        where TClientConfig : ClientConfig<Client, Config>
    {
        //Test Fake
        protected Mock<ContextDB> _context;
        protected Mock<Repository> _repository;
        protected Mock<IMongoCollection<TEntity>> _collection;
        List<TEntity> lista;
        public GenericMongoRepository(TClientConfig clientConfig)
        {            
            _context = new Mock<ContextDB>(clientConfig.contextConfig, clientConfig.mongoClient);
            _collection = new Mock<IMongoCollection<TEntity>>();


        }
        //[Fact]
        //public async Task GetAllPagedAsync()
        //{
        //     _repository = new Mock<Repository>(_context.Object);

        //    lista = new List<TEntity>();

        //    _repository.Setup(x => x.GetAllPagedAsync(
        //        It.IsAny<Restriction>()
        //        , It.IsAny<Order>()
        //        , It.IsAny<Page>()
        //        , It.IsAny<Expression<Func<TEntity, bool>>>()
        //        , It.IsAny<Func<Expression<Func<TEntity, bool>>, PagedList<TEntity>>>()
        //        , It.IsAny<ProjectionDefinition<TEntity, TEntity>>()
        //    )).Returns((Restriction r, Order o, Page p, Expression<Func<TEntity, bool>> filter,
        //    Func<Expression<Func<TEntity, bool>>, PagedList<TEntity>> whenNoExists, ProjectionDefinition<TEntity, TEntity> projection) => {

        //        var cursor = filter == null ? _collection.Object.Find(t => true) : _collection.Object.Find(filter);

        //        if (projection != null)
        //            cursor = cursor.Project(projection);

        //        var result = cursor.ToListAsync().Result;

        //        return Task.FromResult(result.AsQueryable().Order(o).Paged(p, o, r));

        //    });

        //    _repository.Setup(t => t.AddAsync(It.IsAny<TEntity>()))
        //        .Returns((TEntity t) => {
        //            return _collection.Object.InsertOneAsync(t);
        //        });

        //    //var retorno = Task.WhenAll(_repository.Object.AddAsync(Obj()));

        //    var retorno = Task.FromResult(_repository.Object.GetAllPagedAsync(new Restriction(null, Condition.Default, null), new Order("Id", true), new Page(1, 20), null, null, null));

        //    Assert.True(retorno.IsCompletedSuccessfully);
        //    Assert.True(retorno.Exception == null);
        //}

        public void GetAllAsync()
        {
            //var retorno = _repository.Object.GetAllAsync();
        }

        public void GetAllByCommandAsync(string command)
        {
            var retorno = _repository.Object.GetAllByCommandAsync(command);
        }

        public void GetOneAsync()
        {
            var retorno = _repository.Object.GetOneAsync();
        }

        public void GetLastOneAsync()
        {

        }

        [Fact]
        public async Task AddAsync()
        {
            _repository = new Mock<Repository>(_context.Object);
                       
            var teste = Task.FromResult(_repository.Object.AddAsync(Obj()));

            Assert.True(teste.IsCompletedSuccessfully);
            Assert.True(teste.Exception == null);

        }

        public void UpdateAsync()
        {

        }

        public void UpdateManyAsync()
        {

        }

        public void RemoveAsync()
        {

        }

        public abstract TEntity Obj();

        public abstract IMongoCollection<TEntity> MongoDB();


    }
}
