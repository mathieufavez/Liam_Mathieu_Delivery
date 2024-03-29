﻿using BLL;
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
            var deliveryDbManager = new DeliveryManager(Configuration); 
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

                    int idCustomerTryingToConnect =customerDbManager.GetIdCustomer(usernameC);

                    //En fonction de l'id du customer
                    while ( passwordC != customerDbManager.GetPassword(idCustomerTryingToConnect, usernameC))
                    {

                        Console.WriteLine(passwordC);
                        Console.WriteLine("Connection denied. Try again");

                        Console.WriteLine("Username");
                        usernameC = Console.ReadLine();

                        Console.WriteLine("Password");
                        passwordC = Console.ReadLine();

                        idCustomerTryingToConnect = customerDbManager.GetIdCustomer(usernameC);
                    }
                    
                    Console.WriteLine("Connection successful");

                    Program.Suite(idCustomerTryingToConnect);


                }
                else
                {
                    Console.WriteLine("New registration !");

                    Console.WriteLine("Name : ");
                    string nameNewCustomer = Console.ReadLine();
                    Console.WriteLine("Lastname : ");
                    string lastNameNewCustomer = Console.ReadLine();
                    Console.WriteLine("City : ");
                    string cityNewCustomer = Console.ReadLine();
                    Console.WriteLine("ZIP : ");
                    string zipNewCustomer = Console.ReadLine();
                    int idCity = cityDbManager.GetIdCity(cityNewCustomer.ToLower(), zipNewCustomer);
                    if (idCity == 0) 
                    {
                       cityDbManager.AddCity(new City { Name = cityNewCustomer, Zip_code = int.Parse(zipNewCustomer)});
                       idCity = cityDbManager.GetIdCity(cityNewCustomer.ToLower(), zipNewCustomer);

                    }
                    Console.WriteLine("Address : ");
                    string addressNewCustomer = Console.ReadLine();
                    Console.WriteLine("Login : ");
                    string LoginNewCustomer = Console.ReadLine();
                    Console.WriteLine("Password : ");
                    string PasswordNewCustomer = Console.ReadLine();

                    customerDbManager.AddCustomer(new Customer { Name = nameNewCustomer, LastName = lastNameNewCustomer, Address = addressNewCustomer, Login = LoginNewCustomer, Password = PasswordNewCustomer, FK_idCity = idCity });
                    Console.WriteLine("Congratulations, your account has been created ! You can now start ordering food !");

                    int idNewCustomer = customerDbManager.GetIdCustomer(LoginNewCustomer);
                    Program.Suite(idNewCustomer);
                }
            }
            else
            {
                Console.WriteLine("Welcome to the delivery management");

                Console.WriteLine("Username");
                string usernameDM = Console.ReadLine();

                Console.WriteLine("Password");
                string passwordDM = Console.ReadLine();

                int idDeliverymanTryingToConnect = deliverymanDbManager.GetIdDeliveryman(usernameDM);

                //En fonction de l'id du customer
                while (passwordDM != deliverymanDbManager.GetPassword(idDeliverymanTryingToConnect, usernameDM))
                {
                    Console.WriteLine("Connection denied. Try again");

                    Console.WriteLine("Username");
                    usernameDM = Console.ReadLine();

                    Console.WriteLine("Password");
                    passwordDM = Console.ReadLine();
                }

                Console.WriteLine("Connection successful");

                Console.WriteLine("Which delivery have you done ? Insert the ID");
                
                var deliverys = deliveryDbManager.GetAllDelivery(idDeliverymanTryingToConnect); //En fonction de l'id du deliveryman
                foreach (var delivery in deliverys)
                {
                    Console.WriteLine(delivery.ToString());
                }

                string deliveryDone = Console.ReadLine();
                Console.WriteLine("Thank you ! The delivery " + deliveryDbManager.GetDelivery(int.Parse(deliveryDone)) + " has been successfully executed");
                //deliveryDbManager.changeStatusDeliveryToDone(idDelivery);
            }

        }

        public static void Suite(int idCustomer)
        {
            var restaurantDbManager = new RestaurantManager(Configuration);
            var dishDbManager = new DishManager(Configuration);
            var delivery_TimeDbManager = new Delivery_TimeManager(Configuration);
            var orderDbManager = new OrderManager(Configuration);
            var customerDbManager = new CustomerManager(Configuration);
            var deliveryDbManager = new DeliveryManager(Configuration);
            var orderDishDbManager = new Order_DishManager(Configuration);
            var deliverymanDbMangager = new DeliverymanManager(Configuration);

            Console.WriteLine("[1] New order, [2] Cancel order");
            string orderChoice = Console.ReadLine();
            if (orderChoice == "1")
            {
                Console.WriteLine("Restaurants list : ");

                var restaurants = restaurantDbManager.GetAllRestaurants();

                foreach (var restaurant in restaurants)
                {
                    Console.WriteLine(restaurant.ToString());
                }

                Console.WriteLine("Choose the restaurant");
                string idRestaurant = Console.ReadLine();


                var dishes = dishDbManager.GetAllDishes(int.Parse(idRestaurant));

                foreach (var dish in dishes)
                {
                    Console.WriteLine(dish.ToString());
                }

                Console.WriteLine("Choose your dish");
                string dishChoice = Console.ReadLine();

                int dishPrice = dishDbManager.GetDishPrice(int.Parse(dishChoice));

                Console.WriteLine("How many times do you want this dish ?");
                string dishQuantity = Console.ReadLine();

                int totalPrice = dishPrice * int.Parse(dishQuantity);

                var newOrder = orderDbManager.AddOrder(new Order { Status = "In procedure", FK_idCustomer = idCustomer });

                orderDishDbManager.AddOrder_Dish(new Order_Dish { Quantity = dishQuantity, FK_idDish = int.Parse(dishChoice), FK_idOrder = newOrder.IdOrder});

                //Sans plusieurs ordres, ça fonctionne
                /*while (dishChoice != "0")
                {
                    Console.WriteLine("Would you like something else ? If your order is done, insert [0]");
                    dishChoice = Console.ReadLine();
                    dishPrice = dishDbManager.GetDishPrice(int.Parse(dishChoice));

                    if (dishChoice != "0")
                    {
                        Console.WriteLine("How many times do you want this dish ?");
                        dishQuantity = Console.ReadLine();
                        totalPrice += dishPrice * int.Parse(dishQuantity);
                    }

                    //Bug ici à corriger
                    orderDishDbManager.AddOrder_Dish(new Order_Dish { Quantity = dishQuantity, FK_idDish = int.Parse(dishChoice), FK_idOrder = newOrder.IdOrder});
                }*/

                Console.WriteLine("The total of your command is : CHF "+ totalPrice + ".-");

                Console.WriteLine("When do you want your order to be delivered ? Choose the time with the ID");
               

                var delivery_times = delivery_TimeDbManager.GetAllDelivery_Time();
                foreach (var delivery_time in delivery_times)
                {
                    Console.WriteLine(delivery_time.ToString());
                }

                string deliveryTimeChoice = Console.ReadLine();

                Console.WriteLine("Do you validate this order ? Yes [Y], No [N]");
                string validationChoice = Console.ReadLine();

                if (validationChoice == "Y")
                {
                    Console.WriteLine("Thank you for ordering with Liam & Mathieu Food Delivery !");
                    Console.WriteLine("Your order will be there at "+ delivery_TimeDbManager.GetDelivery_Time(int.Parse(deliveryTimeChoice)));
                    

                    int idCityFromRestaurant = restaurantDbManager.GetidCityFromRestaurant(int.Parse(idRestaurant));

                    var deliverymans = deliverymanDbMangager.GetAllDeliveryman(idCityFromRestaurant);

                    foreach (var deliveryman in deliverymans)
                    {
                        //if(deliveryman.FK_idDelivery<5 && deliveryman.)
                    }

                    deliveryDbManager.AddDelivery(new Delivery { FK_idOrder = newOrder.IdOrder, FK_idRestaurant = int.Parse(idRestaurant), FK_idDelivery_Time = int.Parse(deliveryTimeChoice) });
                  
                }

                else 
                {
                    Console.WriteLine("You canceled the order. See you soon !");
                }
            }
            else
            {
                
                Console.WriteLine("Here is the list of your orders : ");

                var orders = orderDbManager.GetAllOrdersForOneCustomer(idCustomer);

                foreach (var order in orders)
                {
                    Console.WriteLine(order.ToString());
                }

                Console.WriteLine("Choose the order you want to delete with the id");
                string orderDelete = Console.ReadLine();
                var code = customerDbManager.Code(idCustomer) + orderDelete;
                Console.WriteLine("Here is your cancellation code for the chosen order :" + ' ' + code);
                Console.WriteLine("Insert you cancellation code :");
                string codeInserted = Console.ReadLine();
                while (codeInserted != code) 
                {
                    Console.WriteLine("Cancellation code wrong. Try again.");
                    codeInserted=Console.ReadLine();
                }
                Console.WriteLine("Are you sure you want to cancel this order ? Yes [Y], No [N]");
                string choice = Console.ReadLine();
                if (choice == "Y") 
                {
                    //Change status order
                    Console.WriteLine("Your order has been successfully cancelled !");
                }
                Console.WriteLine("Your order has not been cancelled");
            }
        }
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .Build();

    }
}
