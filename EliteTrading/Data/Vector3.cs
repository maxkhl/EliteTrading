using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTrading.Data
{
    public struct Vector3
    {
        public double X;
        public double Y;
        public double Z;

        public double Length
        {
            get
            {
                return Math.Sqrt(
                    Math.Pow(X, 2) +
                    Math.Pow(Y, 2) +
                    Math.Pow(Z, 2));
            }
        }

        public Vector3(double Value)
        {
            this.X = Value;
            this.Y = Value;
            this.Z = Value;
        }
        public Vector3(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        static public explicit operator Vector3(string Text)
        {
            var Parts = Text.Split(';');
            return new Vector3(
                double.Parse(Parts[0]), 
                double.Parse(Parts[1]), 
                double.Parse(Parts[2]));
        }

        static public explicit operator string(Vector3 Vector)
        {
            return string.Format("{0}; {1}; {2}", Vector.X.ToString(), Vector.Y.ToString(), Vector.Z.ToString());
        }


        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }
        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;
        }
        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            return v1.X != v2.X || v1.Y != v2.Y || v1.Z != v2.Z;
        }

        public override string ToString()
        {
            return string.Format("{0}; {1}; {2}", this.X.ToString(), this.Y.ToString(), this.Z.ToString());
        }

        public Data.Vector3 RotateX(double degrees)
        {
            //Here we use Euler's matrix formula for rotating a 3D point x degrees around the x-axis

            //[ a  b  c ] [ x ]   [ x*a + y*b + z*c ]
            //[ d  e  f ] [ y ] = [ x*d + y*e + z*f ]
            //[ g  h  i ] [ z ]   [ x*g + y*h + z*i ]

            //[ 1    0        0   ]
            //[ 0   cos(x)  sin(x)]
            //[ 0   -sin(x) cos(x)]

            double cDegrees = (Math.PI * degrees) / 180.0f; //Convert degrees to radian for .Net Cos/Sin functions
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            double y = (this.Y * cosDegrees) + (this.Z * sinDegrees);
            double z = (this.Y * -sinDegrees) + (this.Z * cosDegrees);

            return new Data.Vector3(this.X, y, z);
        }

        public Data.Vector3 RotateY(double degrees)
        {
            //Y-axis

            //[ cos(x)   0    sin(x)]
            //[   0      1      0   ]
            //[-sin(x)   0    cos(x)]

            double cDegrees = (Math.PI * degrees) / 180.0; //Radians
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            double x = (this.X * cosDegrees) + (this.Z * sinDegrees);
            double z = (this.X * -sinDegrees) + (this.Z * cosDegrees);

            return new Data.Vector3(x, this.Y, z);
        }

        public Data.Vector3 RotateZ(double degrees)
        {
            //Z-axis

            //[ cos(x)  sin(x) 0]
            //[ -sin(x) cos(x) 0]
            //[    0     0     1]

            double cDegrees = (Math.PI * degrees) / 180.0; //Radians
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            double x = (this.X * cosDegrees) + (this.Y * sinDegrees);
            double y = (this.X * -sinDegrees) + (this.Y * cosDegrees);

            return new Data.Vector3(x, y, this.Z);
        }
    }
}
