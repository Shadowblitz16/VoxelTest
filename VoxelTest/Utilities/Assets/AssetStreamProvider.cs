namespace VoxelTest.Utilities.Assets;

public class AssetStreamProvider(string root) : IAssetStreamProvider
{
    public Stream GetAssetStream(string assetType, string assetPath)
    {
        return File.Open($"{assetPath}.{assetType.ToLower(System.Globalization.CultureInfo.CurrentCulture)}", FileMode.Open);
    }
}