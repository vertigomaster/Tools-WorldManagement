using IDEK.Tools.WorldManagement.CoreLib.AsyncWorld;
using System.Collections.Generic;
using System.Linq;

namespace IDEK.Tools.WorldManagement.CoreLib.Tiles
{
    public abstract class Tile { }

    public abstract class NonReflexiveTile<TRawSpaceType, TTileIndexType>
    {
        public TTileIndexType TileIndex { get; set; }
        public TRawSpaceType RawPosition { get; set; }

        public abstract bool IsValid { get; }
    }

    /// <summary>
    /// Represents a tile or node in the space that the WFC algorithm is running in.
    /// Unllike <see cref="Tile{TRawSpaceType, TTileIndexType}"/>, this type CAN refer to its own type, via <see cref="TTileRuntimeType"/>.
    /// </summary>
    public abstract class Tile<TRawSpaceType, TTileIndexType, TTileRuntimeType> : NonReflexiveTile<TRawSpaceType, TTileIndexType>
        where TTileRuntimeType : Tile<TRawSpaceType, TTileIndexType, TTileRuntimeType>
    {
        public HashSet<TTileRuntimeType> Neighbors { get; set; }

        public World<TRawSpaceType, TTileIndexType,TTileRuntimeType> World { get; set; }

        public abstract void RefreshNeighbors();

        //public Tile(World<TRawSpaceType, TTileIndexType, TTileRuntimeType> world,
        //    TRawSpaceType position, 
        //    TTileIndexType index, 
        //    IEnumerable<TTileRuntimeType> neighbors)
        //{
        //    World = world;
        //    RawPosition = position;
        //    TileIndex = index;
        //    Neighbors = neighbors.ToHashSet();
        //}
    }

    public abstract class ChunkTile<TRawSpaceType, TTileIndexType, TTileRuntimeType> : Tile<TRawSpaceType, TTileIndexType, TTileRuntimeType>, IChunkElement<TRawSpaceType, TTileIndexType, TTileRuntimeType>
        where TTileRuntimeType : ChunkTile<TRawSpaceType, TTileIndexType, TTileRuntimeType>
    {
        public Chunk<TRawSpaceType, TTileIndexType, TTileRuntimeType> Chunk { get; internal set; }
    }

}
