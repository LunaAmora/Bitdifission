using Godot;
using System;

public class Activator : Area2D
{
    Bidivisor link_to_activate;
    [Export] bool lever_mode = true;
    [Export] bool active = false;

    private bool entered = false; 
    public override void _Ready()
    {
        link_to_activate = (Bidivisor)GetParent().GetChild(GetParent().GetChildren().IndexOf(this) + 1);
        link_to_activate.active = false;
    }
    public override void _PhysicsProcess(float delta){
        foreach (PhysicsBody2D body in GetOverlappingBodies()){
            if (entered) return;
            if (body.HasMethod("GetInput")){
                ChangeState();
                entered = true;
                return;
            }
        }
        if (entered){
            if (!lever_mode) ChangeState();
            entered = false;
        }
    }

    public void ChangeState(){
        active = !active;
        link_to_activate.active = active;
    }
}
