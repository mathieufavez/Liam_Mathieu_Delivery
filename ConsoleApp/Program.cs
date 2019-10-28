using BLL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerDbManager = new CustomerManager(Configuration);
            var deliverymanDbManager = new DeliverymanManager(Configuration);
            var restaurantDbManager = new RestaurantManager(Configuration);
            var deliveryDbManager = new DeliveryManager(Configuration);
            var dishDbManager = new DishManager(Configuration);

            Console.WriteLine("Test GIT");
            Console.WriteLine("Customer [C], Deliveryman [D]");
            string customerDeliverymanChoice = Console.ReadLine();

            if (customerDeliverymanChoice == "C")
            {
                Console.WriteLine("Already registered [1], New registration [2]");
                string registrationChoice = Console.ReadLine();
                if (registrationChoice == "1")
                {
                    Console.WriteLine("Username");
                    string usernameC = Console.ReadLine();

                    Console.WriteLine("Password");
                    string passwordC = Console.ReadLine();

                    while (usernameC != customerDbManager.GetLogin() && passwordC != customerDbManager.GetPassword()) //En fonction de l'id du customer
                    {
                        Console.WriteLine("Connection denied. Try again");

                        Console.WriteLine("Username");
                        usernameC = Console.ReadLine();

                        Console.WriteLine("Password");
                        passwordC = Console.ReadLine();
                    }

                    Console.WriteLine("Connection successful");

                    var restaurants = restaurantDbManager.GetAllRestaurants();

                    foreach (var restaurant in restaurants)
                    {
                        Console.WriteLine(restaurant.ToString());
                    }

                    Console.WriteLine("Choose the restaurant");
                    string idRestaurant = Console.ReadLine();
                    if (idRestaurant == restaurantDbManager.GetRestaurantDishes(int.Parse(idRestaurant)))
                    {
                        var dishes = dishDbManager.GetAllDishes(idRestaurant);
                    }
                }
            }
            else
            {
                var deliverymans = deliverymanDbManager.GetAllDeliveryman();

                foreach (var deliveryman in deliverymans)
                {
                    Console.WriteLine(deliveryman.ToString());
                }
                Console.WriteLine("Username");
                string usernameD = Console.ReadLine();

                Console.WriteLine("Password");
                string passwordD = Console.ReadLine();

                while (usernameD != deliverymanDbManager.GetLogin() && passwordD != deliverymanDbManager.GetPassword()) //En fonction de l'id du deliveryman
                {
                    Console.WriteLine("Connection denied. Try again");

                    Console.WriteLine("Username");
                    usernameD = Console.ReadLine();

                    Console.WriteLine("Password");
                    passwordD = Console.ReadLine();
                }

                Console.WriteLine("Connection successful");

                Console.WriteLine("Choose the delivery");
                var deliverys = deliveryDbManager.GetAllDelivery(); //En fonction de l'id du deliveryman
                foreach (var delivery in deliverys)
                {
                    Console.WriteLine(delivery.ToString());
                }

            }

        }

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .Build();

    }
}
