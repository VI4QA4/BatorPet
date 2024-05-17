using Hotcakes.CommerceDTO.v1.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Shipping;
using System.Security.Policy;
using System.Text.Json;
using System.IO;

namespace ApiSample
{
    public partial class Kliens : Form
    {
        private double kedvezmeny = 0.1;
        private string desktopPath;

        public Kliens()
        {
            InitializeComponent();
            desktopPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ApiSample");
            Directory.CreateDirectory(desktopPath); // Ensure the directory exists
        }

        private void Kliens_Load(object sender, EventArgs e)
        {
            string imagePath = Path.Combine(desktopPath, "logo_legveglegesebb.png");
            pictureBox2.Image = Image.FromFile(imagePath);

            textBox1.Text = "0";
            string url = "http://20.234.113.211:8093";
            string key = "1-41c9229f-7395-41cb-b3e9-8b330e442304";

            Api proxy = new Api(url, key);

            ApiResponse<List<ProductDTO>> response = proxy.ProductsFindAll();
            List<ProductDTO> products = response.Content;

            listBox1.DisplayMember = "ProductName";
            listBox2.DisplayMember = "ProductName";

            foreach (var product in products)
            {
                listBox1.Items.Add(product);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductDTO selected = listBox1.SelectedItem as ProductDTO;
            listBox2.Items.Add(selected);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<ProductDTO> products = new List<ProductDTO>();

            foreach (var item in listBox2.Items)
            {
                if (item is ProductDTO prod)
                {
                    products.Add(prod);
                }
            }

            string filePath = Path.Combine(desktopPath, "backup.json");
            ProductDataSaver.SaveProductsToFile(products, filePath);
            Console.Write(products);

            string url = "http://20.234.113.211:8093";
            string key = "1-41c9229f-7395-41cb-b3e9-8b330e442304";

            Api proxy = new Api(url, key);

            int kedvezmenyPercentage = Int32.Parse(textBox1.Text);
            decimal kedvezmeny = kedvezmenyPercentage / 100m;

            foreach (var item in listBox2.Items)
            {
                ProductDTO product = item as ProductDTO;

                if (product != null)
                {
                    decimal discountedPrice = product.SitePrice * (1 - kedvezmeny);
                    decimal roundedPrice = Math.Round(discountedPrice, 0);

                    product.SitePrice = roundedPrice;

                    ApiResponse<ProductDTO> response = proxy.ProductsUpdate(product);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(desktopPath, "backup.json");
            List<ProductDTO> loadedProducts = ProductDataSaver.LoadProductsFromFile(filePath);
            Console.Write(loadedProducts);

            string url = "http://20.234.113.211:8093";
            string key = "1-41c9229f-7395-41cb-b3e9-8b330e442304";

            Api proxy = new Api(url, key);

            foreach (var item in loadedProducts)
            {
                ProductDTO product = item as ProductDTO;

                if (product != null)
                {
                    ApiResponse<ProductDTO> response = proxy.ProductsUpdate(product);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
