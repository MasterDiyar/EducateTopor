using System;
using System.IO;
using System.Text.Json;
using Godot;

namespace newcorrupt.game.extraUtilities;

public class Munition : Item
{
    private readonly MoveScript _script = new MoveScript();
    private class IList
    {
        public string[] Items { get; init; }
    }

    public class WeaponProperty
    {
        public float Damage { get; init; }
        public int Cartridge { get; init; }
        public int MaxAmmo { get; init; }
        public int CurrentAmmo { get; init; }
        public string FireType { get; init; }
        public float FireDelay { get; init; }
        public string BulletType { get; init; }
    }



    public string GetItemById(int itemId)
    {
        string jsonText = File.ReadAllText("game/items/json/idtoitem.json");
        IList item = JsonSerializer.Deserialize<IList>(jsonText);

        return item.Items[itemId];
    }

    public WeaponProperty GetPropertyByName(string name){
        string jsonText = File.ReadAllText($"game/items/props/{name}prop.json");
        return JsonSerializer.Deserialize<WeaponProperty>(jsonText);
    }

    public FireTypeModule SetFireType(string type) => type switch
    {
        "default" => new FireTypeModule(),
        "fire" => new FireTypeModule(),
        _ => new FireTypeModule()
    };


    public PackedScene SetBulletType(string type) => type switch
    {
        "default" => GD.Load<PackedScene>("res://game/items/bullet.tscn"),
        _ => GD.Load<PackedScene>("res://game/items/bullet.tscn")
    };

    public Weapon SetWeapon(int id)
    {
        var item = GetItemById(id);
        Weapon newWeapon = new Weapon();
        WeaponProperty weaponProperty = GetPropertyByName(item);

        newWeapon.Item = _script.ItemParser($"game/items/json/{item}.json");
        newWeapon.Damage.DamageAmount = weaponProperty.Damage;
        newWeapon.Ammo.MaxAmmo = weaponProperty.MaxAmmo;
        newWeapon.Ammo.CurrentAmmo = weaponProperty.CurrentAmmo;
        newWeapon.Ammo.CartridgeSize = weaponProperty.Cartridge;
        newWeapon.FireType = SetFireType(weaponProperty.FireType);
        newWeapon.FireRate.FireDelay = weaponProperty.FireDelay;
        newWeapon.Projectile.ProjectileScene = SetBulletType(weaponProperty.BulletType);
        return newWeapon;
    }

    public Weapon GetReadyWeapon(int id) => GetWeaponScene(id).Instantiate<Weapon>();
        
    public PackedScene GetWeaponScene(int id) => GD.Load<PackedScene>($"res://game/items/weapon/{_script.ItemParser($"game/items/json/{GetItemById(id)}.json").Name}.tscn");

}