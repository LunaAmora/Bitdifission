using Godot;
using System;

public class PlayButton : TextureButton
{
    private void _on_TextureButton_pressed(){
        GetTree().ChangeScene("res://Scenes/GameScene.tscn");
    }
}