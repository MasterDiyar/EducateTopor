using Godot;
using System;
using newcorrupt.game.extraUtilities;

public partial class Bullet : Area2D
{
	public float Damage { get; set; }
	public float Speed { get; set; }
	public string Target { get; set; }
	public Timer Timer { get; set; }
	public float FlyDuration { get; set; }
	public Item Item { get; set; }
	public override void _Ready()
	{
		Timer = Timer ?? GetNode<Timer>("Timer");
		BodyEntered += OnBodyEntered;
		Timer.WaitTime = FlyDuration;
		Timer.Start();
		Timer.Timeout += QueueFree;

		if (Item != null)
		{
			var icon = GetNode<Sprite2D>("Sprite2D");
			icon.Texture = GD.Load<Texture2D>(Item.TextureRoot);
		}
	}
	
	public override void _Process(double delta)
	{
		Position += Speed * (float)delta * new Vector2(Mathf.Cos(Rotation), Mathf.Sin(Rotation));
	}

	protected virtual void OnBodyEntered(Node body)
	{
		if (body.IsInGroup(Target))
		{
			if (Target == "Player")
			{
				var plProperty = GetNode<Property>("property");
				plProperty.Hp -= Damage;
			}
			else if (Target == "Enemy")
			{
				
			}
		}
	}
}
