using Godot;
using System;

public class ActivableArea : Area2D
{
    [Export] public bool active = false;
    public override void _Ready()
    {
        
    }
}
