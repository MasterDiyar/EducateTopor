using Godot;
using System;

public partial class Property : Node
{
	[Export] public float Hp = 10, Speed = 20f, Resistance = 0; 
	[Export] public string MobType = "";
	
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void GetHurt(float damage)
	{
		Hp -= damage * (1 - Resistance);
		if (Hp <= 0) Death();
	}

	public void Death()
	{
		if (MobType != "")
		{
			if (MobType == "Player")
			{
				var lox = GD.Load<PackedScene>("res://game/ui/levelselect.tscn").Instantiate();
				GetParent().GetParent().AddChild(lox);
			}
		}
		GetParent().QueueFree();
	}
}
