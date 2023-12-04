using System;

public class InventorySystem
{
    public void UpdateQuantity(string productId, int quantity) => Console.WriteLine($"Updated inventory for product {productId} with quantity {quantity}");
}


public class PaymentSystem
{
    public void ProcessPayment(string paymentMethod, decimal amount) => Console.WriteLine($"Processed {paymentMethod} payment of {amount:C}");
}


public class OrderFulfillmentSystem
{
    public void ShipOrder(string orderId, string shippingAddress) => Console.WriteLine($"Shipped order {orderId} to {shippingAddress}");
}

public class OrderFacade
{
    private readonly InventorySystem inventorySystem;
    private readonly PaymentSystem paymentSystem;
    private readonly OrderFulfillmentSystem orderFulfillmentSystem;

    public OrderFacade()
    {
        inventorySystem = new InventorySystem();
        paymentSystem = new PaymentSystem();
        orderFulfillmentSystem = new OrderFulfillmentSystem();
    }

    public void PlaceOrder(string productId, int quantity, string paymentMethod, decimal amount, string shippingAddress)
    {
        Console.WriteLine("Order processing started...");
        inventorySystem.UpdateQuantity(productId, -quantity);
        paymentSystem.ProcessPayment(paymentMethod, amount);
        orderFulfillmentSystem.ShipOrder(Guid.NewGuid().ToString(), shippingAddress);
        Console.WriteLine("Order processing completed!");
    }
}

class Program
{
    static void Main()
    {
        var orderFacade = new OrderFacade();
        orderFacade.PlaceOrder("12345", 2, "Credit Card", 100.00m, "123 Shipping St");
        Console.ReadLine();
    }
}