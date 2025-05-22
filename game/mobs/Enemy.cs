using Godot;
using System;

public partial class Enemy : RigidBody2D
{
	
	public override void _Ready()
	{
	}


	public override void _Process(double delta)
	{
	}

	
	
	public virtual void Die()
	{
		QueueFree();
	}
}
