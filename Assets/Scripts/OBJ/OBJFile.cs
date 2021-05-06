using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Obj
{
    [Serializable]
    [SerializeField]
    public class OBJFile
    {
        public string name;



        public List<Vector3> vertexPositions = new List<Vector3>();
        public List<Vector3> normals = new List<Vector3>();
        public List<Face> faces = new List<Face>();
        public List<Vector2> texCoord = new List<Vector2>();
        

        public string GetGetDataAsString(string path)
        {
            StreamReader file = new StreamReader(path);

            string line = "";

            string txt = "";

            while ((line = file.ReadLine()) != null)
            {
                txt += line;
                txt += "***";
            }


            file.Close();

            return txt;
        }

        public void LoadFromString(string data)
        {
            string[] substrings = data.Split(new string[]{"***"}, StringSplitOptions.None);

            foreach(string line in substrings)
            {
                ProcessLine(line);
            }
            GetTriangles();
        }

        public void Load(string path)
        {
            
            StreamReader file = new StreamReader(path);

            string line = "";

            while ((line = file.ReadLine()) != null)
            {
                ProcessLine(line);
            }
            GetTriangles();
            
            file.Close();
        }

        
        
        public void GetTriangles()
        {
            List<Face> aux = new List<Face>();
            foreach (Face f in faces)
            {
                if (f.vertices.Count > 3)
                {
                    if (f.triangles != null)
                    {
                        foreach (Face t in f.triangles)
                        {
                            aux.Add(t);
                        }
                    }
                }
                else
                {
                    aux.Add(f);
                }
            }

            faces = aux;
        }

        private void ProcessLine(string line)
        {
            string[] substrings = line.Split(new char[] { ' ' });

            if (substrings.Length <= 0) return;

            switch (substrings[0])
            {
                case "v":

                    vertexPositions.Add(LoadVertexPosition(substrings));

                    break;

                case "vt":

                    texCoord.Add(LoadVertexTexCoord(substrings));

                    break;

                case "vn":

                    normals.Add(LoadVertexNormal(substrings));

                    break;
                case "f":

                    faces.Add(LoadFace(substrings));

                    break;
                case "o":
                    if (substrings.Length > 1)
                    {
                        name = substrings[1];
                    }
                    break;
                default:
                    break;
            }
        }


        private Face LoadFace(String[] parts)
        {
            int numberOfVertices = parts.Length - 1;
            String part;
            string[] indices = new string[numberOfVertices];
            for (int i = 0; i < numberOfVertices; i++)
            {
                part = parts[i + 1];

                indices[i] = part;
            }
            Face face = new Face(indices, this);
            return face;
        }

        private Vector3 LoadVertexPosition(string[] vertexData)
        {

            //Console.WriteLine(vertexData[1]);

            for (int i = 1; i < vertexData.Length; i++)
            {
                string aux = "";
                for (int j = 0; j < vertexData[i].Length; j++)
                {
                    if (vertexData[i][j] == '.')
                    {
                        aux += ',';
                    }
                    else
                    {
                        aux += vertexData[i][j];
                    }
                }
                vertexData[i] = aux;
            }

            Vector3 v = new Vector3(Convert.ToSingle(vertexData[1]), Convert.ToSingle(vertexData[2]), Convert.ToSingle(vertexData[3]));

            return v;
        }

        private Vector3 LoadVertexNormal(string[] vertexData)
        {

            //Console.WriteLine(vertexData[1]);

            for (int i = 1; i < vertexData.Length; i++)
            {
                string aux = "";
                for (int j = 0; j < vertexData[i].Length; j++)
                {
                    if (vertexData[i][j] == '.')
                    {
                        aux += ',';
                    }
                    else
                    {
                        aux += vertexData[i][j];
                    }
                }
                vertexData[i] = aux;
            }

            Vector3 v = new Vector3(Convert.ToSingle(vertexData[1]), Convert.ToSingle(vertexData[2]), Convert.ToSingle(vertexData[3]));

            return v;
        }

        private Vector2 LoadVertexTexCoord(string[] vertexData)
        {

            //Console.WriteLine(vertexData[1]);

            for (int i = 1; i < vertexData.Length; i++)
            {
                string aux = "";
                for (int j = 0; j < vertexData[i].Length; j++)
                {
                    if (vertexData[i][j] == '.')
                    {
                        aux += ',';
                    }
                    else
                    {
                        aux += vertexData[i][j];
                    }
                }
                vertexData[i] = aux;
            }

            Vector2 v = new Vector2(Convert.ToSingle(vertexData[1]), Convert.ToSingle(vertexData[2]));

            return v;
        }

        public Vector3 Center
        {
            get
            {
                Vector3 aux = Vector3.zero;

                foreach(Vector3 v in vertexPositions)
                {
                    aux += v;
                }

                aux /= vertexPositions.Count;

                return aux;
            }
        }

        public override string ToString()
        {
            return string.Format("Vertex number: {0}\nFace number: {1}", vertexPositions.Count, faces.Count);
        }
    }
}
