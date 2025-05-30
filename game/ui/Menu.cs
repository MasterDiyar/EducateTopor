using Godot;
using System;

public partial class Menu : Control
{
	private Button _start, _quit;
	
	public override void _Ready()
	{
		_start = GetNode<Button>("TextureRect2/start");
		_quit = GetNode<Button>("TextureRect2/quit");
		_quit.Pressed+=()=> { GetTree().Quit(); };
		_start.Pressed+= Start;
	}

	private void Start()
	{
		GetParent().AddChild(GD.Load<PackedScene>("res://game/ui/levelselect.tscn").Instantiate());
		QueueFree();
	}
	
	public override void _Process(double delta)
	{
	}
}
