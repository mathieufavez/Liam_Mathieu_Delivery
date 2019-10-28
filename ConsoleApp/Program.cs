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
            var orderDbManager = new OrderManager(Configuration);
            var cityDbManager = new CityManager(Configuration);

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

                    Console.WriteLine("Restaurants list : ");

                    var restaurants = restaurantDbManager.GetAllRestaurants();

                    foreach (var restaurant in restaurants)
                    {
                        Console.WriteLine(restaurant.ToString());
                    }

                    Console.WriteLine("[1] New order, [2] Cancel order");
                    string orderChoice = Console.ReadLine();
                    if (orderChoice == "1")
                    {
                        Console.WriteLine("Choose the restaurant");
                        string idRestaurant = Console.ReadLine();
                        if (idRestaurant == restaurantDbManager.GetRestaurantDishes(int.Parse(idRestaurant)))
                        {
                            var dishes = dishDbManager.GetAllDishes(idRestaurant);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Choose the order you want to cancel : ");
                        orderDbManager.GetAllOrders(int.Parse(idCustomer); //Display all the orders the customer in question has currently
                        Console.WriteLine("Do you want to cancel this order ? Yes [Y], No[N]" + orderDbManager.GetOrder(idOrder));
                        string cancelChoice = Console.ReadLine();
                        if (cancelChoice == "Y")
                        {
                            Console.WriteLine("Insert your cancellation code (2 first letters of your lastname+first letter of your firstname " + orderDbManager.getIdOrder());
                            string cancellationCode = Console.ReadLine();
                            if (cancellationCode == getCancellationCode())
                                orderDbManager.changeOrderStatusToCanceled(idOrder);
                            Console.WriteLine("Order : " + orderDbManager.GetOrder(idOrder) + " successfuly canceled !");

                        }
                        else
                        {
                            Console.WriteLine("End");
                        }

                    }



                }
                else
                {
                    Console.WriteLine("New registration !");

                    Console.WriteLine("Name : ");
                    string nameNewCustomer = Console.ReadLine();
                    Console.WriteLine("Lastname : ");
                    string lastNameNewCustomer = Console.ReadLine();
                    Console.WriteLine("Address : ");
                    string addressNewCustomer = Console.ReadLine();
                    cityDbManager.GetAllCities();
                    Console.WriteLine("Insérer l'ID de la ville dans laquelle vous habitez");
                    string idCityNewCustomer = Console.ReadLine();
                    Console.WriteLine("Login : ");
                    string LoginNewCustomer = Console.ReadLine();
                    Console.WriteLine("Password : ");
                    string PasswordNewCustomer = Console.ReadLine();
                    customerDbManager.AddCustomer(nameNewCustomer, lastNameNewCustomer, addressNewCustomer, LoginNewCustomer, PasswordNewCustomer, idCityNewCustomer);

                    Console.WriteLine("Congratulations, your account has been created ! You can now start ordering food !");

                }
            }
            else
            {
                Console.WriteLine("Welcome to the delivery management");

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

                Console.WriteLine("Which delivery have you done ? Insert the ID");

                var deliverys = deliveryDbManager.GetAllDelivery(idDeliveryman); //En fonction de l'id du deliveryman
                foreach (var delivery in deliverys)
                {
                    Console.WriteLine(delivery.ToString());
                }
                string deliveryDone = Console.ReadLine();
                Console.WriteLine("Thank you ! The delivery " + deliveryDbManager.GetDelivery(idDelivery) + " has been successfully executed");
                deliveryDbManager.changeStatusDeliveryToDone(idDelivery);
            }

        }

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .Build();

    }
}
