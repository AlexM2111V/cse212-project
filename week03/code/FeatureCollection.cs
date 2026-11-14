// These classes mirror the shape of the USGS earthquake JSON.
// Only the fields we need are included; the rest are ignored.
//
// {
//   "features": [
//     { "properties": { "mag": 1.2, "place": "10 km N of Somewhere" } },
//     ...
//   ]
// }

public class FeatureCollection
{
    public List<Feature> Features { get; set; } = [];
}

public class Feature
{
    public EarthquakeProperties Properties { get; set; } = new();
}

public class EarthquakeProperties
{
    // Nullable because some earthquakes in the feed have no magnitude or place
    public double? Mag { get; set; }
    public string? Place { get; set; }
}
