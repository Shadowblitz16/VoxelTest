namespace VoxelTest.Utilities.Assets;

public interface IAssetStreamProvider
{
    public static IAssetStreamProvider CreateDefault(string root) => new AssetStreamProvider(root);
    
    Stream GetAssetStream(string assetType, string assetPath);
}