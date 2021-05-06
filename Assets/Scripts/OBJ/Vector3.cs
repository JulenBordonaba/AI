using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Obj
{
    /*public class Vector3
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
            w = 1;
        }

        public Vector3(float _x, float _y, float _z)
        {
            z = _z;
            x = _x;
            y = _y;
            w = 1;
        }

        public Vector3(float _x, float _y, float _z, float _w)
        {
            z = _z;
            x = _x;
            y = _y;
            w = _w;
        }

        public void Normalize()
        {
            Vector3 aux = this.Normalized;

            x = aux.x;
            y = aux.y;
            z = aux.z;
        }

        public static float Distance(Vector3 v1, Vector3 v2)
        {
            return (v1 - v2).Magnitude;
        }

        public static Vector3 One
        {
            get { return new Vector3(1, 1, 1); }
        }

        public static Vector3 Zero
        {
            get { return new Vector3(0, 0, 0); }
        }

        public static Vector3 Up
        {
            get
            {
                return new Vector3(0, 1, 0);
            }
        }

        public static Vector3 Right
        {
            get
            {
                return new Vector3(1, 0, 0);
            }
        }

        public static Vector3 Forward
        {
            get
            {
                return new Vector3(0, 0, 1);
            }
        }

        public static Vector3 CrossProduct(Vector3 v1, Vector3 v2)
        {
            Vector3 v = new Vector3();
            v.x = v1.y * v2.z - v1.z * v2.y;
            v.y = v1.z * v2.x - v1.x * v2.z;
            v.z = v1.x * v2.y - v1.y * v2.x
;
            return v;
        }

        public static float Dot(Vector3 v1, Vector3 v2)
        {
            return (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);
        }

        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(Vector3.Dot(this, this));
            }
        }

        public Vector3 Normalized
        {
            get
            {
                Vector3 v = new Vector3(x, y, z);
                float scale = 1f / v.Magnitude;

                v.x *= scale;
                v.y *= scale;
                v.z *= scale;

                return v;
            }

        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3 operator *(Vector3 v, Matrix m)
        {
            Matrix m2 = new Matrix();
            m2.matrix = new float[1, 4] { { v.x, v.y, v.z, v.w } };

            Matrix aux = m2 * m;

            return new Vector3(aux.matrix[0, 0], aux.matrix[0, 1], aux.matrix[0, 2], aux.matrix[0, 3]);
        }

        public static Vector3 operator *(Vector3 v, float f)
        {
            return new Vector3(v.x * f, v.y * f, v.z * f);
        }

        public static Vector3 operator /(Vector3 v, float f)
        {
            return new Vector3(v.x / f, v.y / f, v.z / f);
        }

        public override string ToString()
        {
            return string.Format("<{0}    {1}    {2}>", x, y, z);
        }
    }*/
}
