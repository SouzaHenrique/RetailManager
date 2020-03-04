using RMDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Helpers
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient apiClient { get; set; }

        public APIHelper()
        {
            InitializeClient();
        }

        /// <summary>
        /// Initializes a new HTPP client and do some tweeks in DefaultRequestHeaders
        /// </summary>
        private void InitializeClient()
        {
            string api = ConfigurationManager.AppSettings["api"];

            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(api);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Makes the call for the API loking for an authentication passing the required arguments
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The Password</param>
        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type","password"),
                new KeyValuePair<string, string>("username",username),
                new KeyValuePair<string, string>("password",password),
            });

            using (HttpResponseMessage response = await apiClient.PostAsync(apiClient.BaseAddress + "/Token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var resut = await response.Content.ReadAsAsync<AuthenticatedUser>();
                    return resut;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
