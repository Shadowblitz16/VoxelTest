using System.Numerics;

namespace VoxelTest.Utilities.Mathematics;

public readonly record struct Quad2<T>(Triangle2<T> A, Triangle2<T> B) where T : unmanaged, INumber<T>
{
    
}