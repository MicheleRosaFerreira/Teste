using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Globalization;
using ViaCep.Model;
using Newtonsoft.Json;
using System.Net;

namespace ViaCep.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ViaCepController : ControllerBase
	{
		//viacep.com.br/ws/01001000/json/

		//public bool ValidateCep(string cepValue)
		//{
		//	cepValue.Replace(" ", "");

		//	if (cepValue.Length > 8)
		//	{
		//		return false;
		//	}
		//	return true;
		//}
		[HttpGet]
		public IActionResult GetCep(string cep)
		{
			//if (!ValidateCep(cep)) return BadRequest("Tamanho de Cep inválido");	
		
			var client = new RestClient("https://viacep.com.br/ws/");
			var request = new RestRequest($"{cep}/json/");
		
			var response = client.ExecuteGet<ViaCepModel>(request);

			if (response.Data == null || response.StatusCode != HttpStatusCode.OK) return StatusCode(404);

			var data = response.Data;

			return Ok(data);
		}
	}
}