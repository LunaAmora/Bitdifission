using Godot;
using System;

public class Terminal : Area2D
{
    public bool active = false;
    public override void _Ready()
    {
        ((GameScene)GetTree().GetRoot().GetChild(0)).LevelTerminals.Add(this);
    }

    public override void _Process(float delta){
        if (!active){
            foreach (PhysicsBody2D body in GetOverlappingBodies()){
                if (body.HasMethod("GetInput")){
                    active = true;
                    ((PlayerBlock)body).active = false;
                    ((GameScene)GetTree().GetRoot().GetChild(0)).update_level();
                    return;
                }
            }
        }
    }
}
