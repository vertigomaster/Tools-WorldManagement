using IDEK.Tools.WorldManagement.CoreLib.Tiles;

//namespace IDEK.Tools.WaveFunctionCollapse.World
namespace IDEK.Tools.WorldManagement.CoreLib.Grid
{
    public abstract class GridTile3D<TRawSpaceType, TTileIndexType, TTileType> : Tile<TRawSpaceType, TTileIndexType, TTileType>, I3DGriddable<TTileType>
        where TTileType : GridTile3D<TRawSpaceType, TTileIndexType, TTileType>
    {
        public virtual TTileType Ahead { get; protected set; }
        public virtual TTileType Behind { get; protected set; }
        public virtual TTileType Above { get; protected set; }
        public virtual TTileType Below { get; protected set; }
        public virtual TTileType Right { get; protected set; }
        public virtual TTileType Left { get; protected set; }
    }
}
