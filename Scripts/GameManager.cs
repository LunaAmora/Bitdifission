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
            p.GetOwner().AddChild(newBlocks[i]);
            newBlocks[i].Set("rotation_degrees", p.GetRotationDegrees()+ b.GetRotationDegrees() + 90*i);
            newBlocks[i].GlobalPosition = pos;
            newBlocks[i].MoveLocalY(128);
        }
        p.QueueFree();
    }
}
