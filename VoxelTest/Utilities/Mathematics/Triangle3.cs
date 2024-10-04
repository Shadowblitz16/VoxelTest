using System.Numerics;
using System.Runtime.InteropServices;

namespace VoxelTest.Utilities.Mathematics;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct Triangle3<T>(Vector3<T> A, Vector3<T> B, Vector3<T> C) where T : unmanaged, INumber<T>
{
    
}