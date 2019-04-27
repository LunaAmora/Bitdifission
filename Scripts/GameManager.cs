using Godot;
using System;

public static class GameManager
{
    public static void SplitBlock (this PlayerBlock p, Bidivisor b){
        Vector2 pos = p.GetGlobalPosition();
        pos.x = pos.x * -1 + 1920;
        PackedScene blockScene = (PackedScene)ResourceLoader.Load("res://Objects/PlayerBlock.tscn");
        PlayerBlock[] newBlocks = new PlayerBlock[2];
        for(int i = 0; i < 2; i++){
            newBlocks[i] = (PlayerBlock)blockScene.Instance();
            newBlocks[i].duplicating = 10;
            b.GetTree().GetRoot().GetChild(0).AddChild(newBlocks[i]);
            newBlocks[i].Set("rotation_degrees", -b.GetRotationDegrees() - 45 + 90*i);
            newBlocks[i].GlobalPosition = pos;
            newBlocks[i].jumpIndex = p.jumpIndex == 0 ? 1 : 0;
            newBlocks[i].MoveLocalY(-newBlocks[i].jump[(newBlocks[i].jumpIndex)]);
        }
        p.QueueFree();
    }
    public static Vector2 Rotate(this Vector2 v, double degrees)
    {
        return new Vector2(
            (float)(v.x * Math.Cos(degrees) - v.y * Math.Sin(degrees)),
            (float)(v.x * Math.Sin(degrees) + v.y * Math.Cos(degrees))
        );
    }
}
