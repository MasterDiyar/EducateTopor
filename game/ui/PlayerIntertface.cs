using Godot;
using System;

public partial class PlayerIntertface : Control
{
	public Weapon FirstWeapon, SecondWeapon, ThirdWeapon;
	public override void _Ready()
	{
		
	}

	
	public override void _Process(double delta)
	{
		
	}

	private void PickItem()
	{
		if (Input.IsActionJustPressed("one"))
		{
			FirstWeapon.ProcessMode = ProcessModeEnum.Inherit;
			SecondWeapon.ProcessMode = ProcessModeEnum.Disabled;
			ThirdWeapon.ProcessMode = ProcessModeEnum.Disabled;
		}

		if (Input.IsActionJustPressed("two"))
		{
			FirstWeapon.ProcessMode = ProcessModeEnum.Disabled;
			SecondWeapon.ProcessMode = ProcessModeEnum.Inherit;
			ThirdWeapon.ProcessMode = ProcessModeEnum.Disabled;
		}

		if (Input.IsActionJustPressed("three"))
		{
			FirstWeapon.ProcessMode = ProcessModeEnum.Disabled;
			SecondWeapon.ProcessMode = ProcessModeEnum.Disabled;
			ThirdWeapon.ProcessMode = ProcessModeEnum.Inherit;
		}
		
		
	}
	
}
