using Godot;

public class Credits : Control
{
    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("ui_cancel"))
        {
            GetTree().ChangeScene("res://Scenes/Menu.tscn");
        }
    }
}
