using IDEK.Tools.WorldManagement.CoreLib.Tiles;
using System;

namespace IDEK.Tools.WorldManagement.CoreLib
{
    //Uncertain if still need this, but don't want to keep deleting and re-creating it
    public abstract class World { }

    /// <summary>
    /// Inherit this for actual implementations.
    /// </summary>
    /// <remarks>
    /// Only SOME world types will require/utilizing chunking,
    /// and that is an implementation-specific distinction, 
    /// which therefore shouldn't be directly coupled to this ancestor class.
    /// </remarks>
    /// <typeparam name="TRawSpaceType"></typeparam>
    /// <typeparam name="TTileIndexType"></typeparam>
    /// <typeparam name="TTileType"></typeparam>
    public abstract class World<TRawSpaceType, TTileIndexType, TTileType> : World
    {
        public virtual bool TryGetTileAtRawPosition(TRawSpaceType rawPosition, out TTileType tile)
        {
            TTileIndexType index = GetTileContainingRawPosition(rawPosition);
            return TryGetTileAtIndex(index, out tile);
        }

        public abstract TTileIndexType GetTileContainingRawPosition(TRawSpaceType rawPosition);
        public abstract bool TryGetTileAtIndex(TTileIndexType newTileIndex, out TTileType tile);

        //Be sure to set up scrobs that interface with something like SQLLite, LiteDB, or some other database structure
    }
}
