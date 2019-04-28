using Godot;
using System;

public class Options : Control
{
    private void _on_Quit_pressed(){
        GetTree().ChangeScene("res://Scenes/Menu.tscn");
    }
    private void _on_Reset_pressed()
    {
        ((GameScene)GetTree().GetRoot().GetChild(0)).reset_scene = true;
        ((GameScene)GetTree().GetRoot().GetChild(0)).change_delay = 30;
        Hide();
    }
}