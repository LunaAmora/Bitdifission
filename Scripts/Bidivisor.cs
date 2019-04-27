using Godot;
using System;

public class Bidivisor : Area2D
{
    [Export] public bool active = true;
	public override void _Process(float delta){
        if (active){
            foreach (PhysicsBody2D body in GetOverlappingBodies()){
                if (body.HasMethod("GetInput")){
                    ((PlayerBlock)body).SplitBlock(this);
                }
            }
        }
    }
}
