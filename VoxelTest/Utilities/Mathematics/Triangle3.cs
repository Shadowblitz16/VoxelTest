using System.Numerics;

namespace VoxelTest.Utilities.Mathematics;

public readonly record struct Triangle3<T>(Vector3<T> A, Vector3<T> B, Vector3<T> C) where T : unmanaged, INumber<T>
{
    
}