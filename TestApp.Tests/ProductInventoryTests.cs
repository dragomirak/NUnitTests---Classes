using NUnit.Framework;
using System;
using System.Data.SqlTypes;
using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }
    
    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
        // Arrange
        string productName = "Banana";
        double productPrice = 2.50;
        int productQuantity = 4;

        string expected = $"Product Inventory:{Environment.NewLine}{productName} - Price: ${productPrice:f2} - Quantity: {productQuantity}";

        // Act
        this._inventory.AddProduct(productName, productPrice, productQuantity);

        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        // Arrange
        string expected = "Product Inventory:";
        
        // Act
       
        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        // Arrange
        string firstProductName = "Banana";
        double firstProductPrice = 2.50;
        int firstProductQuantity = 4;

        string secondProductName = "Lemon";
        double secondProductPrice = 4.50;
        int secondProductQuantity = 2;

        string expected = $"Product Inventory:{Environment.NewLine}{firstProductName} - Price: ${firstProductPrice:f2} - Quantity: {firstProductQuantity}" +
            $"{Environment.NewLine}{secondProductName} - Price: ${secondProductPrice:f2} - Quantity: {secondProductQuantity}";

        // Act
        this._inventory.AddProduct(firstProductName, firstProductPrice, firstProductQuantity);
        this._inventory.AddProduct(secondProductName, secondProductPrice, secondProductQuantity);

        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        // Arrange

        // Act
        double result = this._inventory.CalculateTotalValue();

        // Assert
        Assert.That(result, Is.Zero);
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        // Arrange
        string firstProductName = "Banana";
        double firstProductPrice = 2.50;
        int firstProductQuantity = 4;

        string secondProductName = "Lemon";
        double secondProductPrice = 4.50;
        int secondProductQuantity = 2;
                
        // Act
        this._inventory.AddProduct(firstProductName, firstProductPrice, firstProductQuantity);
        this._inventory.AddProduct(secondProductName, secondProductPrice, secondProductQuantity);

        double result = this._inventory.CalculateTotalValue();

        // Assert
        Assert.That(result, Is.EqualTo(19));
    }
}
