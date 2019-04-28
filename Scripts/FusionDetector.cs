using Godot;
using System;

public class FusionDetector : Area2D
{
    public override void _Process(float delta){
        if (!((GameScene)GetTree().GetRoot().GetChild(0)).reset_scene){
        foreach (PhysicsBody2D body in GetOverlappingBodies()){
                if (body.HasMethod("GetInput")){
                if  (body != GetParent()){
                    if ((!(((PlayerBlock)body).duplicating > 0) && !(((PlayerBlock)GetParent()).duplicating > 0))){
                        ((GameScene)GetTree().GetRoot().GetChild(0)).reset_scene = true;
                        ((GameScene)GetTree().GetRoot().GetChild(0)).change_delay = 60;
                        foreach(PlayerBlock a in ((GameScene)GetTree().GetRoot().GetChild(0)).PlayerNumber){
                            a.alive = false;
                        }
                        return;
                    }
                }
            }
        }
        }
    }
}
