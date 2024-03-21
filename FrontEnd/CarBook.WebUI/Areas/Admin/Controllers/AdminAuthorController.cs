﻿using CarBook.Dto.BannerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/AdminAuthor")]
	public class AdminAuthorController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public AdminBannerController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7143/api/Banners");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		[Route("CreateBanner")]
		public IActionResult CreateBanner()
		{
			return View();
		}

		[HttpPost]
		[Route("CreateBanner")]
		public async Task<IActionResult> CreateBanner(CreateBannerDto craeteBannerDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(craeteBannerDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7143/api/Banners", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[Route("RemoveBanner/{id}")]
		public async Task<IActionResult> RemoveBanner(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7143/api/Banners/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		[Route("UpdateBanner/{id}")]
		public async Task<IActionResult> UpdateBanner(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7143/api/Banners/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateBannerDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		[Route("UpdateBanner/{id}")]
		public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateBannerDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7143/api/Banners/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
