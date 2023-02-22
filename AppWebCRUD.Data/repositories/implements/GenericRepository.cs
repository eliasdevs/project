using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppWebCRUD.Data.repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppWebCRUD.Data.repositories.implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppWebCrudContext appWebCrudContext;
        public GenericRepository(AppWebCrudContext _appWebCrudContext) {
            this.appWebCrudContext=_appWebCrudContext;
        }
        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            if(entity==null) throw new Exception("");
            appWebCrudContext.Set<TEntity>().Remove(entity);
            await appWebCrudContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await appWebCrudContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
         {
            return await appWebCrudContext.Set<TEntity>().FindAsync(id);
            
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            appWebCrudContext.Set<TEntity>().Add(entity);
            await appWebCrudContext.SaveChangesAsync();
             return entity;

        }

        public async Task<TEntity> Update(TEntity entity)
        {
            appWebCrudContext.Entry(entity).State = EntityState.Modified;
            await appWebCrudContext.SaveChangesAsync();
            return entity;
        }
        
        
    }
}
