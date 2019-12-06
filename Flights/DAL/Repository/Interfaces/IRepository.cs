using System;
using System.Linq;
using System.Threading.Tasks;

namespace Flights.DAL.Repository.Interfaces
{
    /// <summary>
    /// Interface with common repository actions 
    /// </summary>
    /// <typeparam name="T">Entity Object</typeparam>
    public interface IRepository<T> : IDisposable where T : class
    {
        /// <summary>
        /// Add a new Entity to Database
        /// </summary>
        /// <param name="obj">Entity Object</param>
        void Add(T obj);
        
        /// <summary>
        /// Async Method
        /// Gets from Database an Entity given a specific identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Object Entity</returns>
        Task<T> GetById(Guid id);
        
        /// <summary>
        /// Get all records from Database for a given Entity
        /// </summary>
        /// <returns>IQueryable of entities</returns>
        IQueryable<T> GetAll();
        
        /// <summary>
        /// Updates an existing Entity in Databse
        /// </summary>
        /// <param name="obj"></param>
        void Update(T obj);
        
        /// <summary>
        /// Commits changes made
        /// </summary>
        /// <returns>Number of entities successfully commited</returns>
        Task<int> SaveChanges();   
    }
}