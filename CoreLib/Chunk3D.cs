using IDEK.Tools.WorldManagement.CoreLib.Grid;

namespace IDEK.Tools.WorldManagement.CoreLib.AsyncWorld
{
    public abstract class Chunk3D<TRawSpaceType, TTileIndexType, TTileType> : Chunk<TRawSpaceType, TTileIndexType, TTileType>, I3DGriddable
    {
        public abstract I3DGriddable Ahead { get; }
        public abstract I3DGriddable Behind { get; }
        public abstract I3DGriddable Above { get; }
        public abstract I3DGriddable Below { get; }
        public abstract I3DGriddable Right { get; }
        public abstract I3DGriddable Left { get; }
    }
}
