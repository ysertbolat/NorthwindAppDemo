using FluentValidation;
using Northwind.Business.Abstract;
using Northwind.Business.Utilities;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{

    public class ProductManager:IProductService
    {
        private IProductDal _productDal; //dataaccess'i referans et

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product); //ValidationTool için using eklemeyi unutmayın
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            try
            {
              _productDal.Delete(product);
            }
            catch //(DbUpdateException e) //hatanın ismini yazdık ama hatanın ismini vermek güvenlik sıkıntısı yaratır bu yüzden bunu eklemeyin
            {
                throw new Exception("Silme Gerçekleşemedi!");
            }
           
        }

        public List<Product> GetAll() //entities'i referans et
        {
            //Business code
            return _productDal.GetAll();

        }

        public List<Product> GetProductsByCategory(string productName)
        {
            return _productDal.GetAll(p=>p.ProductName.ToLower().Contains(productName.ToLower())); //ToLower kullanmamızın nedeni büyük küçük harf hassasiyetini kaldırmak
        }

        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Update(product);
        }

        List<Product> IProductService.GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }
    }
}
