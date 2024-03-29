﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeraApi.Application.Contracts.Services;
using PrimeraApi.BusinessModels.Models;
using PrimeraApi.BusinessModels.Models.Product;

namespace PrimeraApi.API.Controllers
{
	// genera api/products
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : Controller
	{
		private IProductService _productService;

		public ProductController(IProductService productService)
        {
			_productService = productService;
        }




		// api/products/paginated
		[HttpPost]
		[Route("paginated")]
		[ProducesResponseType(typeof(PaginatedResponse<ProductResponse>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult GetProductsPaginated(ProductSearchRequest request)
        {
			var products = _productService.GetProductsPaginated(request);
			return Ok(products);
        }


		// genera api/products/{code}
		[HttpGet]
		[Route("{code}")]
		[ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult GetProductByCode(string code)
        {
			ProductResponse? product = _productService.GetProductByCode(code);

			if (product != null) return Ok(product);
			else return NoContent();
		}


		// genera api/products/{code} // AUNQUE TENGAMOS 2 ENDPOINT CON LA MISMA RUTA, SON DIFERENTES VERBOS
		[HttpDelete]
		[Route("{code}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult DeleteProduct(string code)
        {
			bool result = _productService.DeleteProduct(code);

			if (result)
				return NoContent(); //Retornamos un 204, todo OK pero el code no se encuentra ya en la base de datos
			else
				return NotFound("Product dont exist");
        }

		[HttpPost]
		[ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult AddProduct(CreateProductRequest request)
        {
			ProductResponse? product = _productService.AddProduct(request);

			if (product != null) return Ok(product);
			else return Conflict("El producto ya existe");
        }

		[HttpPut]
		[Route("{code}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult UpdateProduct(string code, UpdateProductRequest request)
        {
			ProductResponse? product = _productService.UpdateProduct(code, request);

			if (product != null) return Ok(product);
			else return NotFound("El producto no existe");
        }
	}
}

