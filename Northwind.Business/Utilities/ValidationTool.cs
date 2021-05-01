using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Utilities
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity) //IValidator ProductValidator kodundan f12ye basarak kaynağına gittik ve interface'ini bulduk bu da tüm alanlarda çalışmamıza yarayacak
        {
            var result = validator.Validate(entity);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors); //tüm alanlarda kullanılabilecek bir method oluşturduk ve bu sayede artık kuralları böyle uygulamaya ekleyeceğiz
            }
        }
    }
}
