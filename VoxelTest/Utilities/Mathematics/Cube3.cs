using System.Numerics;

namespace VoxelTest.Utilities.Mathematics;

public readonly record struct Cube3<T>(Quad3<T> Left, Quad3<T> Right, Quad3<T> Top, Quad3<T> Bottom, Quad3<T> Front, Quad3<T> Back) where T : unmanaged, INumber<T>
{
    
}