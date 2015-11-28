using Procedural;
using Procedural.Terrain;
using System.Collections.Generic;
using UnityEngine;

namespace Ares.Components
{
    public class MeshChunk : IChunk
    {
        public Vector3F Position { get { return _position; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
        public int Depth { get { return _depth; } }
        public bool Disposed { get { return _disposed; } }
        
        public float[] Voxels { get; set; }
        public Vector3F[] Vertices { get; set; }
        public int[] Indices { get; set; }

        private Vector3F _position;
        private int _width;
        private int _height;
        private int _depth;
        private bool _disposed;

        private GameObject _gameObject;
        private Mesh _mesh;

        public MeshChunk(Vector3F position, int width, int height, int depth, Material material)
        {
            _position = position;
            _width = width;
            _height = height;
            _depth = depth;
            _disposed = false;

            InitializeGameObject(material);
        }

        private void InitializeGameObject(Material material)
        {
            var name = string.Format("Chunk-{0},{1}", _position.x, _position.z);
            _gameObject = new GameObject(name, typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider));
            _gameObject.GetComponent<MeshRenderer>().material = material;
            _gameObject.transform.position = new Vector3(_position.x, _position.y, _position.z);
        }

        public void Update()
        {
            _mesh = new Mesh();
            _mesh.vertices = Map(Vertices);
            _mesh.triangles = Indices;

            var uv = new List<Vector2>();
		    var texCoord0 = new Vector2(0,0);
            var texCoord1 = new Vector2(0, 1);
            var texCoord2 = new Vector2(1, 1);		
		    for(var i = 0; i < Vertices.Length; i += 3)
            {
                uv.Add(texCoord1);
                uv.Add(texCoord2);
                uv.Add(texCoord0);
		    }
            _mesh.uv = uv.ToArray();

            _mesh.RecalculateNormals();
            _mesh.RecalculateBounds();

            _gameObject.GetComponent<MeshFilter>().mesh = _mesh;
            _gameObject.GetComponent<MeshCollider>().sharedMesh = _mesh;
        }

        public void Dispose()
        {
            _mesh = null;
            GameObject.Destroy(_gameObject);

            _disposed = true;
        }

        private Vector3[] Map(Vector3F[] from)
        {
            var to = new Vector3[from.Length];
            for (var i = 0; i < from.Length; ++i)
            {
                to[i] = new Vector3(from[i].x, from[i].y, from[i].z);
            }
            return to;
        }
    }
}
