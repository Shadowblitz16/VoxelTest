namespace VoxelTest.Utilities.Assets;

public abstract class AssetFactory<T> where T : IAsset
{
    public abstract T Make();
}