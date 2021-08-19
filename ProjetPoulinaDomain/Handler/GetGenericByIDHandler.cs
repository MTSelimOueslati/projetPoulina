using ProjetPoulinaDomain.Interface;
using ProjetPoulinaDomain.Models;
using ProjetPoulinaDomain.Querie;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetPoulinaDomain.Handler
{
    public class GetGenericByIDHandler<TEntity> : IRequestHandler<GetByIDGeneric<TEntity>, TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> repositories;

        public GetGenericByIDHandler(IRepository<TEntity> Repository)
        {
            repositories = Repository;
        }


        public Task<TEntity> Handle(GetByIDGeneric<TEntity> request, CancellationToken cancellationToken)
        {
            var result = repositories.Get(request.Condition, request.Includes);
            return Task.FromResult(result);
        }
    }   }
