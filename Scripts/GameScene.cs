using System.Collections.Generic;
using Godot;

public class GameScene : Control
{
    public List<PlayerBlock> PlayerNumber = new List<PlayerBlock>();
    public List<Terminal> LevelTerminals = new List<Terminal>();
    List<PackedScene> levels = new List<PackedScene>();
    public Node current_level_node;
    public int terminals_online = 0;
    public bool reset_scene = false;
    public int gamemode = 0;
    [Export] public string levels_folder = "Levels";
    public int change_delay = 0;
    public int tuto_delay = 120;

    public override void _Ready()
    {
        foreach(string str in files_in_directory("res://Scenes/" + levels_folder))
        {
            levels.Add((PackedScene)ResourceLoader.Load("res://Scenes/" + levels_folder + "/" + str));
        }
        current_level_node = levels[0].Instance();
        AddChildBelowNode(GetChild(0), current_level_node);
    }

    public void update_level()
    {
        terminals_online += 1;
        change_delay = 60;
    }

    public void load_level(bool same_level = false)
    {
        terminals_online = 0;
        current_level_node.Free();
        PlayerNumber.Clear();
        LevelTerminals.Clear();

        if (same_level)
        {
            current_level_node = levels[0].Instance();
            AddChildBelowNode(GetChild(0), current_level_node);
        }
        else if (levels.Count > 0)
        {
            levels.RemoveAt(0);
            current_level_node = levels[0].Instance();
            AddChildBelowNode(GetChild(0), current_level_node);
        }
    }

    public List<string> files_in_directory(string path)
    {
        List<string> files = new List<string>();
        Directory dir = new Directory();
        dir.Open(path);
        dir.ListDirBegin();

        while (true)
        {
            var file = dir.GetNext();
            if (file == "")
            {
                break;
            }
            else if (!file.BeginsWith("."))
            {
                files.Add(file);
            }
        }
        return files;
    }

    public override void _Process(float delta)
    {
        if (tuto_delay > 0)
        {
            tuto_delay -= 1;
        }
        if (Input.IsActionJustPressed("reset_level"))
        {
            reset_scene = true;
            change_delay = 30;
        }
        if (Input.IsActionJustPressed("ui_cancel"))
        {
            ((Control)GetChild(GetChildren().Count - 1)).Visible = !((Control)GetChild(GetChildren().Count - 1)).Visible;
        }
        if (change_delay == 0)
        {
            if (reset_scene)
            {
                reset_scene = false;
                load_level(true);
            }
            if (terminals_online == LevelTerminals.Count)
            {
                load_level();
            }
        }
        else
        {
            change_delay -= 1;
        }
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventKey eventKey && tuto_delay == 0)
        {
            if (eventKey.Pressed)
            {
                Control control = ((Control)GetChild(GetChildren().Count - 2));
                if (control.Visible)
                {
                    control.Hide();
                }
            }
        }
    }
}
