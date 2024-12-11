namespace IDEK.Tools.WorldManagement.CoreLib.AsyncWorld
{
    public abstract class ChunkedWorld<TRawSpaceType, TTileIndexType, TTileType> :
        World<TRawSpaceType, TTileIndexType, TTileType>,
        IAsyncWorld<Chunk<TRawSpaceType, TTileIndexType, TTileType>>
    {
        public IChunkLoaderService<Chunk<TRawSpaceType, TTileIndexType, TTileType>> chunkLoader;

        public override bool TryGetTileAtIndex(TTileIndexType newTileIndex, out TTileType tile)
        {
            Chunk<TRawSpaceType, TTileIndexType, TTileType> chunk = GetChunkFromIndex(newTileIndex);
            return chunk.TryGetTileAtWorldSpaceIndex(newTileIndex, out tile);
        }

        public override bool TryGetTileAtRawPosition(TRawSpaceType rawPosition, out TTileType tile)
        {
            Chunk<TRawSpaceType, TTileIndexType, TTileType> chunk = GetChunkFromRawPosition(rawPosition);
            return chunk.TryGetTileContainingRawPosition(rawPosition, out tile);
        }

        public T LoadChunk<T>() where T : Chunk<TRawSpaceType, TTileIndexType, TTileType> => chunkLoader.LoadChunk<T>();
        public void UnloadChunk<T>() where T : Chunk<TRawSpaceType, TTileIndexType, TTileType> => chunkLoader.UnloadChunk<T>();

        public abstract Chunk<TRawSpaceType, TTileIndexType, TTileType> GetChunkFromIndex(TTileIndexType index);
        public abstract Chunk<TRawSpaceType, TTileIndexType, TTileType> GetChunkFromRawPosition(TRawSpaceType rawPosition);
    }
}
