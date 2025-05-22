using Godot;
using System;

public partial class FireRateModule : Node2D
{
	[Export] public float FireDelay = 0.5f;
	private float _lastFireTime = -100f;

	public bool CanShoot()
	{
		if (Time.GetTicksMsec() / 1000f - _lastFireTime >= FireDelay)
		{
			_lastFireTime = Time.GetTicksMsec() / 1000f;
			return true;
		}
		return false;
	}
}
