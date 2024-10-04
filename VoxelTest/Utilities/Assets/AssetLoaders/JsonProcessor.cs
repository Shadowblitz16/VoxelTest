using Newtonsoft.Json;
namespace VoxelTest.Utilities.Assets;
public abstract class JsonProcessor<T> : IAssetProcessor where T : Json
{
    public         bool TryLoad   (out IAsset value, Stream stream)
    {
        var serializer = new JsonSerializer();
        using var textReader = new StreamReader  (stream    );
        using var jsonReader = new JsonTextReader(textReader);
        var result = serializer.Deserialize<T>(jsonReader);
        
        if (result != null)
        {
            value = result;
            return true;
        }
        
        value = default!;
        return false;
    }
    public virtual bool TryDispose(in  IAsset value)
    {
        return true;
    }
}