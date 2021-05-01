using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product> //FluentValidation ile çağırıp product adına inheritance ediyoruz
    {
        //fluent validation dökümanından diğer özellikleri bulun
        public ProductValidator() //constructor oluşturup ürünler için kuralları yazmaya başlıyoruz 
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün ismi boş bırakılamaz!"); //yanlarına notlar da ekleyebiliyorsunuz
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();             //yazılan yerin boş olmaması için
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan(0); //0dan büyük
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0); //int 16 olduğu için short dememiz gerek
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2); //categoryid 2 ise unitprice min 10 olmalı

            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün A harfi ile başlamalı!"); //bazı kurallarda methodlar oluşturmanız ve oradan çalışmanız gerekir 

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
