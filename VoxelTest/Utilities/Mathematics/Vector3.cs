using System.Numerics;
using Silk.NET.Maths;

namespace VoxelTest.Utilities.Mathematics;

public readonly record struct Vector3<T>(T X, T Y, T Z) :
    IComparisonOperators <Vector3<T>, Vector3<T>, bool>,
    IAdditionOperators   <Vector3<T>, Vector3<T>, Vector3<T>>,
    ISubtractionOperators<Vector3<T>, Vector3<T>, Vector3<T>>,
    IMultiplyOperators   <Vector3<T>, Vector3<T>, Vector3<T>>,
    IDivisionOperators   <Vector3<T>, Vector3<T>, Vector3<T>>,
    IModulusOperators    <Vector3<T>, Vector3<T>, Vector3<T>>,
    IMultiplyOperators   <Vector3<T>, T, Vector3<T>>,
    IDivisionOperators   <Vector3<T>, T, Vector3<T>>,
    IModulusOperators    <Vector3<T>, T, Vector3<T>>,
    IVector<Vector3<T>, T>  
    where T : unmanaged, INumber<T>
{

    public static  Vector3<T> One   { get; } = new(T.One , T.One , T.One );
    public static  Vector3<T> Zero  { get; } = new(T.Zero, T.Zero, T.Zero);
    public static  Vector3<T> UnitX { get; } = new(T.One , T.Zero, T.Zero);
    public static  Vector3<T> UnitY { get; } = new(T.Zero, T.One , T.Zero);
    public static  Vector3<T> UnitZ { get; } = new(T.Zero, T.Zero, T.One );
    
    public static bool operator >=(Vector3<T> left, Vector3<T> right)
    {
        return left.X >= right.X && left.Y >= right.Y && left.Z >= right.Z;
    }
    public static bool operator <=(Vector3<T> left, Vector3<T> right)
    {
        return left.X <= right.X && left.Y <= right.Y && left.Z <= right.Z;
    }
    public static bool operator > (Vector3<T> left, Vector3<T> right)
    {
        return left.X > right.X && left.Y > right.Y && left.Z > right.Z;
    }
    public static bool operator < (Vector3<T> left, Vector3<T> right)
    {
        return left.X < right.X && left.Y < right.Y && left.Z < right.Z;
    }
    
    public static Vector3<T> operator +(Vector3<T> left, Vector3<T> right)
    {
        return new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
    }
    public static Vector3<T> operator -(Vector3<T> left, Vector3<T> right)
    {
        return new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
    }
    public static Vector3<T> operator *(Vector3<T> left, Vector3<T> right)
    {
        return new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
    }
    public static Vector3<T> operator /(Vector3<T> left, Vector3<T> right)
    {
        return new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
    }
    public static Vector3<T> operator %(Vector3<T> left, Vector3<T> right)
    {
        return new(left.X % right.X, left.Y % right.Y, left.Z % right.Z);
    }
   
    public static Vector3<T> operator *(Vector3<T> left, T right)
    {
        return new(left.X * right, left.Y * right, left.Z * right);
    }
    public static Vector3<T> operator /(Vector3<T> left, T right)
    {
        return new(left.X / right, left.Y / right, left.Z / right);
    }
    public static Vector3<T> operator %(Vector3<T> left, T right)
    {
        return new(left.X % right, left.Y % right, left.Z % right);
    }
    
    public Vector3<TResult> As<TResult>() where TResult : unmanaged, INumber<TResult>
    {
        return new(TResult.CreateTruncating(X), TResult.CreateTruncating(Y), TResult.CreateTruncating(Z));
    }
    public static implicit operator Vector2<T>(Vector3<T> value) => new(value.X, value.Y);
    public static implicit operator Vector3(Vector3<T> v) => new(float.CreateSaturating(v.X), float.CreateSaturating(v.Y), float.CreateSaturating(v.Z));
    public static implicit operator Vector3<T>(Vector3 v) => new(T.CreateSaturating(v.X), T.CreateSaturating(v.Y), T.CreateSaturating(v.Z));
    public static implicit operator Vector3D<T>(Vector3<T> v) => new(T.CreateSaturating(v.X), T.CreateSaturating(v.Y), T.CreateSaturating(v.Z));
    public static implicit operator Vector3<T>(Vector3D<T> v) => new(T.CreateSaturating(v.X), T.CreateSaturating(v.Y), T.CreateSaturating(v.Z));


    public static T          Length(Vector3<T> self)
    {
        return T.CreateTruncating(double.Sqrt(double.CreateChecked(self.X * self.X) +
                                              double.CreateChecked(self.Y * self.Y) +
                                              double.CreateChecked(self.Z * self.Z)));
    }
    public static Vector3<T> Normal(Vector3<T> self)
    {
        return self / Length(self);
    }

    public static Vector3<T> Min(Vector3<T> self, Vector3<T> other)
    {
        return new(T.Min(self.X, other.X), T.Min(self.Y, other.Y), T.Min(self.Z, other.Z));
    }
    public static Vector3<T> Max(Vector3<T> self, Vector3<T> other)
    {
        return new(T.Max(self.X, other.X), T.Max(self.Y, other.Y), T.Max(self.Z, other.Z));
    }
    public static Vector3<T> Abs(Vector3<T> self)
    {
       return new (T.Abs(self.X), T.Abs(self.Y), T.Abs(self.Z));
    }
    public static Vector3<T> Sign(Vector3<T> self)
    {
        return new (T.CreateChecked(T.Sign(self.X)), T.CreateChecked(T.Sign(self.Y)), T.CreateChecked(T.Sign(self.Z)));
    }
    public static Vector3<T> Clamp(Vector3<T> self, Vector3<T> min, Vector3<T> max)
    {
        return new(T.Clamp(self.X, min.X, max.X), T.Clamp(self.Y, min.Y, max.Y), T.Clamp(self.Z, min.Z, max.Z));
    }
}

