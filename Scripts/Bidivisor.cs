using Godot;
using System;

public class Bidivisor : ActivableArea
{
    AnimationPlayer anim;
    public override void _Ready()
    {
        anim = ((AnimationPlayer)GetChild(GetChildCount()-1));
        if (active) anim.Play();
        else anim.PlayBackwards();
    }
	public override void _Process(float delta){
        if (active){
            if (anim.CurrentAnimationPosition == 0){
                anim.Play();
            }
            foreach (PhysicsBody2D body in GetOverlappingBodies()){
                if (body.HasMethod("GetInput")){
                    ((PlayerBlock)body).SplitBlock(this);
                }
            }
        }
        else if (anim.CurrentAnimationPosition == 1){
            anim.PlayBackwards();
        }
    }
}
