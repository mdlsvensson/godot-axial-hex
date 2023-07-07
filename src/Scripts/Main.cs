using Godot;
using static HexMapGlobals;

public partial class Main : Node3D
{
    public bool Initialized { get; private set; } = false;

    [Export]
    private float _hexSize = 0.5f;
    [Export]
    private Vector2 _mapSize = new(1024, 1024);

    public override void _Ready()
    {
        HexSize = _hexSize;
        MapSize = _mapSize;

        Initialized = true;
    }

    public override void _Process(double delta)
    {
    }
}
