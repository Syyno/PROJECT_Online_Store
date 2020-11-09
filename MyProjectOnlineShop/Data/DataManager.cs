using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProjectOnlineShop.Data.Repositories.Interfaces;

namespace MyProjectOnlineShop.Data
{
    public class DataManager
    {
        public IProductOperations ProductOperations { get; set; }

        public DataManager(IProductOperations productOperations)
        {
            ProductOperations = productOperations;
        }

    }
}
