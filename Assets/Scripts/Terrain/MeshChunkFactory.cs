using Procedural;
using Procedural.Noise;
using Procedural.Terrain;
using UnityEngine;

namespace Grapple.Terrain
{
    public class MeshChunkFactory : IChunkFactory
    {
        private Material _material;

        public MeshChunkFactory(Material material)
        {
            _material = material;
        }
        
        public IChunk CreateChunk(Vector3F position, int width, int height, int depth)
        {
            return new MeshChunk(position, width, height, depth, _material);
        }

        public IChunkGenerator CreateChunkGenerator(Seed seed)
        {
            return new ThreadedChunkGenerator(seed);
        }
    }
}
