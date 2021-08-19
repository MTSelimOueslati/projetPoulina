using ProjetPoulinaDomain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPoulinaDomain.Command
{
   public class PutGeneric<TEntity> : IRequest<string> where TEntity : class
    {
        public PutGeneric(TEntity obj)
        {
            Obj = obj;
        }
        public TEntity Obj { get; }
    }
}
