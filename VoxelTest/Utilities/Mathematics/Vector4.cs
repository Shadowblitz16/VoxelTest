using System.Numerics;
using Silk.NET.Maths;

namespace VoxelTest.Utilities.Mathematics;

public readonly record struct Vector4<T>(T X, T Y, T Z, T W) :
    IComparisonOperators <Vector4<T>, Vector4<T>, bool>,
    IAdditionOperators   <Vector4<T>, Vector4<T>, Vector4<T>>,
    ISubtractionOperators<Vector4<T>, Vector4<T>, Vector4<T>>,
    IMultiplyOperators   <Vector4<T>, Vector4<T>, Vector4<T>>,
    IDivisionOperators   <Vector4<T>, Vector4<T>, Vector4<T>>,
    IModulusOperators    <Vector4<T>, Vector4<T>, Vector4<T>>,
    IMultiplyOperators   <Vector4<T>, T, Vector4<T>>,
    IDivisionOperators   <Vector4<T>, T, Vector4<T>>,
    IModulusOperators    <Vector4<T>, T, Vector4<T>>,
    IVector<Vector4<T>, T>  
    where T : unmanaged, INumber<T>
{

    public static  Vector4<T> One   { get; } = new(T.One , T.One , T.One , T.One );
    public static  Vector4<T> Zero  { get; } = new(T.Zero, T.Zero, T.Zero, T.Zero);
    public static  Vector4<T> UnitX { get; } = new(T.One , T.Zero, T.Zero, T.Zero);
    public static  Vector4<T> UnitY { get; } = new(T.Zero, T.One , T.Zero, T.Zero);
    public static  Vector4<T> UnitZ { get; } = new(T.Zero, T.Zero, T.One , T.Zero);
    public static  Vector4<T> UnitW { get; } = new(T.Zero, T.Zero, T.Zero, T.One );
    
    public static bool operator >=(Vector4<T> left, Vector4<T> right)
    {
        return left.X >= right.X && left.Y >= right.Y && left.Z >= right.Z && left.W >= right.W;
    }
    public static bool operator <=(Vector4<T> left, Vector4<T> right)
    {
        return left.X <= right.X && left.Y <= right.Y && left.Z <= right.Z && left.W <= right.W;
    }
    public static bool operator > (Vector4<T> left, Vector4<T> right)
    {
        return left.X > right.X && left.Y > right.Y && left.Z > right.Z && left.W > right.W;
    }
    public static bool operator < (Vector4<T> left, Vector4<T> right)
    {
        return left.X < right.X && left.Y < right.Y && left.Z < right.Z && left.W < right.W;
    }
    
    public static Vector4<T> operator +(Vector4<T> left, Vector4<T> right)
    {
        return new(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
    }
    public static Vector4<T> operator -(Vector4<T> left, Vector4<T> right)
    {
        return new(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
    }
    public static Vector4<T> operator *(Vector4<T> left, Vector4<T> right)
    {
        return new(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
    }
    public static Vector4<T> operator /(Vector4<T> left, Vector4<T> right)
    {
        return new(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
    }
    public static Vector4<T> operator %(Vector4<T> left, Vector4<T> right)
    {
        return new(left.X % right.X, left.Y % right.Y, left.Z % right.Z, left.W % right.W);
    }
   
    public static Vector4<T> operator *(Vector4<T> left, T right)
    {
        return new(left.X * right, left.Y * right, left.Z * right, left.W * right);
    }
    public static Vector4<T> operator /(Vector4<T> left, T right)
    {
        return new(left.X / right, left.Y / right, left.Z / right, left.W / right);
    }
    public static Vector4<T> operator %(Vector4<T> left, T right)
    {
        return new(left.X % right, left.Y % right, left.Z % right, left.W % right);
    }
    
    public Vector4<TResult> As<TResult>() where TResult : unmanaged, INumber<TResult>
    {
        return new(TResult.CreateTruncating(X), TResult.CreateTruncating(Y), TResult.CreateTruncating(Z), TResult.CreateTruncating(W));
    }
    
    public static implicit operator Vector2<T>(Vector4<T> value) => new(value.X, value.Y);
    public static implicit operator Vector3<T>(Vector4<T> value) => new(value.X, value.Y, value.Z);
    public static implicit operator Vector4(Vector4<T> v) => new(float.CreateSaturating(v.X), float.CreateSaturating(v.Y), float.CreateSaturating(v.Z), float.CreateSaturating(v.W));
    public static implicit operator Vector4<T>(Vector4 v) => new(T.CreateSaturating(v.X), T.CreateSaturating(v.Y), T.CreateSaturating(v.Z), T.CreateSaturating(v.W));
    public static implicit operator Vector4D<T>(Vector4<T> v) => new(T.CreateSaturating(v.X), T.CreateSaturating(v.Y), T.CreateSaturating(v.Z), T.CreateSaturating(v.W));
    public static implicit operator Vector4<T>(Vector4D<T> v) => new(T.CreateSaturating(v.X), T.CreateSaturating(v.Y), T.CreateSaturating(v.Z), T.CreateSaturating(v.W));



    public static T          Length(Vector4<T> self)
    {
        return T.CreateTruncating(double.Sqrt(double.CreateChecked(self.X * self.X) +
                                              double.CreateChecked(self.Y * self.Y) +
                                              double.CreateChecked(self.Z * self.Z) +
                                              double.CreateChecked(self.W * self.W)));
    }
    public static Vector4<T> Normal(Vector4<T> self)
    {
        return self / Length(self);
    }

    public static Vector4<T> Min(Vector4<T> self, Vector4<T> other)
    {
        return new(T.Min(self.X, other.X), T.Min(self.Y, other.Y), T.Min(self.Z, other.Z), T.Min(self.W, other.W));
    }
    public static Vector4<T> Max(Vector4<T> self, Vector4<T> other)
    {
        return new(T.Max(self.X, other.X), T.Max(self.Y, other.Y), T.Max(self.Z, other.Z), T.Max(self.W, other.W));
    }
    public static Vector4<T> Abs(Vector4<T> self)
    {
       return new (T.Abs(self.X), T.Abs(self.Y), T.Abs(self.Z), T.Abs(self.W));
    }
    public static Vector4<T> Sign(Vector4<T> self)
    {
        return new (T.CreateChecked(T.Sign(self.X)), T.CreateChecked(T.Sign(self.Y)), T.CreateChecked(T.Sign(self.Z)), T.CreateChecked(T.Sign(self.W)));
    }
    public static Vector4<T> Clamp(Vector4<T> self, Vector4<T> min, Vector4<T> max)
    {
        return new(T.Clamp(self.X, min.X, max.X), T.Clamp(self.Y, min.Y, max.Y), T.Clamp(self.Z, min.Z, max.Z), T.Clamp(self.W, min.W, max.W));
    }
}

