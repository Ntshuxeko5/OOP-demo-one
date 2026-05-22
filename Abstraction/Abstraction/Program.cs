using System;
using System.Threading;

interface INotificationService // Interface so that the system is not hardwired but calls the send method for notifications
{
    void Send(string recipient, string message); // send method with no body. 
}


class EmailNotificationService : INotificationService
{
    public void Send(string recipient, string message)
    {
        Console.WriteLine($" [SENDING EMAIL] To: {recipient}"); // Email implimentation
        Console.WriteLine($"Message: {message}");
    }

}

class SmsNotificationService : INotificationService 
{
    public void Send(string recipient, string message)
    {
        Console.WriteLine($" [SENDING SMS] To: {recipient}"); // SMS implimentation
        Console.WriteLine($"Message: Good Day\n{message}");
    }

}
// Adding another notification channel would not affect the existing code as it would call the Send() Method 

class OrderService
{
    private readonly INotificationService _notificationService;
    public OrderService(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    public void PlaceOrder(string customer, string orderDetails)
    {
        Console.WriteLine($"\n[SYSTEM] Processing: Placing {orderDetails} for {customer}...");

        // Simulating processing delay
        Thread.Sleep(500);

        Console.WriteLine($"[SYSTEM] Success: {orderDetails} saved to database.");

        // Construct the message and trigger the injected notification service
        string message = $"Your order ({orderDetails}) has been placed successfully.";
        _notificationService.Send(customer, message);

    }

}

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("STARTING ORDER SYSTEM ");
        // 1. Run the Email Flow

        OrderService emailOrder = new OrderService(new EmailNotificationService());
        emailOrder.PlaceOrder("Ntshuxeko", "Order #001 - Laptop");

        // 2. Run the SMS Flow

        OrderService smsOrder = new OrderService(new SmsNotificationService());
        smsOrder.PlaceOrder("Ntshuxeko", "Order #002 - Phone");

        Console.WriteLine("\n ALL ORDERS PROCESSED ");

    }

}
