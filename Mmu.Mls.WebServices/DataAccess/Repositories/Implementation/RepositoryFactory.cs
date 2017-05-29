using System;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mls.WebServices.Models.Entities;

namespace Mmu.Mls.WebServices.DataAccess.Repositories.Implementation
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public RepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IRepository<TModel> CreateRepository<TModel>() where TModel : Entity, new()
        {
            var result = _serviceProvider.GetService<IRepository<TModel>>();
            return result;
        }
    }
}