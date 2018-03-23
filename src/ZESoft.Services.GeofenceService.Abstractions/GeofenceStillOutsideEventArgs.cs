using System;
using System.Collections.Generic;
using System.Text;

namespace ZESoft.Services.GeofenceService.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class GeofenceStillOutsideEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the geofence that the position is still outside of.
        /// </summary>
        public Geofence Geofence => geofence;
        Geofence geofence { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="GeofenceStillOutsideEventArgs"/> class.
        /// </summary>
        /// <param name="geofence">The geofence.</param>
        internal GeofenceStillOutsideEventArgs(Geofence geofence)
        {
            this.geofence = geofence;
        }
    }
}
