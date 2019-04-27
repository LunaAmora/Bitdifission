using Godot;
using System;

public class Bidivisor : Area2D
{
    public override void _Ready()
    {
        Connect("body_enter", this, "_on_Area2D_body_enter");
        
    }
    public void _on_Area2D_body_enter(KinematicBody2D body){
        if (body.HasMethod("GetInput")){
            ((PlayerBlock)body).SplitBlock(this);
        }
    }
    
}
