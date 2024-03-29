﻿using System;
using PrimeraApi.BusinessModels.Models;
using PrimeraApi.BusinessModels.Models.Office;
using PrimeraApi.DataAccess.Contracts.Models;

namespace PrimeraApi.Application.Mappers
{
	public class OfficeMapper
	{
		public static OfficeResponse MapOfficeResponseFromOfficeDTO(OfficeDTO request)
        {
			OfficeResponse result = new OfficeResponse
			{
				OfficeCode = request.OfficeCode,
				AddressLine1 = request.AddressLine1,
				AddressLine2 = request.AddressLine2,
				City = request.City,
				Country = request.Country,
				Phone = request.Phone,
				PostalCode = request.PostalCode,
				State = request.State,
				Territory = request.Territory,
			};

			return result;
        }


		public static OfficeDTO MapToOfficeDTOFromCreateOfficeRequest(CreateOfficeRequest request)
        {
			OfficeDTO result = new OfficeDTO
			{
				OfficeCode = request.OfficeCode,
				AddressLine1 = request.AddressLine1,
				AddressLine2 = request.AddressLine2,
				City = request.City,
				Country = request.Country,
				Phone = request.Phone,
				PostalCode = request.PostalCode,
				State = request.State,
				Territory = request.Territory

			};

			return result;
        }


		public static List<OfficeResponse> MapToOfficeResponseListFromOfficeDTOList(List<OfficeDTO> offices)
        {
			return offices.Select(pl => MapOfficeResponseFromOfficeDTO(pl)).ToList();
        }
	}
}

