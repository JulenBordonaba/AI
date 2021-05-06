using System.Collections;
using System.Collections.Generic;


namespace Obj
{
    /*public class Matrix
    {
        public float[,] matrix;

        public Matrix(int height, int width)
        {
            matrix = new float[height, width];
        }

        public Matrix()
        {

        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            int m;
            int n;
            int p;
            int q;

            try
            {
                m = a.matrix.GetLength(0);
            }
            catch
            {
                m = 1;
            }

            try
            {
                n = a.matrix.GetLength(1);
            }
            catch
            {
                n = 1;
            }

            try
            {
                p = b.matrix.GetLength(0);
            }
            catch
            {
                p = 1;
            }

            try
            {
                q = b.matrix.GetLength(1);
            }
            catch
            {
                q = 1;
            }

            if ((m == p) && (n == q))
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        a.matrix[i, j] -= b.matrix[i, j];
                    }
                }
                return a;
            }
            else
            {
                throw new Exception("The size of the 2 matrices should be the same.");
            }


        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            int m;
            int n;
            int p;
            int q;

            try
            {
                m = a.matrix.GetLength(0);
            }
            catch
            {
                m = 1;
            }

            try
            {
                n = a.matrix.GetLength(1);
            }
            catch
            {
                n = 1;
            }

            try
            {
                p = b.matrix.GetLength(0);
            }
            catch
            {
                p = 1;
            }

            try
            {
                q = b.matrix.GetLength(1);
            }
            catch
            {
                q = 1;
            }

            if ((m == p) && (n == q))
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        a.matrix[i, j] += b.matrix[i, j];
                    }
                }
                return a;
            }
            else
            {
                throw new Exception("The size of the 2 matrices should be the same.");
            }


        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            int m;
            int n;
            int p;
            int q;

            try
            {
                m = a.matrix.GetLength(0);
            }
            catch
            {
                m = 1;
            }

            try
            {
                n = a.matrix.GetLength(1);
            }
            catch
            {
                n = 1;
            }

            try
            {
                p = b.matrix.GetLength(0);
            }
            catch
            {
                p = 1;
            }

            try
            {
                q = b.matrix.GetLength(1);
            }
            catch
            {
                q = 1;
            }

            if (n != p)
            {
                throw new Exception("The length of the width matrix and the height of the second should be the same.");
            }
            else
            {
                Matrix c = new Matrix();
                c.matrix = new float[m, q];

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < q; j++)
                    {
                        c.matrix[i, j] = 0;
                        for (int k = 0; k < n; k++)
                        {
                            c.matrix[i, j] += a.matrix[i, k] * b.matrix[k, j];
                        }
                    }
                }

                return c;
            }

        }

        public static Matrix operator *(Matrix a, float b)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    a.matrix[i, j] *= b;
                }
            }

            return a;
        }

        public static Matrix Translation(float x, float y, float z)
        {
            Matrix m = new Matrix();

            m.matrix = new float[4, 4]
            {
                {1,0,0,0 },
                { 0,1,0,0},
                {0,0,1,0 },
                {x,y,z,1 }
            };

            return m;

        }

        public static Matrix MakeRotationX(float angleRad)
        {
            Matrix m = new Matrix();

            m.matrix = new float[4, 4]
            {
                {1,0,0,0 },
                { 0,(float)Math.Cos(angleRad),(float)Math.Sin(angleRad),0},
                {0,(float)-Math.Sin(angleRad),(float)Math.Cos(angleRad),0 },
                {0,0,0,1 }
            };

            return m;

        }

        public static Matrix MakeRotationY(float angleRad)
        {
            Matrix m = new Matrix();

            m.matrix = new float[4, 4]
            {
                {(float)Math.Cos(angleRad),0,(float)Math.Sin(angleRad),0 },
                { 0,1,0,0},
                {(float)-Math.Sin(angleRad),0,(float)Math.Cos(angleRad),0 },
                {0,0,0,1 }
            };

            return m;

        }

        public static Matrix MakeRotationZ(float angleRad)
        {
            Matrix m = new Matrix();

            m.matrix = new float[4, 4]
            {
                {(float)Math.Cos(angleRad),(float)Math.Sin(angleRad),0,0 },
                { (float)-Math.Sin(angleRad),(float)Math.Cos(angleRad),0,0},
                {0,0,1,0 },
                {0,0,0,1 }
            };

            return m;

        }

        public static Matrix MakeIdentity(int length)
        {
            Matrix m = new Matrix();
            m.matrix = new float[length, length];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i == j)
                    {
                        m.matrix[i, j] = 1f;
                    }
                    else
                    {
                        m.matrix[i, j] = 0f;
                    }
                }
            }

            return m;
        }

        public static Matrix ProjectionMatrix
        {
            get
            {
                float aspect = (float)Camera.instance.width / (float)Camera.instance.height;

                float fovRad = 1f / ((float)Math.Tan(Camera.instance.fov / 360f * 2 * Math.PI));

                Matrix projectionMatrix = new Matrix();
                projectionMatrix.matrix = new float[4, 4]
                { {aspect*fovRad, 0f, 0f, 0f },
                  {0f, fovRad,0f,0f },
                  {0f,0f,Camera.instance.far / (Camera.instance.far * Camera.instance.near),1f },
                  {0f,0f,(-Camera.instance.far * Camera.instance.near) / (Camera.instance.far - Camera.instance.near),0f }
                };
                return projectionMatrix;

            }
        }

        public static Matrix CameraMatrix
        {
            get
            {
                return PointAt(Camera.instance.position, Camera.instance.Target, new Vector3(0, 1, 0, 1));
            }
        }

        public static Matrix ViewMatrix
        {
            get
            {
                return Matrix_QuickInverse(CameraMatrix);
            }
        }

        public float Determinant
        {
            get
            {
                if (matrix == null)
                {
                    throw new Exception("You dont have declared the matrix");
                }

                int m;
                int n;

                try
                {
                    m = matrix.GetLength(0);
                }
                catch
                {
                    m = 1;
                }

                try
                {
                    n = matrix.GetLength(1);
                }
                catch
                {
                    n = 1;
                }

                if (m != n)
                {
                    throw new Exception("To do this operation the matrix should be a square matrix");
                }

                if (m == 1) return matrix[0, 0];

                float[] aux = new float[m];

                for (int i = 0; i < m; i++)
                {
                    Matrix subMatrix = new Matrix();
                    subMatrix.matrix = new float[m - 1, m - 1];


                    int x = 0;
                    int y = 0;
                    for (int j = 1; j < m; j++)
                    {
                        for (int k = 0; k < m; k++)
                        {
                            if (k == i)
                            {
                                continue;
                            }
                            else
                            {
                                subMatrix.matrix[y, x] = matrix[j, k];
                            }
                        }
                    }
                    aux[i] = matrix[0, i] * subMatrix.Determinant;

                }

                float result = 0;

                for (int i = 0; i < aux.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        result += aux[i];
                    }
                    else
                    {
                        result -= aux[i];
                    }
                }

                return result;
            }
        }



        public static Matrix PointAt(Vector3 pos, Vector3 target, Vector3 up)
        {
            Vector3 newForward = (target - pos).Normalized;


            Vector3 a = newForward * Vector3.Dot(up, newForward);
            Vector3 newUp = (up - a).Normalized;

            Vector3 newRight = Vector3.CrossProduct(newUp, newForward).Normalized;


            Matrix m = new Matrix();
            m.matrix = new float[4, 4];
            m.matrix[0, 0] = newRight.x; m.matrix[0, 1] = newRight.y; m.matrix[0, 2] = newRight.z; m.matrix[0, 3] = 0.0f;
            m.matrix[1, 0] = newUp.x; m.matrix[1, 1] = newUp.y; m.matrix[1, 2] = newUp.z; m.matrix[1, 3] = 0.0f;
            m.matrix[2, 0] = newForward.x; m.matrix[2, 1] = newForward.y; m.matrix[2, 2] = newForward.z; m.matrix[2, 3] = 0.0f;
            m.matrix[3, 0] = pos.x; m.matrix[3, 1] = pos.y; m.matrix[3, 2] = pos.z; m.matrix[3, 3] = 1.0f;
            return m;
        }

        public static Matrix Matrix_QuickInverse(Matrix m) // Only for Rotation/Translation Matrices
        {
            Matrix matrix = new Matrix();
            matrix.matrix = new float[4, 4];
            matrix.matrix[0, 0] = m.matrix[0, 0]; matrix.matrix[0, 1] = m.matrix[1, 0]; matrix.matrix[0, 2] = m.matrix[2, 0]; matrix.matrix[0, 3] = 0.0f;
            matrix.matrix[1, 0] = m.matrix[0, 1]; matrix.matrix[1, 1] = m.matrix[1, 1]; matrix.matrix[1, 2] = m.matrix[2, 1]; matrix.matrix[1, 3] = 0.0f;
            matrix.matrix[2, 0] = m.matrix[0, 2]; matrix.matrix[2, 1] = m.matrix[1, 2]; matrix.matrix[2, 2] = m.matrix[2, 2]; matrix.matrix[2, 3] = 0.0f;
            matrix.matrix[3, 0] = -(m.matrix[3, 0] * matrix.matrix[0, 0] + m.matrix[3, 1] * matrix.matrix[1, 0] + m.matrix[3, 2] * matrix.matrix[2, 0]);
            matrix.matrix[3, 1] = -(m.matrix[3, 0] * matrix.matrix[0, 1] + m.matrix[3, 1] * matrix.matrix[1, 1] + m.matrix[3, 2] * matrix.matrix[2, 1]);
            matrix.matrix[3, 2] = -(m.matrix[3, 0] * matrix.matrix[0, 2] + m.matrix[3, 1] * matrix.matrix[1, 2] + m.matrix[3, 2] * matrix.matrix[2, 2]);
            matrix.matrix[3, 3] = 1.0f;
            return matrix;
        }



        public override string ToString()
        {
            string s = "";

            int legth1;
            int legth2;

            try
            {
                legth1 = matrix.GetLength(0);
            }
            catch
            {
                legth1 = 1;
            }

            try
            {
                legth2 = matrix.GetLength(1);
            }
            catch
            {
                legth2 = 1;
            }

            for (int i = 0; i < legth1; i++)
            {
                for (int j = 0; j < legth2; j++)
                {
                    s += matrix[i, j] + " ";
                }
                s += "\n";
            }
            return s;
        }
    }*/
}
