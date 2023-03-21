namespace Newshore.UseCase
{
    using Domain;
    using Newshore.UseCase.SearchFlights;
    using NewshoreTest.Code;
    using Newtonsoft.Json;
    using System.Collections.ObjectModel;

    public class Services
    {
        public async  Task<List<SearchFlightsResponse>> GetSearchFlight()
        {
            var urlService = $"{Constants.UrlBase}0";

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, urlService);
                var httpResponse = await client.SendAsync(request);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string response = await httpResponse.Content.ReadAsStringAsync();
                    var resultDeserialize = JsonConvert.DeserializeObject<List<SearchFlightsResponse>>(response);
                    return resultDeserialize;
                }
                else
                {
                    throw new Exception("Error getting flights from API");
                }
            }
        }
    }
}
