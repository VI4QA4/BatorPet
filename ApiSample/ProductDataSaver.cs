using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Hotcakes.CommerceDTO.v1.Catalog;

namespace ApiSample
{
    public class ProductDataSaver
    {
        public static void SaveProductsToFile(List<ProductDTO> products, string filePath)
        {
            try
            {
                Console.Write("trying");
                // Serialize the list to JSON
                var options = new JsonSerializerOptions { WriteIndented = true }; // To make the JSON easy to read
                string jsonString = JsonSerializer.Serialize(products, options);

                // Write the JSON string to file
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine("Products saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public static List<ProductDTO> LoadProductsFromFile(string filePath)
        {
            try
            {
                // Read the JSON string from file
                string jsonString = File.ReadAllText(filePath);

                // Deserialize the JSON string to a list of ProductDTO
                var products = JsonSerializer.Deserialize<List<ProductDTO>>(jsonString);
                Console.WriteLine("Products loaded successfully.");
                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading products: {ex.Message}");
                return null;
            }
        }
    }
}
