using StbImageSharp;
using VoxelTest.Utilities.Assets;
using VoxelTest.Utilities.Mathematics;

namespace VoxelTest.Utilities.Imaging;

public class Image : IAsset
{
    private byte[] _data;
    private Vector2<uint> _size;
    public  Vector2<uint>  Size => _size;

    public Image(Vector2<uint> size, Color color)
    {
        _size = size;
        _data = new byte[size.X * size.Y * 4];
        for (var i = 0; i < _data.Length; i += 4)
        {
            _data[i+0] = color.R;
            _data[i+1] = color.G;
            _data[i+2] = color.B;
            _data[i+3] = color.A;
        }
    }
    public Image(Stream stream)
    {
        var result = ImageResult.FromStream(stream);
        _size = new((uint)result.Width, (uint)result.Height);
        _data = result.Data;

    }
    
    public ReadOnlySpan<byte> AsSpan() => _data.AsSpan();

    public void  SetPixel(uint x, uint y, Color color)
    {
        _data[((x + y * Size.X) * 4) + 0] = color.R;
        _data[((x + y * Size.X) * 4) + 1] = color.G;
        _data[((x + y * Size.X) * 4) + 2] = color.B;
        _data[((x + y * Size.X) * 4) + 3] = color.A;
    }
    public Color GetPixel(uint x, uint y)
    {
        var r = _data[((x + y * Size.X) * 4) + 0];
        var g = _data[((x + y * Size.X) * 4) + 1];
        var b = _data[((x + y * Size.X) * 4) + 2];
        var a = _data[((x + y * Size.X) * 4) + 3];
        return new Color(r, g, b, a);
    }

    public void BlitRect(Image srcImage, Vector2<uint> srcPos, Vector2<uint> dstPos, Vector2<uint> size)
    {
        if (srcImage == null) return;
        
        for (uint y = 0; y < size.Y; y++)
        for (uint x = 0; x < size.X; x++)
        {
            SetPixel(x + dstPos.X, y + dstPos.Y, srcImage.GetPixel(x + srcPos.X, y + srcPos.Y));
        }
    }
    public void Resize(Vector2<uint> size)
    {
        var newSize = new Vector2<uint>(size.X, size.Y);
        var newData = new byte[newSize.X * newSize.Y];
        
        for (uint y = 0; y < size.Y; y++)
        for (uint x = 0; x < size.X; x++)
        {
            newData[((x + y * size.X) * 4) + 0] = _data[((x + y * Size.X) * 4) + 0];
            newData[((x + y * size.X) * 4) + 1] = _data[((x + y * Size.X) * 4) + 1];
            newData[((x + y * size.X) * 4) + 2] = _data[((x + y * Size.X) * 4) + 2];
            newData[((x + y * size.X) * 4) + 3] = _data[((x + y * Size.X) * 4) + 3];
        }
        
        _data = newData;
        _size = newSize;
    }
}