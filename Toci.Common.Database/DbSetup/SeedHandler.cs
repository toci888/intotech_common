using Intotech.Common.Database.Interfaces.DbSetup;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Database.DbSetup
{
    public class SeedHandler : ISeedHandler
    {
        protected DbContext DbContext { get; set; }

        protected List<object> Entities = new List<object>();

        public SeedHandler(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual bool AddEntity(object modelEntity)
        {
            Entities.Add(modelEntity);

            return true;
        }

        public virtual bool SeedCollection()
        {
            foreach (object entity in Entities) 
            {
                try
                {
                    Insert(entity);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Nie udało się zaseedować tabeli, prawdopodobnie są już w niej dane. {ex.Message} {entity}");
                }
            }

            return true;
        }

        protected virtual bool Insert(object model) 
        {
            MethodInfo setMethodInfo = DbContext.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                        .Where(m => m.Name == "Set" && m.IsGenericMethod)
                                        .First();

            MethodInfo custom = setMethodInfo.MakeGenericMethod(model.GetType());

            var set = custom.Invoke(DbContext, null);

            MethodInfo addMethod = set.GetType().GetMethod("Add");

            //set.Add(model);
            addMethod.Invoke(set, new[] { model });

            DbContext.SaveChanges();

            //DbContext.Set<object>().Add(model);

            return true;
        }
    }
}
