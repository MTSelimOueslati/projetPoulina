using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPoulinaDomain.Command
{

        public class RemoveByEntityGenericCommand<TEntity> : IRequest<string> where TEntity : class
        {



            public TEntity Entity { get; }

            public RemoveByEntityGenericCommand(TEntity entity)
            {
                Entity = entity;
            }

        }
    



}
