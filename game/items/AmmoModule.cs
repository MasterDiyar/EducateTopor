using Godot;
using System;

public partial class AmmoModule : Node2D
{
	[Export] public int MaxAmmo = 30;
	public int CurrentAmmo;

	public override void _Ready() => CurrentAmmo = MaxAmmo;

	public bool CanFire() => CurrentAmmo > 0;

	public void ConsumeAmmo() => CurrentAmmo--;
}
