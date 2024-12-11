using System;

namespace IDEK.Tools.WorldManagement.CoreLib.Tiles
{
    [Obsolete("Composition is only useful for modular segments. This class's implementation would depend entirely on the World's specific implementation.")]
    /// <summary>
    /// Intended for a concrete implementation to be attached to a relevant World class.
    /// </summary>
    public abstract class TileUtility<TRawSpaceType, TTileIndexType, TTileType>
    {
        protected internal World<TRawSpaceType, TTileIndexType, TTileType> world;

        internal abstract TTileType GetTileAtRawPosition(TRawSpaceType rawPosition);
        internal abstract TTileType GetTileAtIndex(TTileIndexType newTileIndex);
    }
}
