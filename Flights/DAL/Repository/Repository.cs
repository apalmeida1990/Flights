using System;
using System.Linq;
using System.Threading.Tasks;
using Flights.DAL.Context;
using Flights.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Flights.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly FlightContext _db;
        protected readonly DbSet<T> _dbSet;
        public Repository(FlightContext context)
        {
            _db = context;
            _dbSet = _db.Set<T>();
        }

        public async void Add(T obj)
        {
            await _dbSet.AddAsync(obj);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(Guid id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }

        public void Update(T obj)
        {
            _dbSet.Update(obj);
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}