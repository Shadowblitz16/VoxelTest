namespace VoxelTest.Utilities.Assets;

public class AssetManager(IAssetStreamProvider streamProvider)
{
    private readonly Dictionary<string, IAssetProcessor>               _processors = new(StringComparer.Ordinal);
    private readonly Dictionary<string, Dictionary<string, IAsset>>    _loaded     = new(StringComparer.Ordinal);
    private readonly Dictionary<IAsset, string>                        _names      = new();
    
    public T?   Load      <T>(string             name     ) where T : IAsset
    {
        var value = Load(typeof(T).Name, name);
        if (value is T result) return result;
        return default;
    }
    public void Dispose   <T>(T?                 asset    ) where T : IAsset
    {
        Dispose(typeof(T).Name, asset);
    }
    public void Register  <T>(IAssetProcessor<T> processor) where T : IAsset
    {
        Register(typeof(T).Name, processor);
    }
    public void Unregister<T>(                            ) where T : IAsset
    {
        Unregister(typeof(T).Name);
    }
    
    public IAsset? Load      (string type, string          name     )
    {
        var processor = _processors[type];
        var stream    = streamProvider.GetAssetStream(type, name);

        if (_loaded.TryGetValue(type, out var result))
        {
            return result[name];
        }
        
        if (processor.TryLoad(out var value, stream))
        {
            if (_loaded.ContainsKey(type)) _loaded.Add(type, new Dictionary<string, IAsset>(StringComparer.Ordinal));
            _loaded[type].Add(name, value);
            _names.Add(value, name);
            return value;
        }
        return null;
    }
    public void    Dispose   (string type, IAsset?         asset    )
    {
        if (asset == null) return;
        if (!_loaded.TryGetValue(type, out var value)) return;
        
        var processor = _processors[type];
        if (processor.TryDispose(in asset))
        {
            value .Remove(_names[asset]);
            _names.Remove(asset);
            
            if (value.Count == 0) _loaded.Remove(type);
        }
        
    }
    public void    Register  (string type, IAssetProcessor processor)
    {
        _processors.TryAdd(type, processor);
    }
    public void    Unregister(string type                           )
    {
        _processors.Remove(type);
    }
    
    public IEnumerable<string> Types => _processors.Keys;
}