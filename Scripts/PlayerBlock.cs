using Godot;
using System;

public class PlayerBlock : KinematicBody2D
{
	[Export] public int[] jump = new int[]{120, 85};
	public int jumpIndex = 0;
	Vector2 velocity = new Vector2();
	
	public int duplicating = 0;
	public bool active = true;
	public bool alive = true;
	public override void _Ready()
    {
		if (GlobalPosition.x > 960){
			jumpIndex = 1;
		}
        ((GameScene)GetTree().GetRoot().GetChild(0)).PlayerNumber.Add(this);
    }
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
			if (active && alive){
				if (duplicating > 0) duplicating -= 1;
				if (GetInput()){
					if (!TestMove(Transform, velocity.Rotate(GetRotation()))){
						duplicating = 5;
						jumpTile();
					}
				}
			}
			else if (((Sprite)GetChild(0)).GetFrame() == 0){
				((Sprite)GetChild(0)).SetFrame(1);
			}
		}

		public void jumpTile(){
			KinematicCollision2D a = MoveAndCollide(velocity.Rotate(GetRotation()));
		}
}
