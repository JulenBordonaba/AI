using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obj
{
    [System.Serializable]
    [SerializeField]
    public class Face
    {

        OBJFile myObject;

        int[] vertexIndex;
        int[] texCoordIndex;
        int[] normalIndex;

        public List<Vertex> vertices = new List<Vertex>();

        public List<Face> triangles;


        public bool isReversed = false;

        public Face(Vertex[] _vertices, OBJFile _myObject)
        {
            vertices = new List<Vertex>(_vertices);
            myObject = _myObject;

            if (_vertices.Length > 3)
            {
                triangles = new List<Face>();

                for (int i = 1; i < vertices.Count - 1; i++)
                {
                    Vertex[] triangleIndexes = new Vertex[3];
                    
                    triangleIndexes[0] = vertices[0];
                    triangleIndexes[2] = vertices[i];
                    triangleIndexes[1] = vertices[i + 1];


                    triangles.Add(new Face(triangleIndexes, myObject));

                }
            }

        }

        public Face(string[] indices, OBJFile _myObject)
        {
            vertexIndex = new int[indices.Length];
            texCoordIndex = new int[indices.Length];
            normalIndex = new int[indices.Length];

            myObject = _myObject;

            for (int i = 0; i < indices.Length; i++)
            {
                string[] subParts = indices[i].Split(new char[] { '/' });
                vertexIndex[i] = int.Parse(subParts[0]) - 1;
                texCoordIndex[i] = int.Parse(subParts[0]) - 1;
                normalIndex[i] = int.Parse(subParts[0]) - 1;
            }


            LoadVertexData(vertexIndex.Length);




            if (indices.Length > 3)
            {
                triangles = new List<Face>();

                for (int i = 1; i < vertices.Count - 1; i++)
                {
                    Vertex[] triangleIndexes = new Vertex[3];
                    
                    triangleIndexes[0] = vertices[0];
                    triangleIndexes[2] = vertices[i];
                    triangleIndexes[1] = vertices[i + 1];

                    triangles.Add(new Face(triangleIndexes, myObject));

                }
            }


        }
        
        private void LoadVertexData(int vertexNum)
        {
            vertices.Clear();
            for (int i = 0; i < vertexNum; i++)
            {
                vertices.Add(new Vertex(myObject.vertexPositions[vertexIndex[i]], myObject.texCoord[texCoordIndex[i]], myObject.normals[normalIndex[i]]));
            }
        }
        
        /*public Vector3 Normal
        {
            get
            {
                Vector3 a = vertices[1].position - vertices[0].position;
                Vector3 b = vertices[2].position - vertices[0].position;

                return Vector3.CrossProduct(a, b);
            }
        }*/



        public override string ToString()
        {

            string indicesText = "";

            foreach (int i in vertexIndex)
            {
                indicesText += i.ToString() + " ";
            }

            return string.Format("Indices: {0}", indicesText);
        }
    }
}