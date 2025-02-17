﻿namespace PeopleManagement.Infra.Repositories
{
    using PeopleManagement.Domain.Entities;
    using PeopleManagement.Domain.Interfaces.Repositories;
    using PeopleManagement.Infra.Contexts;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly AppDbContext appDbContext;

        public RepositoryBase(AppDbContext appDbContext)
            : base()
        {
            this.appDbContext = appDbContext;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await appDbContext.AddAsync(entity);

            await appDbContext.SaveChangesAsync();

            if(entity.Id != Guid.Empty)
            {
                return entity;
            }
            else
            {
                throw new InvalidOperationException("Something went wrong when adding!");
            }      
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var entity = await appDbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);

                if (entity == null)
                {
                    //Not found
                    return false;
                }

                appDbContext.Remove(entity);

                return await appDbContext.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll() => await appDbContext.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<TEntity?> GetById(Guid id) => await appDbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<TEntity> Update(TEntity entity)
        {
            appDbContext.Update(entity);

            await appDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
