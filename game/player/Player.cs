using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 80.0f;
	private Weapon _weapon;
	public override void _Ready()
	{
		GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("move");
		_weapon = GetNode<Weapon>("weapon");
	}

	public override void _PhysicsProcess(double delta)
	{
		Attack();
		
		
		Vector2 velocity = Velocity;
		
		Vector2 direction = Input.GetVector("a", "d", "w", "s");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	private void Attack(bool type = false)
	{
		if (Input.IsActionPressed("attack"))
			_weapon.Fire();
	}
}
