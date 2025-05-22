using Godot;
using System;

public partial class ProjectileModule : Node2D
{
	[Export] public PackedScene ProjectileScene;
	[Export] public Weapon Weapon;

	public void Spawn(float damage)
	{
		var angledPosition = new Vector2(Mathf.Cos(Weapon.Rotation), Mathf.Sin(Weapon.Rotation));
		var instance = (Bullet)ProjectileScene.Instantiate();
		instance.Damage = damage;
		instance.Position = GetParent<Node2D>().GetParent<Node2D>().Position + 16*angledPosition;
		GetParent().GetParent().GetParent().AddChild(instance); //map::player::weapon

	}
}
