using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obj
{
    public class Vertex
    {

        public Vector3 position;
        public Vector3 color;
        public UnityEngine.Vector2 texCoord;
        public Vector3 normal;


        public Vertex(Vector3 _position, UnityEngine.Vector2 _texCoord, Vector3 _normal)
        {
            position = _position;
            texCoord = _texCoord;
            normal = _normal;
        }
        
    }
}