﻿using System;

namespace ObjectDesign.CreatingObjects.Constructors
{
    public class Position
    {
        const float EarthRadiusInKilometers = 6378.0F;

        public Position(float latitude, float longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public float Latitude { get; }
        public float Longitude { get; }

        public float DistanceInKilometersTo(Position position)
        {
            /// Haversine formula
            var latitude = ToRadian(position.Latitude - Latitude);
            var longitude = ToRadian(position.Longitude - Longitude);
            var a = Math.Pow(Math.Sin(latitude / 2), 2) +
                    Math.Cos(ToRadian(Latitude)) *
                    Math.Cos(ToRadian(position.Latitude)) *
                    Math.Pow(Math.Sin(longitude / 2), 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadiusInKilometers * Convert.ToSingle(c);
        }

        private float ToRadian(float value)
        {
            return Convert.ToSingle(Math.PI / 180) * value;
        }
    }
}
