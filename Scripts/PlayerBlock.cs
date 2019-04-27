using Godot;
using System;

public class PlayerBlock : KinematicBody2D
{
	Vector2 velocity = new Vector2();
	public void GetInput()
		{
			velocity = new Vector2();
			if (Input.IsActionJustPressed("ui_right"))
			{
				velocity.x += 1;
			}
			else if (Input.IsActionJustPressed("ui_left"))
			{
				velocity.x -= 1;
			}
			else if (Input.IsActionJustPressed("ui_down"))
			{
				velocity.y += 1;
			}
			else if (Input.IsActionJustPressed("ui_up"))
			{
				velocity.y -= 1;
			}
			velocity *= 128;
		}
		public override void _Process(float delta)
		{
			GetInput();
			if(Input.IsActionJustPressed("ui_accept")){
				Set("rotation_degrees", GetRotationDegrees()+ 90); 
			}
			MoveLocalX(velocity.x);
			MoveLocalY(velocity.y);
		}
}
