using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Foodyism.Infrastructure.Spoonacular
{
	
	public static class RestHelper<T>
	{
		static HttpClient _httpClient;

		public static HttpClient Client {
			get {
				if (_httpClient != null) return _httpClient;
					_httpClient = new HttpClient();
					_httpClient.DefaultRequestHeaders.Add("X-Mashape-Key", "QsfZxxHbywmshJyuFMPmr7LdDbeWp12EjXrjsniFwhgQHKiK4U");
					_httpClient.DefaultRequestHeaders.Add("Accept","application/json");
					return _httpClient;
				}
		}

		public static async Task<RestResponse<T>> GetAsync(string url)
		{
			var resp = await Client.GetAsync(url);
			return await ProcessResponse(resp);
		}

		public async static Task<RestResponse<T>> ProcessResponse(HttpResponseMessage resp)
		{
			var obj = new RestResponse<T>();
			obj.IsSuccessful = resp.IsSuccessStatusCode;
			obj.Code = resp.StatusCode;
			if (resp.IsSuccessStatusCode)
			{
				obj.Body = JsonConvert.DeserializeObject<T>(await resp.Content.ReadAsStringAsync());
			}
			return obj;
		}
	}
}
