namespace VoxelTest.Utilities.Assets;

public interface IAssetProcessor
{ 
    bool TryLoad   (out IAsset value, Stream stream);
    bool TryDispose(in  IAsset value);
}

public interface IAssetProcessor<T> : IAssetProcessor where T : IAsset
{
    bool TryLoad(out T value, Stream stream)
    {
        if ((this as IAssetProcessor).TryLoad(out var result, stream) && result is T resultT)
        {
            value = resultT;
            return true;
        }

        value = default!;
        return false;
    }

    bool TryDispose(in T value)
    {
        if ((this as IAssetProcessor).TryDispose(value))
        {
            return true;
        }
        return false;
    }
}