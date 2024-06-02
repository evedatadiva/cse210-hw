using System;
using System.Collections.Generic;

class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public string Street { get { return _street; } }
    public string City { get { return _city; } }
    public string State { get { return _state; } }
    public string Country { get { return _country; } }

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

class Customer
{
    private string _name;
    private Address _address;

    public string Name { get { return _name; } }
    public Address Address { get { return _address; } }

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}

class Product
{
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    public string Name { get { return _name; } }
    public string ProductId { get { return _productId; } }
    public decimal Price { get { return _price; } }
    public int Quantity { get { return _quantity; } }

    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }
}

class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public List<Product> Products { get { return _products; } }
    public Customer Customer { get { return _customer; } }

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal totalCost = 0;
        foreach (var product in _products)
        {
            totalCost += product.GetTotalCost();
        }

        totalCost += _customer.IsInUSA() ? 5 : 35;
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in _products)
        {
            packingLabel += $"Name: {product.Name}, Product ID: {product.ProductId}\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.Name}\n{_customer.Address.GetFullAddress()}";
    }
}

// Program - principal
class Program
{
    static void Main(string[] args)
    {
        // Address
        Address address1 = new Address("123 Main St", "Anytown", "NY", "USA");
        Address address2 = new Address("456 Maple Rd", "Othertown", "NJ", "USA");

        // clients
        Customer customer1 = new Customer("Evelin Flores", address1);
        Customer customer2 = new Customer("Sam Sherman", address2);

        // products
        Product product1 = new Product("Widget", "W123", 3.50m, 10);
        Product product2 = new Product("Gadget", "G456", 7.25m, 5);
        Product product3 = new Product("Screen", "T789", 12.75m, 20);

        // orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // results
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order.GetTotalCost():C}");
        Console.WriteLine();
    }
}
