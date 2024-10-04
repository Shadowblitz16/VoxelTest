using System.Numerics;
using System.Runtime.InteropServices;
using Silk.NET.Maths;

namespace VoxelTest.Utilities.Mathematics;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct Vector2<T>(T X, T Y) :
    IComparisonOperators <Vector2<T>, Vector2<T>, bool>,
    IAdditionOperators   <Vector2<T>, Vector2<T>, Vector2<T>>,
    ISubtractionOperators<Vector2<T>, Vector2<T>, Vector2<T>>,
    IMultiplyOperators   <Vector2<T>, Vector2<T>, Vector2<T>>,
    IDivisionOperators   <Vector2<T>, Vector2<T>, Vector2<T>>,
    IModulusOperators    <Vector2<T>, Vector2<T>, Vector2<T>>,
    IMultiplyOperators   <Vector2<T>, T, Vector2<T>>,
    IDivisionOperators   <Vector2<T>, T, Vector2<T>>,
    IModulusOperators    <Vector2<T>, T, Vector2<T>>,
    IVector<Vector2<T>, T>  
    where T : unmanaged, INumber<T>
{

    public static  Vector2<T> One   { get; } = new(T.One , T.One );
    public static  Vector2<T> Zero  { get; } = new(T.Zero, T.Zero);
    public static  Vector2<T> UnitX { get; } = new(T.One , T.Zero);
    public static  Vector2<T> UnitY { get; } = new(T.Zero, T.One );
    
    public static bool operator >=(Vector2<T> left, Vector2<T> right)
    {
        return left.X >= right.X && left.Y >= right.Y;
    }
    public static bool operator <=(Vector2<T> left, Vector2<T> right)
    {
        return left.X <= right.X && left.Y <= right.Y;
    }
    public static bool operator > (Vector2<T> left, Vector2<T> right)
    {
        return left.X > right.X && left.Y > right.Y;
    }
    public static bool operator < (Vector2<T> left, Vector2<T> right)
    {
        return left.X < right.X && left.Y < right.Y;
    }
    
    public static Vector2<T> operator +(Vector2<T> left, Vector2<T> right)
    {
        return new(left.X + right.X, left.Y + right.Y);
    }
    public static Vector2<T> operator -(Vector2<T> left, Vector2<T> right)
    {
        return new(left.X - right.X, left.Y - right.Y);
    }
    public static Vector2<T> operator *(Vector2<T> left, Vector2<T> right)
    {
        return new(left.X * right.X, left.Y * right.Y);
    }
    public static Vector2<T> operator /(Vector2<T> left, Vector2<T> right)
    {
        return new(left.X / right.X, left.Y / right.Y);
    }
    public static Vector2<T> operator %(Vector2<T> left, Vector2<T> right)
    {
        return new(left.X % right.X, left.Y % right.Y);
    }
   
    public static Vector2<T> operator *(Vector2<T> left, T right)
    {
        return new(left.X * right, left.Y * right);
    }
    public static Vector2<T> operator /(Vector2<T> left, T right)
    {
        return new(left.X / right, left.Y / right);
    }
    public static Vector2<T> operator %(Vector2<T> left, T right)
    {
        return new(left.X % right, left.Y % right);
    }
    
    public Vector2<TResult> As<TResult>() where TResult : unmanaged, INumber<TResult>
    {
        return new(TResult.CreateTruncating(X), TResult.CreateTruncating(Y));
    }
    public static implicit operator Vector2(Vector2<T> v) => new(float.CreateSaturating(v.X), float.CreateSaturating(v.Y));
    public static implicit operator Vector2<T>(Vector2 v) => new(T.CreateSaturating(v.X), T.CreateSaturating(v.Y));

    public static implicit operator Vector2D<T>(Vector2<T> v) => new(T.CreateSaturating(v.X), T.CreateSaturating(v.Y));
    public static implicit operator Vector2<T>(Vector2D<T> v) => new(T.CreateSaturating(v.X), T.CreateSaturating(v.Y));

    public static T          Length(Vector2<T> self)
    {
        return T.CreateTruncating(double.Sqrt(double.CreateChecked(self.X * self.X) +
                                              double.CreateChecked(self.Y * self.Y)));
    }
    public static Vector2<T> Normal(Vector2<T> self)
    {
        return self / Length(self);
    }

    public static Vector2<T> Min(Vector2<T> self, Vector2<T> other)
    {
        return new(T.Min(self.X, other.X), T.Min(self.Y, other.Y));
    }
    public static Vector2<T> Max(Vector2<T> self, Vector2<T> other)
    {
        return new(T.Max(self.X, other.X), T.Max(self.Y, other.Y));
    }
    public static Vector2<T> Abs(Vector2<T> self)
    {
       return new (T.Abs(self.X), T.Abs(self.Y));
    }
    public static Vector2<T> Sign(Vector2<T> self)
    {
        return new (T.CreateChecked(T.Sign(self.X)), T.CreateChecked(T.Sign(self.Y)));
    }
    public static Vector2<T> Clamp(Vector2<T> self, Vector2<T> min, Vector2<T> max)
    {
        return new(T.Clamp(self.X, min.X, max.X), T.Clamp(self.Y, min.Y, max.Y));
    }
    
}

