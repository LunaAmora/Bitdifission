using Godot;
using System;

public class PlayerBlock : KinematicBody2D
{
	[Export] public int[] jump = new int[]{120, 85};
	public int jumpIndex = 0;
	Vector2 velocity = new Vector2();
	
	public int duplicating = 0;
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
			velocity *= jump[jumpIndex];
			return true;
		}
		public override void _PhysicsProcess(float delta)
		{
			if (duplicating > 0) duplicating -= 1;
			if (Input.IsActionJustPressed("ui_cancel")){
				Set("rotation_degrees", GetRotationDegrees()+ 90);
			}
			if (GetInput()){
				if (!TestMove(Transform, velocity.Rotate(GetRotation()))){
					jumpTile();
				}
			}
		}

		public void jumpTile(){
			KinematicCollision2D a = MoveAndCollide(velocity.Rotate(GetRotation()));
		}
}
