﻿namespace POC.Controllers.Models
{
    public class Coordinate
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Coordinate() { }

        public Coordinate(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
