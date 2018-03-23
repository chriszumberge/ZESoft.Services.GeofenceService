using System;
using System.Collections.Generic;
using System.Text;

namespace ZESoft.Services.GeofenceService.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class GeofenceEnteredEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the geofence that was entered.
        /// </summary>
        /// <value>The geofence.</value>
        public Geofence Geofence { get; }

        /// <summary>
        /// Gets the date time value for when the geofence was entered.
        /// </summary>
        /// <value>The date time entered.</value>
        public DateTime DateTimeEntered { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CaiMCT.Clients.Portable.GeofenceEnteredEventArgs"/> class.
        /// </summary>
        /// <param name="geofence">Geofence.</param>
        /// <param name="dateTimeEntered">Date time entered.</param>
        internal GeofenceEnteredEventArgs(Geofence geofence, DateTime dateTimeEntered)
        {
            Geofence = geofence;
            DateTimeEntered = dateTimeEntered;
        }
    }
}
