using Org.BouncyCastle.Asn1;

namespace MyProject.ReadModels
{

    public record Label(string label);
    public record Data(double value);
    public record DataSet(string seriename, List<Data> data);
    public record Chart(
     string caption,
     string subCaption,
     string numberPrefix,
     string theme,
     string radarfillcolor
     );
    public record Category(List<Label> category);

    public record WeatherDataRM(
        Chart chart,
        List<Category> categories,
        List<DataSet> dataset);
}
