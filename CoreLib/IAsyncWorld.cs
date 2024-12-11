namespace IDEK.Tools.WorldManagement.CoreLib.AsyncWorld
{
    public interface IAsyncWorld<TChunkType> : IChunkLoaderService<TChunkType> where TChunkType : class { }
}
