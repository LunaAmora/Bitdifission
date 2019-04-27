using Godot;
using System;

public class PlayerBlock : KinematicBody2D
{
	Vector2 velocity = new Vector2();
	Vector2 last_direction = new Vector2();
	public bool GetInput()
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
			else {
				return false;
			}
			last_direction = velocity;
			velocity *= 128;
			return true;
		}
		public override void _Process(float delta)
		{
			if (Input.IsActionJustPressed("ui_cancel")){
				Set("rotation_degrees", GetRotationDegrees()+ 90);
			}
			if (GetInput()){
				MoveLocalX(velocity.x);
				MoveLocalY(velocity.y);	
			}
		}
}
