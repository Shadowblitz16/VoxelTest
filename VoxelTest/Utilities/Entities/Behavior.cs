using Newtonsoft.Json;

namespace VoxelTest.Utilities.Entities;

public class Behavior(Entity entity)
{
    private bool _started;
    
    [JsonIgnore] public Entity Entity { get; } = entity;
    [JsonIgnore] public Scene  Scene  { get; } = entity.Scene;
    [JsonIgnore] public Game   Game   { get; } = entity.Game;
    
    public virtual void Update (float delta)
    {
        if (!_started)
        {
            OnStart(delta);
            _started = true;
        }
        OnUpdate(delta);
    }
    public virtual void Render (float delta)
    {
        if (!_started)
        {
            OnStart(delta);
            _started = true;
        }
        OnRender(delta);
    }
    public virtual void Dispose(float delta)
    {
        if (!_started) return;
        OnDispose(delta);
    }
    
    protected virtual void OnStart  (float delta)
    {
        
    }
    protected virtual void OnUpdate (float delta)
    {
        
    }
    protected virtual void OnRender (float delta)
    {
        
    }
    protected virtual void OnDispose(float delta)
    {
        
    }
}