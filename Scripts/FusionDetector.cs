using Godot;

public class FusionDetector : Area2D
{
    public override void _Process(float delta)
    {
        GameScene gameScene = (GameScene)GetTree().Root.GetChild(0);
        if (!gameScene.reset_scene)
        {
            foreach (PhysicsBody2D body in GetOverlappingBodies())
            {
                if (body.HasMethod("GetInput") && body != GetParent())
                {
                    if (!(((PlayerBlock)body).duplicating > 0 || ((PlayerBlock)GetParent()).duplicating > 0))
                    {
                        gameScene.reset_scene = true;
                        gameScene.change_delay = 60;
                        foreach (PlayerBlock a in gameScene.PlayerNumber)
                        {
                            a.alive = false;
                        }
                        return;
                    }
                }
            }
        }
    }
}
