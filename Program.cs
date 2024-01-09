using System;
using System.IO;

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class Program
{
    static void Main()
    {
        Product newProduct = new Product();

        Console.WriteLine("Enter the product name:");
        newProduct.Name = Console.ReadLine();

        Console.WriteLine("Enter the product price:");
        // Məhsulun qiyməti üçün girişi təsdiqləyib və təhlil edir
        if (decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            newProduct.Price = price;

            // Məhsul təfərrüatlarını mətn faylında saxlayır
            SaveProductToFile(newProduct);

            Console.WriteLine("Product details saved to file.");
        }
        else
        {
            Console.WriteLine("Invalid price format. Please enter a valid numeric value.");
        }

        Console.ReadKey();
    }

    static void SaveProductToFile(Product product)
    {
        // Mətn faylı yaradır və ya ona əlavə edir (lazım olduqda fayl yolunu dəyişdirir)
        string filePath = "products.txt";

        // Fayla məhsul təfərrüatlarını yazır
        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine($"Product Name: {product.Name}, Price: {product.Price:C}");
        }
    }
}