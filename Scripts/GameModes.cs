using Godot;
using System;

public class GameModes : Control
{
    private void _on_Campaign_pressed(){
        GetTree().ChangeScene("res://Scenes/GameScene.tscn");
    }

    private void _on_Arcade_pressed(){
        GetTree().ChangeScene("res://Scenes/ArcadeScene.tscn");
    }
    public override void _Process(float delta){
        if (Input.IsActionJustPressed("ui_cancel")){
            GetTree().ChangeScene("res://Scenes/Menu.tscn");
        }
    }
}
