using Godot;
using System;

public partial class ProjectileModule : Node2D
{
	[Export] public PackedScene ProjectileScene;
	[Export] public Weapon Weapon;
	[Export] public string Target;
	private float _angle;

	public void Spawn(float damage)
	{
		_angle = GetParent<Sprite2D>().Rotation;
		
		var angledPosition = new Vector2(Mathf.Cos(Weapon.Rotation), Mathf.Sin(Weapon.Rotation));
		var instance = (Bullet)ProjectileScene.Instantiate();
		instance.Damage = damage;
		instance.FlyDuration = 1f;
		instance.Speed = 120f;
		instance.Target = Target;
		instance.Rotation = _angle;
		instance.Position = GetParent<Node2D>().GetParent<Node2D>().GetParent<Node2D>().Position + 16*angledPosition;
		GetParent().GetParent().GetParent().GetParent().AddChild(instance); //map::player::weapon
	}
}
