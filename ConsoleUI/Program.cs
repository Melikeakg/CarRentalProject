using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarsGetAll();
            //CarAdd();

            //ColorsGetAll();
            //ColorAdd();

            //CarDetails(); 

            //CustomerAdded();

            UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User { UserId = 1, FirstName = "Ali", LastName = "Kaya", Email = "ali@kaya.com", Password = "1112548" });

        }

        private static void CustomerAdded()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { CustomerId = 1, UserId = 1, CompanyName = "Anonim" });
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(car.CarName + "/" + car.DailyPrice);
                }
                
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }


        private static void ColorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId = 2, ColorName = "Gümüş" });
            
        }

        private static void ColorsGetAll()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { CarId = 4, BrandId = 1, ColorId = 2, DailyPrice = 150, ModelYear = 2017, Description = "Açıklama..", CarName="Honda Cıvıc"});
            
        }

        private static void CarsGetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }
        }
    }
}
