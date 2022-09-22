using AutoMapper;
using Northwind.Domain.Base;
using Northwind.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services
{
    public class ServiceManager : IServiceManager
    {
        //private readonly IRepositoryManager _repositoryManager;
        private readonly Lazy<ICategoryService> _lazyCategoryService;
        private readonly Lazy<ISupplierService> _lazySupplierService;
        private readonly Lazy<IProductService> _lazyProductService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            //_repositoryManager = repositoryManager;
            _lazyCategoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, mapper));
            _lazySupplierService = new Lazy<ISupplierService>(() => new SupplierService(repositoryManager, mapper));
            _lazyProductService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper));
        }

        public ICategoryService CategoryService => _lazyCategoryService.Value;

        public ISupplierService SupplierService => _lazySupplierService.Value;

        public IProductService ProductService => _lazyProductService.Value;
    }
}
