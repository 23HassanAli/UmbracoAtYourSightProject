namespace MyProject.Models
{
    public class RootObject
    {
        public Dimensionheader[] DimensionHeaders { get; set; }
        public Metricheader[] MetricHeaders { get; set; }
        public object[] Rows { get; set; }
        public object[] Totals { get; set; }
        public object[] Maximums { get; set; }
        public object[] Minimums { get; set; }
        public int RowCount { get; set; }
        public Metadata Metadata { get; set; }
    }

    public class Metadata
    {
        public bool DataLossFromOtherRow { get; set; }
    }

    public class Dimensionheader
    {
        public string Name { get; set; }
    }

    public class Metricheader
    {
        public string Name { get; set; }
        public int Type { get; set; }
    }

}
