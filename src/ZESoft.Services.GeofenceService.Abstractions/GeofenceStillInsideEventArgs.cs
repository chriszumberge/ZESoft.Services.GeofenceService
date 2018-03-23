using System;

namespace ZESoft.Services.GeofenceService.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class GeofenceStillInsideEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the geofence that the position is still inside of.
        /// </summary>
        public Geofence Geofence { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="GeofenceStillInsideEventArgs"/> class.
        /// </summary>
        /// <param name="geofence">The geofence.</param>
        internal GeofenceStillInsideEventArgs(Geofence geofence)
        {
            Geofence = geofence;
        }
    }
}
