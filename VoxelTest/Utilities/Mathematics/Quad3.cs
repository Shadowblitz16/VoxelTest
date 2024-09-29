using System.Numerics;

namespace VoxelTest.Utilities.Mathematics;

public readonly record struct Quad3<T>(Triangle3<T> A, Triangle3<T> B) where T : unmanaged, INumber<T>
{
    
}