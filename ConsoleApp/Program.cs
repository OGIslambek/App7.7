using System.Diagnostics.Metrics;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApp
{
    class Client
    {
        public string Name;

        public string Address;

        public Client(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }

    class Couriers
    {
        public string Name;

        public Couriers(string name)
        {
            Name = name;
        }
    }

    class Shop
    {
        public string Address;

        public Shop(string address)
        {
            Address = address;
        }
    }
    class PickPoint
    {
        public string Address;

        public PickPoint(string address)
        {
            Address = address;
        }
    }

    class Products
    {
        public string Name;

        public Products(string name)
        {
            Name = name;
        }
    }
    abstract class Delivery
    {
        string ClientName;

        public string Address;

        public Delivery(string clientName, string address)
        {
            ClientName = clientName;

            Address = address;
        }
    }

    class HomeDelivery : Delivery
    {
        public HomeDelivery(string clientName, string address) : base (clientName, address)
        {
            
        }
    }

    class PickPointDelivery : Delivery
    {
        public PickPointDelivery(string clientName, string address) : base(clientName, address)
        {
            
        }
    }

    class ShopDelivery : Delivery
    {
        public ShopDelivery(string clientName, string address) : base(clientName, address)
        {
            
        }
    }

    class Order<TDelivery> where TDelivery : Delivery
    {
        public TDelivery delivery;

        public Products products;

        public Couriers courier;

        public Client client;

        public void DisplayOrder()
        {
            if (delivery is HomeDelivery)
            {
                Console.WriteLine("Доставка на дом");
            }
            else if (delivery is PickPointDelivery)
            {
                Console.WriteLine("Доставка на пункт выдачи");
            }
            else if (delivery is ShopDelivery)
            {
                Console.WriteLine("Доставка на адресс магазина");
            }

            Console.WriteLine($"Заказчик: {client.Name}");
            Console.WriteLine($"Адресс доставки: {delivery.Address}");
            Console.WriteLine($"Название товара: {products.Name}");

            if (courier != null)
            {
                Console.WriteLine($"Ваш курьер: {courier.Name}");
            }
        }

        public Order(TDelivery delivery, Products product, Client client, Couriers courier = null)
        {
            this.delivery = delivery;
            this.products = product;
            this.courier = courier;
            this.client = client;
        }
    }

    internal class Program
    {
        static string[] ProductsName = {"Телевизор", "Смартфон", "Камера"};
        static void Main(string[] args)
        {
            Client client1 = new Client("Иван", "ул. Пушкина 1");
            Client client2 = new Client("Ксения", "ул. Лавандовая 11");
            Client client3 = new Client("Владимир", "ул. Белая 74");

            Couriers courier1 = new Couriers("Антон");

            Products product1 = new Products(ProductsName[0]);
            Products product2 = new Products(ProductsName[1]);
            Products product3 = new Products(ProductsName[2]);

            Shop shop = new Shop("Магазин на ул. Мира 4");
            PickPoint pickPoint = new PickPoint("Пункт выдачи на ул. Правды 12");

            HomeDelivery homeDelivery = new(client1.Name, client1.Address);
            ShopDelivery shopDelivery = new(client2.Name, shop.Address);
            PickPointDelivery pickPointDelivery = new(client3.Name, pickPoint.Address);

            Order<HomeDelivery> order1 = new(homeDelivery, product1, client1, courier1);
            Order<ShopDelivery> order2 = new(shopDelivery, product2, client2);
            Order<PickPointDelivery> order3 = new(pickPointDelivery, product3, client3);

            order1.DisplayOrder();
            Console.WriteLine();
            order2.DisplayOrder();
            Console.WriteLine();
            order3.DisplayOrder();

        }
    }
}
