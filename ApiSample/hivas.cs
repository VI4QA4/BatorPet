using Hotcakes.CommerceDTO.v1
using Hotcakes.CommerceDTO.v1.Catalog
using Hotcakes.CommerceDTO.v1.Client


string url = "http://YOURDOMAIN.COM";
string key = "YOUR-API-KEY";

Api proxy = new Api(url, key);

// specify the product to look for
var productId = "a5c9f622-9e03-4399-9a89-8f3dce4644e2";

// call the API to find the product
ApiResponse<ProductDTO> response = proxy.ProductsFind(productId);

