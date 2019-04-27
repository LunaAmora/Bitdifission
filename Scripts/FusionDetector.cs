using Godot;
using System;

public class FusionDetector : Area2D
{
    public override void _Process(float delta){
        foreach (PhysicsBody2D body in GetOverlappingBodies()){
                if (body.HasMethod("GetInput")){
                if  (body != GetParent()){
                    if ((!(((PlayerBlock)body).duplicating > 0) && !(((PlayerBlock)GetParent()).duplicating > 0))){
                        GetTree().ReloadCurrentScene();
                        return;
                    }
                }
            }
        }
    }
}
