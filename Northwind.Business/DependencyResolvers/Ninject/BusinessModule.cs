using Ninject.Modules;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule //using ile ninject module'ü ekleyin
    {
        public override void Load() 
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            //biri senden IProductService isterse ona ProductManager ver anlamındadır
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            //InSingletonScope() sadece bir kere üretilebilir anlamındadır

            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            //buraya kendi modüllerinizi farklı yerlerde çalışmak isterseniz tek tek yazacaksınız 
        }
    }
}
