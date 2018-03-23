using System;
using System.Collections.Generic;
using System.Text;

namespace ZESoft.Services.GeofenceService.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class GeofenceExitedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the geofence that was exited.
        /// </summary>
        /// <value>The geofence exited.</value>
        public Geofence Geofence { get; }

        /// <summary>
        /// Gets the date time value for when the geofence was exited.
        /// </summary>
        /// <value>The date time exited.</value>
        public DateTime DateTimeExited { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CaiMCT.Clients.Portable.GeofenceExitedEventArgs"/> class.
        /// </summary>
        /// <param name="geofence">Geofence.</param>
        /// <param name="dateTimeExited">Date time exited.</param>
        internal GeofenceExitedEventArgs(Geofence geofence, DateTime dateTimeExited)
        {
            Geofence = geofence;
            DateTimeExited = dateTimeExited;
        }
    }
}
