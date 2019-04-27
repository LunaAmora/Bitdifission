using Godot;
using System;
using System.Collections.Generic;

public class GameScene : Control
{
    public List<PlayerBlock> PlayerNumber = new List<PlayerBlock>();
    public List<Terminal> LevelTerminals = new List<Terminal>();
    
    List<PackedScene> levels = new List<PackedScene>();
    public Node current_level_node;
    public int current_n = 0;
    
    public int terminals_online = 0;

    public override void _Ready()
    {
        foreach(string str in files_in_directory("res://Scenes/Levels")){
            levels.Add((PackedScene)ResourceLoader.Load("res://Scenes/Levels/" + str));
        }

        current_level_node = levels[0].Instance();
        AddChild(current_level_node);
    }

    public void update_level(){
        terminals_online += 1;
        if (terminals_online == LevelTerminals.Count){
            load_level();
        }
    }

    public void load_level(bool same_level = false){
        terminals_online = 0;
        current_level_node.QueueFree();
        foreach(PlayerBlock rip in PlayerNumber){
            rip.QueueFree();
        }
        foreach(Terminal rip in LevelTerminals){
            rip.QueueFree();
        }
        if (same_level){
            current_level_node = levels[current_n].Instance();
            AddChild(current_level_node);
        }
        else if (levels.Count > current_n){
            current_level_node = levels[current_n + 1].Instance();
            AddChild(current_level_node);
        }
    }

    public List<string> files_in_directory(string path){
        List<string> files = new List<string>();
        Directory dir = new Directory();
        dir.Open(path);
        dir.ListDirBegin();

        while (true){
            var file = dir.GetNext();
            if (file == ""){
                break;
            }
            else if (!file.BeginsWith(".")){
                files.Add(file);
            }
        }

        return files;
    }
}
