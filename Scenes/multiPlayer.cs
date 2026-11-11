using Godot;
using System;

public partial class multiPlayer : Button
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Text = "Multi-Player";
        Pressed += ButtonPressed;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    private void ButtonPressed()
    {
        GD.Print("Button pressed: " + Text); 
        GetTree().ChangeSceneToFile("res://Scenes/map.tscn");
    }
}