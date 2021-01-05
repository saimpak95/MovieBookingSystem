
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieBooking_Repository.Specifications
{
   public class SpecificationEvaluation<TEntity> where TEntity: class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, IBaseSpecification<TEntity> specification)
        {
            var query = inputQuery;
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
