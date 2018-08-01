using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApplication.Core.Models;
using MyApplication.Core.Repositories;

namespace MyApplication.Persistence.Repositories
{
    public class ProductionTypeRepository:IProductionTypeRepository
    {
        private readonly IApplicationDbContext _context;

        public ProductionTypeRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductionType> GetAllProductionTypes()
        {
            return _context.ProductionTypes.ToList();
        }
    }
}