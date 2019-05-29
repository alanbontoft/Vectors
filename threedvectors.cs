using System;

namespace Vectors
{
    public class Vector3D
    {
        private double[] _data = new double[3];

        public Vector3D()
        {
            Load(0.0, 0.0, 0.0);
        }

        public Vector3D(double x, double y, double z)
        {
            Load(x,y,z);
        }

        public Vector3D(double[] values)
        {
            Load(values);
        }

        public void Load(double x, double y, double z)
        {
            _data[0] = x;
            _data[1] = y;
            _data[2] = z;
        }

        public void Load(double[] values)
        {
            if (values.Length != 3) return;

            _data[0] = values[0];
            _data[1] = values[1];
            _data[2] = values[2];
        }

        public double X
        {
            get { return _data[0]; }
        }

        public double Y
        {
            get { return _data[1]; }
        }

        public double Z
        {
            get { return _data[2]; }
        }

        public double Length
        {
            get { return Math.Sqrt((_data[0] * _data[0]) + (_data[1] * _data[1]) + (_data[2] * _data[2])); }
        }
    }
    
    public class VectorClass
    {
        private Vector3D _u = new Vector3D();
        private Vector3D _v = new Vector3D();
        private Vector3D _w = new Vector3D();

        private double _angle;  // angle between u & v

        public Vector3D U
        {
            get { return _u; }
        }

        public Vector3D V
        {
            get { return _v; }
        }

        public Vector3D W
        {
            get { return _w; }
        }

        public double Angle
        {
            get { return _angle; }
        }

        public void Calculate()
        {
            double[] values = new double[3];

            values[0] = (_u.Y * _v.Z) - (_u.Z * _v.Y);
            values[1] = -1.0 * ((_u.X * _v.Z) - (_u.Z * _v.X));
            values[2] = (_u.X * _v.Y) - (_u.Y * _v.X);

            _w.Load(values);

            // calculate angle between u & v
            // cos0 = u x v / |u|.|v|
            double ucrossv = (_u.X * _v.X) + (_u.Y * _v.Y) + (_u.Z * _v.Z);

            _angle = Math.Acos(ucrossv / (_u.Length * _v.Length));

            _angle = (_angle * 180.0) / Math.PI;
        }
    }
}