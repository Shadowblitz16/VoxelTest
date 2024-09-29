using System.Numerics;

namespace VoxelTest.Utilities.Mathematics;

public readonly record struct Triangle2<T>(Vector2<T> A, Vector3<T> B, Vector2<T> C) where T : unmanaged, INumber<T>
{
    
}