using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;
using ZESoft.Services.GeofenceService.Abstractions;

namespace ZESoft.Services.GeofenceService.Forms
{
    public class GeofenceManagerService : IGeofenceManagerService
    {
        public List<Geofence> Geofences => geofences;
        List<Geofence> geofences { get; set; } = new List<Geofence>();

        public event EventHandler<GeofenceEnteredEventArgs> OnEnteredGeofence;

        public event EventHandler<GeofenceExitedEventArgs> OnExitedGeofence;

        public event EventHandler<GeofenceStillInsideEventArgs> OnStillInsideGeofence;

        public event EventHandler<GeofenceStillOutsideEventArgs> OnStillOutsideGeofence;

        void IGeofenceManagerService.SubscribeGeofence(Geofence newGeofence) => geofences.Add(newGeofence);

        void IGeofenceManagerService.UnsubscribeGeofence(Geofence geofence) => geofences.Remove(geofence);

        void IGeofenceManagerService.UpdateGeofences(double lat, double lng, DateTime locationTimeStamp) =>
            this.UpdateGeofences(new Point(lng, lat), locationTimeStamp);

        void UpdateGeofences(Point location, DateTime? triggerTime = null)
        {
            foreach (Geofence geofence in geofences)
            {
                // If location is inside this geofence...
                if (geofence.Geometry.Contains(location))
                {
                    // .. but it wasn't before, update to say it now is and raise the OnEntered event if it has an event handler attached.
                    // Else, it was already in the geofence and now just continues to be in it. Raise the on still inside event.
                    if (!geofence.IsInside)
                    {
                        geofence.IsInside = true;
                        OnEnteredGeofence?.Invoke(this, new GeofenceEnteredEventArgs(geofence, triggerTime ?? DateTime.Now));
                    }
                    else
                    {
                        OnStillInsideGeofence?.Invoke(this, new GeofenceStillInsideEventArgs(geofence));
                    }
                }
                // Otherwise location is not inside this geofence...
                else
                {
                    // .. and if it was before, update it to say it no longer is and raise the OnExited event if it has an event handler attached.
                    // Else, it was not in the geofence and it continues to not be in it. Currently no event is raised for this case.
                    if (geofence.IsInside)
                    {
                        geofence.IsInside = false;
                        OnExitedGeofence?.Invoke(this, new GeofenceExitedEventArgs(geofence, triggerTime ?? DateTime.Now));
                    }
                    else
                    {
                        OnStillOutsideGeofence?.Invoke(this, new GeofenceStillOutsideEventArgs(geofence));
                    }
                }
            }
        }
    }
}
