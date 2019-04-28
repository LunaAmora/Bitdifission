using Godot;
using System;

public class Bidivisor : ActivableArea
{
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
