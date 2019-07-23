namespace LightingSurvey.MvcSite.Services.Postcodes.Model
{
    public class LatLong
    {
        public LatLong(double latitute, double longitude)
        {
            Lat = latitute;
            Long = longitude;
        }

        public double Lat { get; }

        public double Long { get; } 
    }
}
