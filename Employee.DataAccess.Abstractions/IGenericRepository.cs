﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Employee.DataAccess.Abstractions
{
    public interface IGenericRepository<T>
    {
        IContext Context { get; }

        IEnumerable<T> GetAll();

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        T Add(T entity);

        T Delete(T entity);

        void Edit(T entity);

        void Save();
    }
}