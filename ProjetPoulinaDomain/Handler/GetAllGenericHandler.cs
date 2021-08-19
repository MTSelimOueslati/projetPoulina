﻿using ProjetPoulinaDomain.Interface;
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
    public class GetAllGenericHandler<TEntity> : IRequestHandler<GetAllGeneric<TEntity>, IEnumerable<TEntity>> where TEntity : class
    {
        private readonly IRepository<TEntity> repository;

        public GetAllGenericHandler(IRepository<TEntity> userRepository)
        {
            repository = userRepository;
        }

        public Task<IEnumerable<TEntity>> Handle(GetAllGeneric<TEntity> request, CancellationToken cancellationToken)
        {
            var result = repository.GetList(request.Condition, request.Includes);
            return Task.FromResult(result);
        }
    }
}
