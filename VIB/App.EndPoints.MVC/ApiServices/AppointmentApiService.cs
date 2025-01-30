using App.Domain.Core.Entities.Inspection;

namespace App.EndPoints.MVC.ApiServices
{
	public class AppointmentApiService
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiKey;
		private readonly string _apiBaseUrl;

		public AppointmentApiService(HttpClient httpClient,
			IConfiguration configuration)
		{
			_httpClient = httpClient;
			_apiKey = configuration["ApiSettings:ApiKey"];
			_apiBaseUrl = configuration["ApiSettings:ApiBaseUrl"];
		}

		public string GetAppointments()
		{
			var request = new HttpRequestMessage(HttpMethod.Get,
				$"{_apiBaseUrl}/api/Appointment");
			request.Headers.Add( "X-API-Key", _apiKey );
			var response = _httpClient.Send(request);
			return response.Content.ToString();
		}
	}
}
