using System.Numerics;
using System.Runtime.InteropServices;

namespace VoxelTest.Utilities.Mathematics;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct Quad3<T>(Triangle3<T> A, Triangle3<T> B) where T : unmanaged, INumber<T>
{
    
}