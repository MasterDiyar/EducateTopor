using Godot;
using newcorrupt.game.extraUtilities;

public partial class Weapon : Sprite2D
{
    [Export] public DamageModule Damage;
    [Export] public AmmoModule Ammo;
    [Export] public FireTypeModule FireType;
    [Export] public FireRateModule FireRate;
    [Export] public ProjectileModule Projectile;
    public Item Item { get; set; }

    public override void _Ready()
    {
        Texture = GD.Load<Texture2D>(Item.TextureRoot);
        Damage = GetNode<DamageModule>("DamageModule");
        Ammo = GetNode<AmmoModule>("AmmoModule");
        FireType = GetNode<FireTypeModule>("FireTypeModule");
        FireRate = GetNode<FireRateModule>("FireRateModule");
        Projectile = GetNode<ProjectileModule>("ProjectileModule");
    }

    public void Fire()
    {
        if (!Ammo.CanFire()) return;

        if (FireRate.CanShoot())
        {
            Ammo.ConsumeAmmo();
            FireType.Fire(Damage, Projectile);
        }
    }
    
}