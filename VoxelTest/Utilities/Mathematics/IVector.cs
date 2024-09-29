using System.Numerics;

namespace VoxelTest.Utilities.Mathematics;

public interface IVector<TSelf, T> where TSelf : IVector<TSelf, T> where T : unmanaged, INumber<T>
{
    public static abstract T     Length (TSelf self);
    public static abstract TSelf Normal (TSelf self);
    
    public static abstract TSelf Min (TSelf self, TSelf other);
    public static abstract TSelf Max (TSelf self, TSelf other);
    public static abstract TSelf Abs (TSelf self);
    public static abstract TSelf Sign(TSelf self);
    public static abstract TSelf Clamp(TSelf self, TSelf min, TSelf max);
}

