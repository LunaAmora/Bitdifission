using Godot;
using System;

public class Door : ActivableArea
{
    [Export] bool moveable = true;
    [Export] float velocity = 10;

    int dir = 1;
    bool blocked = false;
    bool moving = false;
    public override void _Ready()
    {
        
    }
    public override void _Process(float delta){
        if (!moveable){
            GetNode("Sprite").Set("visible", active);
            ((KinematicBody2D)GetNode("ignore")).SetCollisionLayer(active ? 1 : 0);
        }
        else if (active || moving){
            Vector2 pos = GetGlobalPosition();
            MoveLocalY(15 * dir);
            foreach (KinematicBody2D body in GetOverlappingBodies()){
                dir *= -1;
                active = false;
                moving = false;
                SetGlobalPosition(pos);
                MoveLocalY(30 * dir);
                return;
            }
            moving = true;
        }
    }
}
