using Intotech.Common.Database.Interfaces.DbSetup;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Database.DbSetup
{
    public class SeedHandler<TModel> : ISeedHandler<TModel> where TModel : class
    {
        protected DbContext DbContext { get; set; }

        protected List<TModel> Entities = new List<TModel>();

        public SeedHandler(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual bool AddEntity(TModel modelEntity)
        {
            Entities.Add(modelEntity);

            return true;
        }

        public virtual bool SeedCollection()
        {
            foreach (TModel entity in Entities) 
            {
                Insert(entity);
            }

            return true;
        }

        protected virtual bool Insert(TModel model) 
        {
            DbContext.Set<TModel>().Add(model);

            return true;
        }
    }
}
