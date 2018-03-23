using System;
using System.Collections.Generic;

namespace ZESoft.Services.GeofenceService.Abstractions
{
    /// <summary>
    /// Interface for implementing a Geofence Manager Service.
    /// </summary>
    public interface IGeofenceManagerService
    {
        /// <summary>
        /// Gets the geofences.
        /// </summary>
        /// <value>The registered geofences.</value>
        List<Geofence> Geofences { get; }

        /// <summary>
        /// Occurs when [on entered geofence].
        /// </summary>
        /// <seealso cref="GeofenceEnteredEventArgs"/>
        event EventHandler<GeofenceEnteredEventArgs> OnEnteredGeofence;
        /// <summary>
        /// Occurs when [on exited geofence].
        /// </summary>
        /// <seealso cref="GeofenceExitedEventArgs"/>
        event EventHandler<GeofenceExitedEventArgs> OnExitedGeofence;
        /// <summary>
        /// Occurs when [on still inside geofence].
        /// </summary>
        /// <seealso cref="GeofenceStillInsideEventArgs"/>
        event EventHandler<GeofenceStillInsideEventArgs> OnStillInsideGeofence;

        /// <summary>
        /// Occurs when [on still outside geofence].
        /// </summary>
        /// <seealso cref="GeofenceStillOutsideEventArgs"/>
        event EventHandler<GeofenceStillOutsideEventArgs> OnStillOutsideGeofence;

        /// <summary>
        /// Subscribes the geofence.
        /// </summary>
        /// <param name="newGeofence">The new geofence to subscribe.</param>
        void SubscribeGeofence(Geofence newGeofence);
        /// <summary>
        /// Unsubscribes the geofence.
        /// </summary>
        /// <param name="geofence">The geofence to unsubscribe.</param>
        void UnsubscribeGeofence(Geofence geofence);

        /// <summary>
        /// Updates the geofences using the provided position to raise <see cref="OnEnteredGeofence" /> or <see cref="OnExitedGeofence" /> events.
        /// </summary>
        /// <param name="lat">The latitude.</param>
        /// <param name="lng">The longitude.</param>
        /// <param name="locationTimeStamp">The location time stamp.</param>
        //void UpdateGeofences(Plugin.Geolocator.Abstractions.Position position);
        //void UpdateGeofences(Point locationPoint, DateTime locationTimeStamp);
        void UpdateGeofences(double lat, double lng, DateTime locationTimeStamp);
    }
}
