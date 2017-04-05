using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Foodyism.Infrastructure.Spoonacular
{
	public class RestResponse<T> {
		public bool IsSuccessful { get; set; }
		public System.Net.HttpStatusCode Code { get; set; }
		public T Body { get; set; }
	}
}
