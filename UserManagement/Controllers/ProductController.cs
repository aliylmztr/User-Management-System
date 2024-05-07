using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserManagement.Data.Models;
using Token = UserManagement.Data.Models.Token;

namespace UserManagement.Controllers
{
    public class ProductController : Controller
    {
        string Baseurl = "http://185.124.86.45:8899";
        string TokenUrl = "http://185.124.86.45:8899/token";

        public async Task<IActionResult> Index()
        {
            List<Product> products = new List<Product>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                var loginData = new Dictionary<string, string>
        {
            {"username", "*******"},
            {"password", "********"},
            {"grant_type", "password"}
        };

                HttpResponseMessage TokenResponse = await client.PostAsync(TokenUrl, new FormUrlEncodedContent(loginData));

                var tokenResponce = TokenResponse.Content.ReadAsStringAsync().Result;
                var token = JsonConvert.DeserializeObject<Token>(tokenResponce);

                string queryParams = "/api/Integration//EticaretStokListesi?tarih=1900-01-01&depoid=1&miktarsifirdanbuyukstoklarlistelensin=False";

                var fullUrl = Baseurl + queryParams;
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

                HttpResponseMessage Res = await client.GetAsync(fullUrl);

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    var productsRaw = JsonConvert.DeserializeObject<dynamic>(EmpResponse);
                    products = JsonConvert.DeserializeObject<List<Product>>(productsRaw);
                }
                return View(products);
            }
        }
    }
}