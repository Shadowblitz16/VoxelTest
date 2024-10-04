using System.Numerics;
using System.Runtime.InteropServices;

namespace VoxelTest.Utilities.Mathematics;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct Triangle2<T>(Vector2<T> A, Vector3<T> B, Vector2<T> C) where T : unmanaged, INumber<T>
{
    
}