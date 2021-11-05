using Challenge_Desafio3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge_Desafio3.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ChallengeContext _contexto;
        private DbSet<TEntity> _dbSet;
        public Repository(ChallengeContext contexto)
        {
            _contexto = contexto;
            _dbSet = contexto.Set<TEntity>();
        }



        public void Add(TEntity data)
        {
            _dbSet.Add(data);
        }

        public void Delete(int id)
        {
            var dataToDelete = _dbSet.Find(id);
            _dbSet.Remove(dataToDelete);
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.ToList();
        }

        public TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }

        public void Save()
        {
            _contexto.SaveChanges();
        }

        public void Update(TEntity data)
        {
            _dbSet.Attach(data);
            _contexto.Entry(data).State = EntityState.Modified;
        }
    }
}
