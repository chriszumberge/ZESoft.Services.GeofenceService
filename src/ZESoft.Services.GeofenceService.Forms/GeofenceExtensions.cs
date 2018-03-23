using System;
using System.Linq;
using ZESoft.Services.GeofenceService.Abstractions;

namespace ZESoft.Services.GeofenceService.Forms
{
    public static class GeofenceExtensions
    {
        public static Xamarin.Forms.Maps.MapSpan GetGeometrySpan(this Geofence geofence)
        {
            if (geofence.Geometry == null)
            {
                throw new Exception("Geofence has no geometry to get the span of.");
            }

            double x1 = geofence.Geometry.Coordinates.Min(c => c.X);
            double y1 = geofence.Geometry.Coordinates.Min(c => c.Y);
            double x2 = geofence.Geometry.Coordinates.Max(c => c.X);
            double y2 = geofence.Geometry.Coordinates.Max(c => c.Y);

            double centerX = x1 + ((x2 - x1) / 2);
            double centerY = y1 + ((y2 - y1) / 2);
            double radius = Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2));

            return Xamarin.Forms.Maps.MapSpan.FromCenterAndRadius(
                new Xamarin.Forms.Maps.Position(centerY, centerX),
                Xamarin.Forms.Maps.Distance.FromMeters((radius / 0.0000089987) + 100));
        }
    }
}
