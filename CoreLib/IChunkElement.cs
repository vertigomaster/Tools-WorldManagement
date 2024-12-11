namespace IDEK.Tools.WorldManagement.CoreLib.AsyncWorld
{
    /// <summary>
    /// An empty <see langword="interface"/> for chunk elements, created to get around hiccups with generics. 
    /// <br/>
    /// For implementation, you should instead implement <see cref="IChunkElement{TRawSpaceType, TTileIndexType, TTileRuntimeType}"/>.
    /// </summary>
    public interface IChunkElement { }

    /// <summary>
    /// Represents something that exists within a given world chunk.
    /// </summary>
    /// <typeparam name="TRawSpaceType"></typeparam>
    /// <typeparam name="TTileIndexType"></typeparam>
    /// <typeparam name="TTileRuntimeType"></typeparam>
    public interface IChunkElement<TRawSpaceType, TTileIndexType, TTileRuntimeType> : IChunkElement
    {
        Chunk<TRawSpaceType, TTileIndexType, TTileRuntimeType> Chunk { get; }
    }
}