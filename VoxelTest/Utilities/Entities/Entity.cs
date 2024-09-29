using Newtonsoft.Json;

namespace VoxelTest.Utilities.Entities;

public class Entity(Scene scene)
{
    private bool _started;

    [JsonIgnore] public Game  Game { get; } = scene.Game;
    [JsonIgnore] public Scene Scene { get; } = scene;

    readonly List<Behavior> _behaviors = new();
    
    public void Update (float delta)
    {
        foreach (var behavior in _behaviors)
        {
            behavior.Update(delta);
        }

        if (!_started)
        {
            OnStart(delta);
            _started = true;
        }
        OnUpdate(delta);
    }
    public void Render (float delta)
    {
        foreach (var behavior in _behaviors)
        {
            behavior.Render(delta);
        }  
        if (!_started)
        {
            OnStart(delta);
            _started = true;
        }
        OnRender(delta);
    }
    public void Dispose(float delta)
    {
        if (!_started) return;
        foreach (var behavior in _behaviors)
        {
            behavior.Dispose(delta);
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

    public T?   GetBehavior   <T>() where T : Behavior
    {
        return _behaviors.Find(b => b.GetType() == typeof(T)) as T;
    }
    public T    AddBehavior   <T>(T behavior) where T : Behavior
    {
        if (_behaviors.All(b => b.GetType() != behavior.GetType()))
        {
            _behaviors.Add(behavior);
            return behavior;
        }
        return behavior;
    }
    public void RemoveBehavior<T>(T behavior) where T : Behavior
    {
        if (_behaviors.Any(b => b.GetType() == behavior.GetType()))
        {
            _behaviors.Remove(behavior);
        }
    }
}