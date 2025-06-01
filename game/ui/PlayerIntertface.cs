using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using newcorrupt.game.extraUtilities;
using FileAccess = Godot.FileAccess;

public partial class PlayerIntertface : Control
{
	public class DeserializedItems
	{
		public Weapon[] Items { get; set; }
	}

	public class Inventory
	{
		[JsonPropertyName("itemID")]		
		public int[] ItemID { get; set; }
		
		[JsonPropertyName("ammo typecount")]
		public int[] AmmoCount { get; set; }
	}
	
	private List<WeaponSlotData> _slotData; 
	public Weapon FirstWeapon, SecondWeapon, ThirdWeapon, CurrentWeapon;
	public PackedScene FirWe, SecWe, ThirWe;
	private Player _player;
	private int _currentItem = 0;
	private Label _properties;
	private Property _prop;
	Inventory inventory;
	Munition munition;

	[Export]private Button inv1, inv2, inv3;
	public override void _Ready()
	{
		munition = new Munition();
		inventory = JsonSerializer.Deserialize<Inventory>(FileAccess.Open("res://game/player/data/inventory.json", FileAccess.ModeFlags.Read).GetAsText()); 
		_slotData = new List<WeaponSlotData>
		{
			new(inv1, munition.GetWeaponScene(inventory.ItemID[0]).Instantiate<Weapon>(), munition.GetWeaponScene(inventory.ItemID[0])),
			new(inv2, munition.GetWeaponScene(inventory.ItemID[1]).Instantiate<Weapon>(), munition.GetWeaponScene(inventory.ItemID[1])),
			new(inv3, munition.GetWeaponScene(inventory.ItemID[2]).Instantiate<Weapon>(), munition.GetWeaponScene(inventory.ItemID[2]))
		};
		
		_properties = GetNode<Label>("Label");
		_player = GetParent().GetParent<Player>();
		_prop = _player.GetNode<Property>("property");
		CurrentWeapon = _slotData[0].WeaponRef;
		var mun = new Munition();
		for (int i = 0; i < _slotData.Count; i++)
		{
			
			var slot = _slotData[i];
			slot.Button.Pressed += (() => Equip(slot));
			slot.Button.GetNode<TextureRect>("TextureRect").Texture =
				GD.Load<Texture2D>(mun.GetItemById(inventory.ItemID[i]).TextureRoot);
		}
		
	}

	
	public override void _Process(double delta)
	{
		PickItem();
		_properties.Text = $"x {_prop.Hp}\nx {CurrentWeapon.GetAmmo()[0]}\n {CurrentWeapon.GetAmmo()[1]}";
	}

	private void WeaponInit(string path)
	{
		if (File.Exists(path))
		{
			string jsonText = FileAccess.Open(path, FileAccess.ModeFlags.Read).GetAsText();
			Item item = JsonSerializer.Deserialize<Item>(jsonText);
		}   
	}

	private void PickItem()
	{
		for (int i = 0; i < _slotData.Count; i++)
		{

			string actionName = i switch
			{
				0 => "1",
				1 => "2",
				2 => "3",
				_ => null
			};

			if (!string.IsNullOrEmpty(actionName) && Input.IsActionJustPressed(actionName))
			{
				Equip(_slotData[i]);
				break; 
			}
		}
	}

	private void Equip(WeaponSlotData slot)
	{
		CurrentWeapon = slot.WeaponRef;
		_player.EquipWeapon(slot.Scene);
	}
	
}