using MyProject.Models;
using Newtonsoft.Json;

namespace MyProject.Repository
{
    public class MockApiRepository
    {
        private HttpClient httpClient;

        public MockApiRepository()
        {
        }
        public async void GetData()
        {
            try
            {
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://63f629b7ab76703b15b97dd7.mockapi.io/api/");
                //httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await httpClient.GetAsync("data/data");

                if (response.IsSuccessStatusCode)
                {
                    var root = new Root();
                    var jsonString = await response.Content.ReadAsStringAsync();
                    root = JsonConvert.DeserializeObject<Root>(jsonString, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                    });
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
