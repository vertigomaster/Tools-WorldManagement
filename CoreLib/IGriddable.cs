namespace IDEK.Tools.WorldManagement.CoreLib.Grid
{
    public interface IGriddable { }

    public interface I3DGriddable : IGriddable { }
    public interface I2DGriddable : IGriddable { }
    public interface I1DGriddable : IGriddable { }

    public interface I3DGriddable<T> : I2DGriddable<T>, I3DGriddable
        where T : I3DGriddable<T>
    {
        public T Ahead { get; }
        public T Behind { get; }
    }

    public interface I2DGriddable<T> : I1DGriddable<T>, I2DGriddable 
        where T : I2DGriddable<T>
    {
        public T Above { get; }
        public T Below { get; }
    }


    public interface I1DGriddable<T> : I1DGriddable
        where T : I1DGriddable<T>
    {
        public T Right { get; }
        public T Left { get; }
    }
}
