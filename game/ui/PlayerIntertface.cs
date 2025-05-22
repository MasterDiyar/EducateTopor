using Godot;
using System;
using System.IO;
using System.Text.Json;
using newcorrupt.game.extraUtilities;

public partial class PlayerIntertface : Control
{
	public class DeserializedItems
	{
		public Weapon[] Items { get; set; }
		
	}
	
	
	public Weapon FirstWeapon, SecondWeapon, ThirdWeapon, CurrentWeapon;
	private Player _player;
	private int _currentItem = 0;
	private Label _properties;
	private Property _prop;
	public override void _Ready()
	{
		_properties = GetNode<Label>("Label");
		_player = GetParent().GetParent<Player>();
		_prop = _player.GetNode<Property>("property");
		CurrentWeapon = _player.GetNode<Weapon>("weapon");
		
	}

	
	public override void _Process(double delta)
	{
		_properties.Text = $"x {_prop.Hp}\nx {CurrentWeapon.GetAmmo()[0]}\n {CurrentWeapon.GetAmmo()[1]}";
	}

	private void WeaponInit(string path)
	{
		if (File.Exists(path))
		{
			string jsonText = File.ReadAllText(path);
			Item item = JsonSerializer.Deserialize<Item>(jsonText);
		}   
	}

	private void PickItem()
	{
		if (Input.IsActionJustPressed("one"))
		{
			CurrentWeapon = FirstWeapon;
		}

		if (Input.IsActionJustPressed("two"))
		{
			CurrentWeapon = SecondWeapon;
		}

		if (Input.IsActionJustPressed("three"))
		{
			CurrentWeapon = ThirdWeapon;
		}
	}
	
}
