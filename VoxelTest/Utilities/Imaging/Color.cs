using System.Runtime.InteropServices;

namespace VoxelTest.Utilities.Imaging;

[StructLayout(LayoutKind.Auto)]
public readonly record struct Color(byte R, byte G, byte B, byte A)
{
    public static Color Black       { get; } = new(0, 0, 0, 0);
    public static Color White       { get; } = new(255, 255, 255, 255);
    public static Color Red         { get; } = new(255, 0, 0, 255);
    public static Color Green       { get; } = new(0, 255, 0, 255);
    public static Color Blue        { get; } = new(0, 0, 255, 255);
    public static Color Cyan        { get; } = new(0, 255, 255, 255);
    public static Color Magenta     { get; } = new(255, 0, 255, 255);
    public static Color Yellow      { get; } = new(255, 255, 0, 255);
    public static Color Transparent { get; } = new(0, 0, 0, 0);
}