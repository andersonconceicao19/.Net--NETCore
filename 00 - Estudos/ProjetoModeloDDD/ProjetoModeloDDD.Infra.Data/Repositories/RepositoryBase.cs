﻿using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : Entity
    {
        protected ProjetoModeloContext _context = new ProjetoModeloContext();
       


        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
        public TEntity GetEntityById(Guid Id)
        {
            return _context.Set<TEntity>().Find(Id);
        }
        public void Add(TEntity Obj)
        {
            _context.Set<TEntity>().Add(Obj);
            SaveChange();
        }


        public void Remove(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
            SaveChange();
        }

        public void Update(TEntity obg)
        {
            _context.Entry(obg).State = EntityState.Modified;
            SaveChange();
        }
        public async Task<int> SaveChange()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
           
        }
    }
}
