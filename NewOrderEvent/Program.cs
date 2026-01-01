using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NewOrderEvent
{


    public class OrderEventArgs : EventArgs
    {

        public string Name { get; }

        public double Prix { get; }

        public string Email { get; }

        public string MobileNumber { get; } 


        public OrderEventArgs(string name , double prix, string email , string Mobile) 
        {

            this.Name = name;
            this.Prix = prix;
            this.Email = email;
            this.MobileNumber = Mobile;
        }
    }

    public class Order
    {

        public event EventHandler<OrderEventArgs> OrderCompleted;


        public void CreateOrder(string name , double prix , string Email , string Mobile)
        {

            if (OrderCompleted != null)
            {

                OrderCompleted(this, new OrderEventArgs(name, prix,Email,Mobile));
            }
        }


    }

    public class EmailService
    {


      

        public void Subscribe(Order order)
        {

            order.OrderCompleted += HandleSendEmail;

        }

        public void Unsubscribe(Order order)
        {

            order.OrderCompleted -= HandleSendEmail;

        }

        public void HandleSendEmail(object sender , OrderEventArgs order)
        {

            Console.WriteLine("------------------Email------------------");
            Console.WriteLine($"To  : {order.Email}");
            Console.WriteLine("Object : Send Email by The order Event");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Order Name : {order.Name}");
            Console.WriteLine($"Order Prix : {order.Prix}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();


        }

    }

    public class SmsService
    {




        public void Subscribe(Order order)
        {

            order.OrderCompleted += HandleSendSms;

        }

        public void UnSubscribe(Order order)
        {

            order.OrderCompleted -= HandleSendSms;
        }

        public void HandleSendSms(object sender, OrderEventArgs order)
        {

            Console.WriteLine("------------------SMS------------------");
            Console.WriteLine($"To  : {order.MobileNumber}");
            Console.WriteLine("Title : Send SMS by The order Event");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Order Name : {order.Name}");
            Console.WriteLine($"Order Prix : {order.Prix}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();


        }


    }

    public class ShippingService
    {

        public void Subscribe(Order order)
        {

            order.OrderCompleted += HandleSendToShipping;

        }

        public void UnSubscribe(Order order)
        {

            order.OrderCompleted -= HandleSendToShipping;
        }

        public void HandleSendToShipping(object sender, OrderEventArgs order)
        {



            Console.WriteLine("------------------Shipping------------------");
            Console.WriteLine("Title : Send by The order Event");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Order Name : {order.Name}");
            Console.WriteLine($"Order Prix : {order.Prix}");
            Console.WriteLine($"Email Client : {order.Email}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();


        }


    }


    internal class Program
    {
        static void Main(string[] args)
        {

            var order = new Order();

            EmailService email  = new EmailService();
            SmsService sms = new SmsService();
            ShippingService shipping = new ShippingService();


            email.Subscribe(order);
            sms.Subscribe(order);
            shipping.Subscribe(order);

            order.CreateOrder("Iphone 11", 111.44, "mkissame9@gmail.com", "067598271881");


        }
    }
}
