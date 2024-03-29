﻿using Microsoft.AspNetCore.Mvc;
using PrimeraApi.Application.Contracts.Services;
using PrimeraApi.BusinessModels.Models;
using PrimeraApi.BusinessModels.Models.Office;

namespace PrimeraApi.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OfficeController : Controller
	{
		private IOfficeService _OfficeService;

		public OfficeController(IOfficeService officeService)
		{
			_OfficeService = officeService;
		}

		[HttpPost]
		[Route("paginated")]
		[ProducesResponseType(typeof(PaginatedResponse<ProductResponse>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult GetOfficePaginated(OfficeSearchRequest request)
		{
			var products = _OfficeService.GetOfficePaginated(request);
			return Ok(products);
		}


		[HttpGet]
		[ProducesResponseType(typeof(OfficeResponse), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult GetOfficeByCode(string code)
        {
			OfficeResponse? office = _OfficeService.GetOfficeByCode(code);

			if (office != null) return Ok(office);
			else return NoContent();
        }


		[HttpDelete]
		[Route("{code}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult DeleteOffice(string code)
        {
			bool result = _OfficeService.DeleteOffice(code);

			if (result) return NoContent();
			else return NotFound("Office dont exist");
        }

		[HttpPost]
		[ProducesResponseType(typeof(OfficeResponse), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult AddOffice(CreateOfficeRequest request)
        {
			OfficeResponse? office = _OfficeService.AddOficce(request);

			if (office != null) return Ok(office);
			else return Conflict("La oficina ya existe");
        }


		[HttpPut]
		[Route("{code}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult UpdateOffice(string code, UpdateOfficeRequest request)
        {
			OfficeResponse? office = _OfficeService.UpdateOffice(code, request);

			if (office != null) return Ok(office);
			else return NotFound("La oficina no existe");
        }
	}
}

