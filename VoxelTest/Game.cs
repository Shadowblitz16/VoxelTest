using System.Drawing;
using System.Numerics;
using Silk.NET.Input;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;
using VoxelTest.Engine.Input;
using VoxelTest.Utilities.Mathematics;


public class Game
{

    public IWindow       Window   { get; }
    public IInputContext Input    { get; }
    public GL            Graphics { get; }
    private float _delta = 0;
    private bool _ready = false;
    private bool _running = false;

    public Game()
    {
        Window  = Silk.NET.Windowing.Window.Create(WindowOptions.Default with
        {
            IsVisible = false,
        });
        Window.Initialize();
        
        Input    = Window.CreateInput();
        Input.ConnectionChanged += (device, connected) => {
            if (!connected) return;
            
            switch (device)
            {
                case IKeyboard keyboard:
                    keyboard.KeyUp   += (_, key, _) => {
                        if (key == Key.Unknown) return;
                        OnKeyUp((KeyboardCode)key);
                    };
                    keyboard.KeyDown += (_, key, _) => {
                        if (key == Key.Unknown) return;
                        OnKeyDown((KeyboardCode)key);
                    };
                    keyboard.KeyChar += (_, key) => {
                        OnKeyChar(key);
                    };
                    break;
                case IMouse mouse:
                    mouse.MouseUp   += (_, button) => {
                        if (button == MouseButton.Unknown) return;
                        OnMouseDown((MouseCode)button);
                    };
                    mouse.MouseDown += (_, button) => {
                        if (button == MouseButton.Unknown) return;
                        OnMouseDown((MouseCode)button);
                    };
                    mouse.MouseMove += (_, move) => {
                        OnMouseMove(move);
                    };
                    mouse.Scroll    += (_, scroll) => {
                        OnMouseScroll(new(scroll.X, scroll.Y));
                    };
                    break;
            }
        };
        
        Graphics = Window.CreateOpenGL();
        Graphics.Clear(ClearBufferMask.ColorBufferBit);
        
        Window.Update  += d => {
            _delta = (float)d;

            if (!_ready)
            {
                OnReady(_delta);
                Window.IsVisible = true;
                _ready = true;
            }
            OnUpdate(_delta);
        };
        Window.Render  += d => {
            _delta = (float)d;
            
            if (!_ready)
            {
                OnReady(_delta);
                Window.IsVisible = true;
                _ready = true;
            }
            Graphics.ClearColor(Color.CornflowerBlue);
            OnRender(_delta);
        };
        Window.Closing += () => {
            OnClosed(_delta);
        };

        Window.Move    += vector2D => {   
            OnMoved(vector2D);
        };
        Window.Resize  += vector2D => {
            OnResized(vector2D);
        };
        
    }
    
    public void Run()
    {
        if (_running) return;
        _running = true;
        
        Window.Run();
    }
    
    public event Action<float>? Ready;
    public event Action<float>? Update;
    public event Action<float>? Render;
    public event Action<float>? Closed;

    public event Action<Vector2<int>>? Moved;
    public event Action<Vector2<int>>? Resizeed;
  
    public event Action<KeyboardCode>? KeyUp;
    public event Action<KeyboardCode>? KeyDown;
    public event Action<char>?         KeyChar;
    
    public event Action<MouseCode>?        MouseUp;
    public event Action<MouseCode>?        MouseDown;
    public event Action<Vector2<float>>?   MouseMove;
    public event Action<Vector2<float>>?   MouseScroll;

    protected virtual void OnReady(float delta)
    {
        Ready?.Invoke(delta);
    }

    protected virtual void OnUpdate(float delta)
    {
        Update?.Invoke(delta);
    }

    protected virtual void OnRender(float delta)
    {
        Render?.Invoke(delta);
    }

    protected virtual void OnClosed(float delta)
    {
        Closed?.Invoke(delta);
    }

    protected virtual void OnMoved(Vector2<int> position)
    {
        Moved?.Invoke(position);
    }

    protected virtual void OnResized(Vector2<int> size)
    {
        Resizeed?.Invoke(size);
    }

    protected virtual void OnKeyUp(KeyboardCode key)
    {
        KeyUp?.Invoke(key);
    }

    protected virtual void OnKeyDown(KeyboardCode key)
    {
        KeyDown?.Invoke(key);
    }

    protected virtual void OnKeyChar(char keyCode)
    {
        KeyChar?.Invoke(keyCode);
    }

    protected virtual void OnMouseUp(MouseCode button)
    {
        MouseUp?.Invoke(button);
    }

    protected virtual void OnMouseDown(MouseCode button)
    {
        MouseDown?.Invoke(button);
    }

    protected virtual void OnMouseMove(Vector2<float> delta)
    {
        MouseMove?.Invoke(delta);
    }

    protected virtual void OnMouseScroll(Vector2<float> delta)
    {
        MouseScroll?.Invoke(delta);
    }
}

