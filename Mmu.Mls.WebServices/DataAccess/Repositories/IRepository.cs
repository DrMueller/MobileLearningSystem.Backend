﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mmu.Mls.WebServices.DataAccess.Repositories
{
    public interface IRepository<TModel>
    {
        Task DeleteAsync(string id);

        Task<IReadOnlyCollection<TModel>> LoadAllAsync();

        Task<IReadOnlyCollection<TModel>> LoadAsync(Expression<Func<TModel, bool>> predicate);

        Task<TModel> LoadByIdAsync(string id);

        Task<TModel> SaveAsync(TModel model);
    }
}