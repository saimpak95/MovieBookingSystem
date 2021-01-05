using Microsoft.EntityFrameworkCore;
using MovieBooking_DomainModels;
using MovieBooking_Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking_Repository
{
    public interface IGenericRepository<T> where T: class
    {
        Task<IReadOnlyList<T>> GetListAsync(IBaseSpecification<T> specification);
        Task<T> GetByIDAsync(IBaseSpecification<T> specification);
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext db;

        public GenericRepository(DataContext db)
        {
            this.db = db;
        }
        public async Task<T> GetByIDAsync(IBaseSpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetListAsync(IBaseSpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }
        private IQueryable<T> ApplySpecification(IBaseSpecification<T> specification)
        {
            return SpecificationEvaluation<T>.GetQuery(db.Set<T>().AsQueryable(), specification);
        }
    }
}
