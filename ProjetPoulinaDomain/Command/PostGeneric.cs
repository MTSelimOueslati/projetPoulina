using ProjetPoulinaDomain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPoulinaDomain.Command
{
   public class PostGeneric<TEntity> : IRequest<string> where TEntity : class
    {
        public PostGeneric(TEntity obj)
        {
            Obj = obj;
        }

        public TEntity Obj { get; }
    }
}
