namespace IDEK.Tools.WorldManagement.CoreLib.Tiles
{
    public class TileCursor<TRawSpaceType, TTileIndexType, TTileType> 
        where TTileType : NonReflexiveTile<TRawSpaceType, TTileIndexType>
    {
        public World<TRawSpaceType, TTileIndexType, TTileType> world;

        public TRawSpaceType rawPosition;
        public TTileType tile;
        public TTileIndexType TileIndex => tile.TileIndex;

        public virtual bool TrySetRawPosition(TRawSpaceType newRawPosition)
        {
            TTileType oldTile = tile;
            
            if(!world.TryGetTileAtRawPosition(newRawPosition, out TTileType newTile)) return false;
            if(!newTile.IsValid) return false;

            tile = newTile;

            rawPosition = newRawPosition;
            OnCursorUpdate(oldTile, tile);

            return true;
        }

        public virtual bool TrySetTileIndex(TTileIndexType newTileIndex) => world.TryGetTileAtIndex(newTileIndex, out TTileType tileAtIndex) && TryMoveTo(tileAtIndex);

        public virtual bool TryMoveTo(TTileType newTile)
        {
            if (newTile == null || !newTile.IsValid) return false;

            TTileType oldTile = tile;
            tile = newTile;
            rawPosition = newTile.RawPosition;
            OnCursorUpdate(oldTile, newTile);

            return true;
        }

        public virtual void OnCursorUpdate(TTileType oldTile, TTileType newTile) { }
    }
}
