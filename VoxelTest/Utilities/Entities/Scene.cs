using Newtonsoft.Json;

namespace VoxelTest.Utilities.Entities;

public class Scene(Game game)
{
    private bool                  _started;
    private readonly List<Entity> _entities = new();

    [JsonIgnore] public Game Game { get; } = game;
    
    public virtual void Update (float delta)
    {
        foreach (var entity in _entities)
        {
            entity.Update(delta);
        }

        if (!_started)
        {
            OnStart(delta);
            _started = true;
        }
        
        OnUpdate(delta);
    }
    public virtual void Render (float delta)
    {
        foreach (var entity in _entities)
        {
            entity.Render(delta);
        }
        
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
        foreach (var entity in _entities)
        {
            entity.Dispose(delta);
        }
        OnDispose(delta);
        _started = false;
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

    public Entity? GetEntity(uint index)
    {
        if (((int)index) >= _entities.Count) return null;
        return _entities[(int)index];
    }
    public uint    GetEntityCount()
    {
        return (uint)_entities.Count;
    }
    
    public Entity  CreateEntity()
    {
        var entity = new Entity(this);
        _entities.Add(entity);
        return entity;
    }
    public void    DestroyEntity(Entity entity)
    {
        _entities.Remove(entity);
    }
}