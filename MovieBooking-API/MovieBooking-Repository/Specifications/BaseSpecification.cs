﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieBooking_Repository.Specifications
{
    public interface IBaseSpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }
    public class BaseSpecification<T> : IBaseSpecification<T>
    {
        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria  { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddIncludes(Expression<Func<T,object>> expression)
        {
            Includes.Add(expression);
        }
    }
}
