using Business.Concrete;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Helplers.FileHelper;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using Color = Entities.Concrete.Color;

public class Program
{
    
    private static void Main(string[] args)
    {
        RentalManager rentalsManager = new RentalManager(new EfRentalDal());
        /*RentalAdd(rentalsManager);
        RentalUpdate(rentalsManager);
        RentalDelete(rentalsManager);
        RentalGetAllDto(rentalsManager);*/

        Line();

        CustomerManager customersManager = new CustomerManager(new EfCustomerDal());
        /*CustomerAdd(customersManager);
        CustomerUpdate(customersManager);
        CustomerDelete(customersManager);
        CustomerGetAll(customersManager);
        CustomerDto(customersManager);*/

        Line();

        UserManager userManager = new UserManager(new EfUserDal());
        /*UserAdd(usersManager);
        UserUpdate(usersManager);
        UserDelete(usersManager);
        UserGetAll(usersManager);*/

        Line();


        CarManager carsManager = new CarManager(new EfCarDal());
        /*CarAdd(carsManager);
        CarUpdate(carsManager);
        CarDelete(carsManager);
        CarDtoList(carsManager);*/

        Line();

        BrandManager brandsManager = new BrandManager(new EfBrandDal());
        /*BrandAdd(brandsManager);
        BrandUpdate(brandsManager);
        BrandDelete(brandsManager);
        BrandGetAll(brandsManager);*/

        Line();

        ColorManager colorsManager = new ColorManager(new EfColorDal());
        /*ColorAdd(colorsManager);
        ColorUpdate(colorsManager);
        ColorDelete(colorsManager);
        ColorGetAll(colorsManager);*/

        Line();
        
    }
    #region Rentals
    private static void RentalGetAllDto(RentalManager rentalsManager)
    {
        var result = rentalsManager.GetRentalDetail();

        if (result.Success)
        {
            foreach (var rentaldto in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", rentaldto.Id, rentaldto.CarName, rentaldto.CompanyName, rentaldto.RentDate, rentaldto.ReturnDate);
            }
        }

        Console.WriteLine(result.Message);
    }

    private static void RentalDelete(RentalManager rentalsManager)
    {
        rentalsManager.Delete(new Rental { Id = 3 });
    }

    private static void RentalUpdate(RentalManager rentalsManager)
    {
        rentalsManager.Update(new Rental
        {
            Id = 2,
            CarId = 2,
            CustomerId = 2,
            RentDate = DateTime.Now,
            ReturnDate = DateTime.Now
        });
    }

    private static void RentalAdd(RentalManager rentalsManager)
    {
        rentalsManager.Add(new Rental
        {
            CarId = 2,
            CustomerId = 2,
            RentDate = DateTime.Now,
            ReturnDate = DateTime.Now
        });
    }
#endregion
    #region Customers
    private static void CustomerDto(CustomerManager customersManager)
    {
        var result = customersManager.GetCustomerDetails();

        if (result.Success)
        {
            foreach (var customerDto in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3}", customerDto.Id, customerDto.FirstName, customerDto.LastName, customerDto.CompanyName);
            }
        }

        Console.WriteLine(result.Message);
    }
    private static void CustomerGetAll(CustomerManager customersManager)
    {
        var result = customersManager.GetAll();

        if (result.Success)
        {
            foreach (var customer in result.Data)
            {
                Console.WriteLine("{0} {1} {2}", customer.Id, customer.UserId, customer.CompanyName);
            }
        }

        Console.WriteLine(result.Message);
    }

    private static void CustomerDelete(CustomerManager customersManager)
    {
        customersManager.Delete(new Customer { Id = 3 });
    }

    private static void CustomerUpdate(CustomerManager customersManager)
    {
        customersManager.Update(new Customer
        {
            Id = 2,
            UserId = 2,
            CompanyName = "Kod Elektronik"
        });
    }

    private static void CustomerAdd(CustomerManager customersManager)
    {
        customersManager.Add(new Customer
        {
            UserId = 3,
            CompanyName = "Ukaz Yangın",
        });
    }
