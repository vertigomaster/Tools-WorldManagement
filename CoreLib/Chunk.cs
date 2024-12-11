namespace IDEK.Tools.WorldManagement.CoreLib.AsyncWorld
{
    /// <summary>
    /// a region unit containing spatially local tiles.
    /// Can be sparse but usually isn't
    /// </summary>
    public abstract class Chunk<TRawSpaceType, TTileIndexType, TTileType>
    {
        public abstract bool TryGetTileAtLocalIndex(TTileIndexType tileIndex, out TTileType tile);
        public abstract bool TryGetTileContainingRawPosition(TRawSpaceType rawPosition, out TTileType tile);
        public abstract bool TryGetTileAtWorldSpaceIndex(TTileIndexType newTileIndex, out TTileType tile);
    }
}
