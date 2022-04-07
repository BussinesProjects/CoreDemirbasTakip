using DemirbasTakipSistemi.Interface;
using DemirbasTakipSistemi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DemirbasTakipSistemi.Repositories
{
    public class Repository<TEntity> /*: IRepository<TEntity>*/ where TEntity : class 
    {
        Context c= new  Context();


        public async Task<TEntity> Add(TEntity entity)
        {
            c.Set<TEntity>().Add(entity);
            await c.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await c.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            c.Set<TEntity>().Remove(entity);
            await c.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await c.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
           var list= await c.Set<TEntity>().ToListAsync();
            return list;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            c.Entry(entity).State = EntityState.Modified;
            await c.SaveChangesAsync();
            return entity;
        }

    }
}