#endregion
    #region Users
    /*private static void UserGetAll(UserManager usersManager)
    {
        var result = usersManager.GetAll();

        if (result.Success)
        {
            foreach (var user in result.Data)
            {
               // Console.WriteLine("{0} {1} {2} {3} {4}", user.Id, user.FirstName, user.LastName, user.Email, user.Password);
            }
        }

        Console.WriteLine(result.Message);
    }

    private static void UserDelete(UserManager usersManager)
    {
        usersManager.Delete(new User
        {
            Id = 3
        });
    }

    private static void UserUpdate(UserManager usersManager)
    {
        usersManager.Update(new User
        {
            Id = 1,
            FirstName = "Hakan",
            LastName = "Sönmez",
            Email = "hakansonmez2326@gmail.com",
            //Password = "Password"
        });
    }

    private static void UserAdd(UserManager usersManager)
    {
        usersManager.Add(new User
        {
            FirstName = "Veli",
            LastName = "Öztürk",
            Email = "veliozturk@gmail.com",
            //Password = "12345678"
        });
    }*/
    #endregion
    #region Colors
    private static void ColorGetAll(ColorManager colorsManager)
    {
       var result = colorsManager.GetAll();

        if (result.Success)
        {
            foreach (var color in result.Data)
            {
                Console.WriteLine("{0} {1}", color.ColorId, color.ColorName);
            }
        }

        Console.WriteLine(result.Message);
    }

    private static void ColorDelete(ColorManager colorsManager)
    {
        colorsManager.Delete(new Color
        {
            ColorId = 2
        });
    }

    private static void ColorUpdate(ColorManager colorsManager)
    {
        colorsManager.Update(new Color
        {
            ColorId = 1,
            ColorName = "Black Matte"
        });
    }

    private static void ColorAdd(ColorManager colorsManager)
    {
        colorsManager.Add(new Color
        {
            ColorName = "Red"
        });
    }
    #endregion
    #region Brands
    private static void BrandGetAll(BrandManager brandsManager)
    {
        var result = brandsManager.GetAll();

        if (result.Success)
        {
            foreach (var brand in result.Data)
            {
                Console.WriteLine("{0} {1}", brand.BrandId, brand.BrandName);
            }
        }

        Console.WriteLine(result.Message);
    }
    private static void BrandDelete(BrandManager brandsManager)
    {
        brandsManager.Delete(new Brand
        {
            BrandId = 2
        });
    }

    private static void BrandUpdate(BrandManager brandsManager)
    {
        brandsManager.Update(new Brand
        {
            BrandId = 1,
            BrandName = "Range Over Sports"
        });
    }

    private static void BrandAdd(BrandManager brandsManager)
    {
        brandsManager.Add(new Brand
        {
            BrandName = "Jaguar"
        });
    }
    #endregion
    #region Cars
    private static void CarDtoList(CarManager carsManager)
    {
        var result = carsManager.GetCarsDetails();
        if (result.Success)
        {
            foreach (var carDto in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", carDto.CarId, carDto.BrandName, carDto.ColorName, carDto.DailyPrice, carDto.Description);
            }
        }

        Console.WriteLine(result.Message);

    }
    private static void CarDelete(CarManager carsManager)
    {
        carsManager.Delete(new Car
        {
            CarId = 2,
        });
    }

    private static void CarUpdate(CarManager carsManager)
    {
        carsManager.Update(new Car
        {
            CarId = 10,
            BrandId = 2,
            ColorId = 2,
            ModelYear = 2010,
            DailyPrice = 75,
            Description = "TestingUpdate"
        });
    }

    private static void CarAdd(CarManager carsManager)
    {
        carsManager.Add(new Car
        {
            BrandId = 3,
            ColorId = 1,
            ModelYear = 2023,
            DailyPrice = 400,
            Description = "a"
        });
      
    }
    #endregion

    private static void Line()
    {
        Console.WriteLine("-------------------------------");
    }
}