using Godot;
using System;
using DABank.Scripts;

public partial class Bank1 : TileMapLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void EnterBank(Node2D body)
	{
		if (body is players)
		{
			GD.Print("Player 1 entered");
			body.Position = new Vector2(3000.0f, 75.0f);

		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
