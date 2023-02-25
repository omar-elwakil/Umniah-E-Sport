using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UI.Helper.Managers
{
    public class SmartLinkApiClient
    {
        private readonly HttpClient _client;

        public SmartLinkApiClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://api.sltech.org/allcasualgames/");
            //SmartLink-API Key Header
            // key generator : https://www.guidgenerator.com/online-guid-generator.aspx

            //client.DefaultRequestHeaders.Add("APP-KEY", "22");
            client.DefaultRequestHeaders.Add("ApiKey", "a4c1a89b-753e-45a8-9260-84c1d159fd66");

            _client = client;
        }

        public async Task<string> GetAsync(string requestUrl)
        {
            var response = await _client.GetAsync(requestUrl);
            string jsonString = null;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            return jsonString;
        }
        public async Task<bool> PostAsync(string requestUrl, string jsonString)
        {

            var response = await _client.PostAsync(requestUrl, new StringContent(jsonString, Encoding.UTF8, "application/json"));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
