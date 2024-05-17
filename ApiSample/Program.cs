#region License

// Distributed under the MIT License
// ============================================================
// Copyright (c) 2019 Hotcakes Commerce, LLC
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
// and associated documentation files (the "Software"), to deal in the Software without restriction, 
// including without limitation the rights to use, copy, modify, merge, publish, distribute, 
// sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or 
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
// THE SOFTWARE.

#endregion

using System;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Shipping;
using System.Collections.Generic;


namespace ApiSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            Kliens form = new Kliens();

            // Start the message loop
            form.ShowDialog();

            //string url = "http://20.234.113.211:8093";
            //string key = "1-41c9229f-7395-41cb-b3e9-8b330e442304";

            //http://20.234.113.211:8093/DesktopModules/Hotcakes/API/rest/v1/products?key=1-41c9229f-7395-41cb-b3e9-8b330e442304

            //Api proxy = new Api(url, key);

            // specify the product to look for
            //var productId = "639470d9-a47a-45d7-9da1-7956fe18131c";

            // call the API to find the product to update
            //var product = proxy.ProductsFind(productId).Content;

            //ApiResponse<List<ProductDTO>> response = proxy.ProductsFindAll();

            //List<ProductDTO> products = response.Content;

            //foreach (var product in products)
            //{
                // Write product information to the console
             //   Console.WriteLine($"Product ID: {product.Bvin}"); 
             //   Console.WriteLine($"Product Name: {product.ProductName}");
             //   Console.WriteLine(); // Empty line for separation
            //}

            // update one or more properties of the product
            //product.SitePrice = 5890;


            // call the API to update the product
            //ApiResponse<ProductDTO> response = proxy.ProductsUpdate(product);


            //Console.Write(response);



            Console.WriteLine("Done - Press a key to continue");
            Console.ReadKey();
            
        }
    }
}