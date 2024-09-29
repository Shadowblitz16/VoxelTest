using Silk.NET.OpenGL;

namespace VoxelTest.Games.VoxelGame;

public class VoxelGame : Game
{
    private uint    _vao;
    private uint    _vbo;
    private float[] _verticies =
    {
        -0.5f, -0.5f, 0.0f,
        0.5f, -0.5f, 0.0f,
        0.0f, -0.5f, 0.0f
    };

    private string _vShader = @"
    #version 330 core
    layout (location = 0) in vec3 aPos;

    void main()
    {
        gl_Position = vec4(aPos.x, aPos.y, aPos.z, 1.0);
    }";
    private string _fShader = @"
    #version 330 core
    out vec4 FragColor;

    void main()
    {
        FragColor = vec4(1.0, 0.5, 0.2, 1.0);
    }";

    private uint _shader;
    protected override void OnReady(float delta)
    {
        base.OnReady(delta);
        
        // #1 vao
        Graphics.GenVertexArrays(1, out _vao);
        Graphics.BindVertexArray(_vao);
        
        // #2 vbo
        Graphics.GenBuffers(1, out _vbo);
        Graphics.BindBuffer(BufferTargetARB.ArrayBuffer, _vbo);
        Graphics.BufferData(BufferTargetARB.ArrayBuffer, (uint)(_verticies.Length * sizeof(float)), new ReadOnlySpan<float>(_verticies), BufferUsageARB.StaticDraw);
        
        // #3 attributes
        Graphics.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        Graphics.EnableVertexAttribArray(0);
        
        // #4 shader
        _shader = CompileProgram(CompileShader(_vShader, ShaderType.VertexShader), CompileShader(_fShader, ShaderType.FragmentShader));

        Graphics.BindVertexArray(0);
        Graphics.BindBuffer(BufferTargetARB.ArrayBuffer, 0);
    }

    protected override void OnRender(float delta)
    {
        base.OnRender(delta);
        Graphics.UseProgram(_shader);
        Graphics.BindVertexArray(_vao);
        Graphics.DrawArrays(PrimitiveType.Triangles, 0, 3);
    }

    private uint CompileShader(string source, ShaderType type)
    {
        var shader = Graphics.CreateShader(type);
        Graphics.ShaderSource (shader, source);
        Graphics.CompileShader(shader);

        Graphics.GetShader(shader, ShaderParameterName.CompileStatus, out var ok);
        if (ok == 0)
        {
            var infoLog = Graphics.GetShaderInfoLog(shader);
            Console.WriteLine("ERROR::SHADER::VERTEX:COMPILATION_FAILED\n"+infoLog);
        }
        return shader;
    }

    private uint CompileProgram(uint vertexShader, uint fragmentShader)
    {
        var program = Graphics.CreateProgram();
        Graphics.AttachShader(program, vertexShader  );
        Graphics.AttachShader(program, fragmentShader);
        Graphics.LinkProgram (program);
        Graphics.ValidateProgram(program);

        Graphics.GetProgram(program, ProgramPropertyARB.LinkStatus, out var ok1);
        if (ok1 == 0)
        {
            var infoLog = Graphics.GetProgramInfoLog(program);
            Console.WriteLine("ERROR::SHADER::LINKING_FAILED\n"+infoLog);
        }
        
        Graphics.GetProgram(program, ProgramPropertyARB.ValidateStatus, out var ok2);
        if (ok2 == 0)
        {
            var infoLog = Graphics.GetProgramInfoLog(program);
            Console.WriteLine("ERROR::SHADER::VALIDATION_FAILED\n"+infoLog);
        }
        
        Graphics.DetachShader(program, vertexShader);
        Graphics.DetachShader(program, fragmentShader);
        Graphics.DeleteShader(vertexShader  );
        Graphics.DeleteShader(fragmentShader);

        return program;
    }
}