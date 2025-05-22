using Godot;
using System;

public partial class FireTypeModule : Node2D

{
	public virtual void Fire(DamageModule damage, ProjectileModule projectile)
	{
		projectile.Spawn(damage.DamageAmount);
	}
}
