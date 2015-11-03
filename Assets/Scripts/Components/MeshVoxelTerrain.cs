using Procedural;
using Procedural.Terrain;
using UnityEngine;

namespace Ares.Components
{
    public class MeshVoxelTerrain : MonoBehaviour
    {
        public int terrainSize = 30;
        public int chunkSize = 15;
        public int chunkHeight = 20;
        public uint numberOfGenerators = 4;
        public Material material;

        private ITerrain _terrain;

        private void Start()
        {
            var camPos = Camera.main.transform.position;
            _terrain = new VoxelTerrain(new MeshChunkFactory(material),
                new Volume(terrainSize, 1, terrainSize),
                new Volume(chunkSize, chunkHeight, chunkSize),
                numberOfGenerators,
                new Vector3F(camPos.x, camPos.y, camPos.z));
        }

        private void Update()
        {
            var camPos = Camera.main.transform.position;
            _terrain.Update(new Vector3F(camPos.x, camPos.y, camPos.z));
        }
    }
}
