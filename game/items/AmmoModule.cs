using Godot;
using System;
using System.Text.Json;

public partial class AmmoModule : Node2D
{
	[Export] public Weapon MyWeapon;
	[Export] public int MaxAmmo = 120;          // общий боезапас
	[Export] public int CartridgeSize = 30;     // размер магазина
	public int CurrentAmmo;                     // текущие патроны в магазине
	public int AmmoRemaining;                   // патроны вне магазина
	
	public override void _Ready()
	{
		var inventory = JsonSerializer.Deserialize<PlayerIntertface.Inventory>(FileAccess.Open("res://game/player/data/inventory.json", FileAccess.ModeFlags.Read).GetAsText());
		
		AddAmmo(inventory.AmmoCount[MyWeapon.ID]);
		ReloadAmmo();
	}

	public bool CanFire() => CurrentAmmo > 0;

	public void ConsumeAmmo()
	{
		if (CurrentAmmo > 0)
			CurrentAmmo--;
	}

	public bool CanReload() => CurrentAmmo < CartridgeSize && AmmoRemaining > 0;

	public void ReloadAmmo()
	{
		if (!CanReload())
			return;

		int needed = CartridgeSize - CurrentAmmo;
		int toReload = Math.Min(needed, AmmoRemaining);

		CurrentAmmo += toReload;
		AmmoRemaining -= toReload;
	}

	public void AddAmmo(int amount)
	{
		AmmoRemaining = Math.Min(AmmoRemaining + amount, MaxAmmo);
	}
}
