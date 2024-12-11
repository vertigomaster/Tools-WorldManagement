namespace IDEK.Tools.WorldManagement.CoreLib.AsyncWorld
{
    public interface IChunkLoaderService<TChunkType> where TChunkType : class
    {
        //chunk data must be stored on disk by default and loaded in as needed to avoid overwhelming/hogging RAM

        public T LoadChunk<T>() where T : TChunkType;
        public void UnloadChunk<T>() where T : TChunkType;

    }
}
