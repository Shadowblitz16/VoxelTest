using System.Numerics;
using System.Runtime.InteropServices;

namespace VoxelTest.Utilities.Mathematics;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct Quad2<T>(Triangle2<T> A, Triangle2<T> B) where T : unmanaged, INumber<T>
{
    
}