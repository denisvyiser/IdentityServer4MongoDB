using Project.identityserver.Domain.Core.Data;
using Project.identityserver.Domain.Core.Models;
using Project.identityserver.Infrastructure.Contexts.MongoDb;
using Project.identityserver.Infrastructure.Repositories.Base;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Project.identityserver.Test.Repository.Tests.Repositories
{
    public abstract class ReadMongoDbRepositoryTest<TEntity> where TEntity : Entity
    {

        Mock<ReadMongoDbRepository<TEntity>> _repositoryMock;
        //Mock<IReadMongoDbContext> _contextMock;
        List<TEntity> dbList;

        public ReadMongoDbRepositoryTest()
        {
           
            dbList = DBList();

            //MockSetup();
        }

        //public void MockSetup()
        //{
        //    _contextMock = new Mock<IReadMongoDbContext>();
        //    _repositoryMock = new Mock<ReadMongoDbRepository<TEntity>>(_contextMock.Object);

        //    _repositoryMock.Setup(x => x.GetAllPagedAsync(
        //        It.IsAny<Restriction>()
        //        , It.IsAny<Order>()
        //        , It.IsAny<Page>()
        //        , It.IsAny<Expression<Func<TEntity, bool>>>()
        //        , It.IsAny<Func<Expression<Func<TEntity, bool>>, PagedList<TEntity>>>()
        //        , It.IsAny<ProjectionDefinition<TEntity, TEntity>>()
        //    )).Returns((Restriction r, Order o, Page p, Expression<Func<TEntity, bool>> filter,
        //    Func<Expression<Func<TEntity, bool>>, PagedList<TEntity>> whenNoExists, ProjectionDefinition<TEntity, TEntity> projection) => {


        //        return Task.FromResult(dbList.AsQueryable().Order(o).Paged(p, o, r));

        //    });

        //    _repositoryMock.Setup(t => t.AddAsync(It.IsAny<TEntity>()))
        //      .Returns((TEntity t) =>
        //      {

        //          dbList.Add(t);

        //          return Task.CompletedTask;
        //      });
        //}

        [Fact]
        public async Task GetAllPagedAsync()
        {

            Expression<Func<TEntity, bool>> filter=null;
            //Func<Expression<Func<TEntity, bool>>, PagedList<TEntity>> whenNoExists=null;
            //ProjectionDefinition<TEntity, TEntity> Prjection=null;

           
            //var retorno = Task.WhenAll(_repository.Object.AddAsync(Obj()));

            var retorno = Task.FromResult(_repositoryMock.Object.GetAllPagedAsync(new Order("Id", true), new Page(1, 20), filter));

            Assert.True(retorno.IsCompletedSuccessfully);
            Assert.True(retorno.Exception == null);
        }

        public void GetAllAsync()
        {
           // var retorno = _repository.Object.GetAllAsync();
        }

        public void GetAllByCommandAsync(string command)
        {
           // var retorno = _repository.Object.GetAllByCommandAsync(command);
        }

        public void GetOneAsync()
        {
            //var retorno = _repository.Object.GetOneAsync();
        }

        public void GetLastOneAsync()
        {

        }

        [Fact]
        public async Task AddAsync()
        {

          var retorno = Task.FromResult(_repositoryMock.Object.AddAsync(Obj()));

            Assert.True(retorno.IsCompletedSuccessfully);
            //Assert.True(teste.Exception == null);

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

        public abstract List<TEntity> DBList();
    }
}
