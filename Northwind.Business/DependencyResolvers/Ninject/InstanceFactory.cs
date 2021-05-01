using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.DependencyResolvers.Ninject
{
    public class InstanceFactory
    {
        public static T GetInstance<T>() //bunu proje boyunca generic methodla yalnızca bir kere yapacağız 
        {
            var kernel = new StandardKernel(new BusinessModule()); //biz bindlar yazarak bir kutu oluşturduğumuzu düşünelim ve o kutuyu bu kodu yazarak bu modül olarak belirledik
            return kernel.Get<T>();
        }
    }
}
