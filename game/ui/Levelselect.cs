using Godot;
using System;

public partial class Levelselect : Control
{
	private Button _first, _second, _third;
	public override void _Ready()
	{
		_first = GetNode<Button>("first");
		_second = GetNode<Button>("second");
		_third = GetNode<Button>("third");
		foreach (var node in GetChildren())
		{
			if (node is Button nid)
			{
				nid.MouseEntered += () => {nid.Scale = new Vector2(4.2f, 4.2f);};
				nid.MouseExited += () => {nid.Scale = new Vector2(4, 4);};
				
			}
		}

		_first.Pressed += _on_first_pressed;
	}

	
	public override void _Process(double delta)
	{
	}

	private void _on_first_pressed()
	{
		var level = GD.Load<PackedScene>("res://game/map/testworld.tscn").Instantiate();
		
		QueueFree();
	}
}
