using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.Models.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Ocsp;
using static MyProject.Models.ChartJs;
using System.Text;
using MyProject.ReadModels;

namespace MyProject.Components
{
    [ViewComponent(Name = "chartjs")]
    public class ChartJsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
    //        var client = new HttpClient();
    //        var request = new HttpRequestMessage
    //        {
    //            Method = HttpMethod.Get,
    //            RequestUri = new Uri("https://meteostat.p.rapidapi.com/stations/monthly?station=10637&start=2020-01-01&end=2020-12-31"),
    //            Headers =
    //{
    //    { "X-RapidAPI-Key", "470bf0a141msha0e8d64ae386145p1203b5jsne624adfd06db" },
    //    { "X-RapidAPI-Host", "meteostat.p.rapidapi.com" },
    //},
    //        };
    //        StringBuilder body = new StringBuilder();

    //        using (var response = await client.SendAsync(request))
    //        {

    //            response.EnsureSuccessStatusCode();
    //            body.Append(await response.Content.ReadAsStringAsync());
    //            Console.WriteLine(body);
    //        }

    //        JObject json = JObject.Parse(body.ToString());
    //        JToken dataToken = json["data"];
    //        IEnumerable<JToken> year = dataToken.Children();

    //        List<MyProject.ReadModels.Data> dataForChart = new List<MyProject.ReadModels.Data>();
    //        foreach (var month in year)
    //        {
    //            dataForChart.Add(new MyProject.ReadModels.Data((double)month["tavg"]));
    //        }
    //        var rm = new MyProject.ReadModels.WeatherDataRM(

    //    chart: new Chart(
    //        caption: "Weather in New York",
    //        subCaption: "Based on data collected last year",
    //        numberPrefix: "",
    //        theme: "fusion",
    //        radarfillcolor: "#ffffff"
    //        ),

    //    categories: new List<Category>
    //    {
    //                new Category(
    //                    new List<Label>
    //                    {
    //                        new Label("Jan"),
    //                        new Label("Feb"),
    //                        new Label("Mar"),
    //                        new Label("Apr"),
    //                        new Label("May"),
    //                        new Label("Jun"),
    //                        new Label("Jul"),
    //                        new Label("Jug"),
    //                        new Label("Sep"),
    //                        new Label("Oct"),
    //                        new Label("Nov"),
    //                        new Label("Dec")
    //                    }
    //                    ),
    //    },

    //    dataset: new List<DataSet>
    //    {
    //                new DataSet(
    //                    seriename: "Temperature average",
    //                    dataForChart
    //                    )
    //    }
        //);
            return View();
        }
    }
}
