using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using NetTopologySuite.Operation.Buffer;
using System;
using System.Linq;

namespace ZESoft.Services.GeofenceService.Abstractions
{
    public class Geofence
    {
        /// <summary>
        /// Gets the geometry of the geofence.
        /// </summary>
        /// <value>The geometry of the geofence.</value>
        public Polygon Geometry { get; }
        /// <summary>
        /// Gets the name of the geofence.
        /// </summary>
        /// <value>The name of the geofence.</value>
        public string Name { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CaiMCT.Clients.Portable.Geofence"/> is inside.
        /// </summary>
        /// <value><c>true</c> if is inside; otherwise, <c>false</c>.</value>
        public bool IsInside { get; internal set; }

        private double metersToBufferDistanceConversionFactor = 1.0 / 213000;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CaiMCT.Clients.Portable.Geofence"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="geometry">Geometry.</param>
        public Geofence(string name, Polygon geometry)
        {
            Geometry = geometry;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CaiMCT.Clients.Portable.Geofence"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="geometryWellKnownText">Geometry well known text.</param>
        public Geofence(string name, string geometryWellKnownText)
        {
            Name = name;

            WKTReader reader = new WKTReader();
            GeoAPI.Geometries.IGeometry geometry = reader.Read(geometryWellKnownText);

            if (geometry is Polygon)
            {
                Geometry = (Polygon)geometry;
            }
            else
            {
                // for now, can extrude with default settings later
                throw new ArgumentException("Well Known Text does not represent a polygon");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CaiMCT.Clients.Portable.Geofence"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="lineStringWellKnownText">Line string well known text.</param>
        /// <param name="bufferDistance">Buffer distance.</param>
        public Geofence(string name, string lineStringWellKnownText, double bufferDistance)
        {
            Name = name;

            WKTReader reader = new WKTReader();
            LineString lineString = (LineString)reader.Read(lineStringWellKnownText);
            BufferParameters bufferParameters = new BufferParameters(8, GeoAPI.Operation.Buffer.EndCapStyle.Round, GeoAPI.Operation.Buffer.JoinStyle.Round, 5);
            Geometry = (Polygon)lineString.Buffer(bufferDistance * metersToBufferDistanceConversionFactor, bufferParameters);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CaiMCT.Clients.Portable.Geofence"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="polygonBorderCoordinates">Polygon border coordinates.</param>
        public Geofence(string name, GeoAPI.Geometries.Coordinate[] polygonBorderCoordinates)
        {
            Name = name;

            Geometry = new Polygon(new LinearRing(polygonBorderCoordinates));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CaiMCT.Clients.Portable.Geofence"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="lat">Lat.</param>
        /// <param name="lng">Lng.</param>
        /// <param name="meterRadius">Meter radius.</param>
        public Geofence(string name, double lat, double lng, double meterRadius)
        {
            Name = name;

            Point point = new Point(lng, lat);
            BufferParameters bufferParams = new BufferParameters(16, GeoAPI.Operation.Buffer.EndCapStyle.Round, GeoAPI.Operation.Buffer.JoinStyle.Round, meterRadius);
            Polygon polygon = (Polygon)point.Buffer(meterRadius * metersToBufferDistanceConversionFactor, bufferParams);
            Geometry = polygon;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CaiMCT.Clients.Portable.Geofence"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="location">Location.</param>
        /// <param name="meterRadius">Meter radius.</param>
        public Geofence(string name, Point location, double meterRadius)
        {
            Name = name;

            BufferParameters bufferParams = new BufferParameters(16, GeoAPI.Operation.Buffer.EndCapStyle.Round, GeoAPI.Operation.Buffer.JoinStyle.Round, meterRadius);
            Polygon polygon = (Polygon)location.Buffer(meterRadius * metersToBufferDistanceConversionFactor, bufferParams);
            Geometry = polygon;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CaiMCT.Clients.Portable.Geofence"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="coordinate">Coordinate.</param>
        /// <param name="meterRadius">Meter radius.</param>
        public Geofence(string name, GeoAPI.Geometries.Coordinate coordinate, double meterRadius)
        {
            Name = name;

            Point point = new Point(coordinate.X, coordinate.Y);
            BufferParameters bufferParams = new BufferParameters(16, GeoAPI.Operation.Buffer.EndCapStyle.Round, GeoAPI.Operation.Buffer.JoinStyle.Round, meterRadius);
            Polygon polygon = (Polygon)point.Buffer(meterRadius * metersToBufferDistanceConversionFactor, bufferParams);
            Geometry = polygon;
        }

        public GeoAPI.Geometries.Coordinate GetGeometryCenter()
        {
            if (Geometry == null)
            {
                throw new Exception("Geofence has no geometry to get the center of.");
            }

            double x1 = Geometry.Coordinates.Min(c => c.X);
            double y1 = Geometry.Coordinates.Min(c => c.Y);
            double x2 = Geometry.Coordinates.Max(c => c.X);
            double y2 = Geometry.Coordinates.Max(c => c.Y);

            double centerX = x1 + ((x2 - x1) / 2);
            double centerY = y1 + ((y2 - y1) / 2);

            return new GeoAPI.Geometries.Coordinate(centerX, centerY);
        }
    }
}
