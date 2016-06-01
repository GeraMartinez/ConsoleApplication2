using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Product> productos = new List<Product>();
        /*p.Add(new Product("AAA", "XBOX ONE", 6000.23m));
        p.Add(new Product("AAA", "PS4", 7000.23m));
        p.Add(new Product("AAC", "WiiU", 3000.99m));
        ProductDB.saveproducts(p);*/
        productos = ProductDB.GetProducts();
        foreach (Product p in productos)
            Console.WriteLine(p);
        Console.ReadKey();

    }
}
class Product
{
    public string code, description;
    public decimal price;

    public Product(string c, string d, decimal p)
    {
        code = c;
        description = d;
        price = p;
    }
    public override string ToString()
    {
        return String.Format("{0}-{1}-${2}", code, description, price);
    }
}
class ProductDB
{
    const string dir = @"C:\Users\Gera\Desktop\Nueva carpeta";
    const string path = dir + "@archivo.txt";

    public static List<Product> GetProducts()
    {
        StreamReader textIN =
                new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read));
        List<Product> products = new List<Product>();
        while (textIN.Peek() != -1)
        {
            string row = textIN.ReadLine();
            string[] columns = row.Split('|');
            products.Add(new Product(columns[0], columns[1], Convert.ToDecimal(columns[2])));
        }
        return products;
    }

    public static void saveproducts(List<Product> products)
    {
        StreamWriter textOut =
                new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
        foreach (Product p in products)
        {
            textOut.Write(p.code + "|");
            textOut.Write(p.description + "|");
            textOut.WriteLine(p.price);
        }
        textOut.Close();
    }
}