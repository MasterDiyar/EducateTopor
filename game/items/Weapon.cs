using Godot;
using newcorrupt.game.extraUtilities;


/*
 * DamageModule <= There all damage will be saved
 * Ammo <= Get ammo count
 * FireType <= For change type of attack
 * FireRate <= Fire Rate
 * ProjectileModule <= Spawn bullet
 * Item <= Texture, Name, id of weapon
 */
public partial class Weapon : Sprite2D
{
    [Export] public int ID;
    [Export] public DamageModule Damage;
    [Export] public AmmoModule Ammo;
    [Export] public FireTypeModule FireType;
    [Export] public FireRateModule FireRate;
    [Export] public ProjectileModule Projectile;
    public Item Item { get; set; }

    public override void _Ready()
    {
        Munition mun= new Munition();
        Item = mun.GetItemById(ID);
        Texture = GD.Load<Texture2D>(Item.TextureRoot);

        Scale = new Vector2(24f / Texture.GetSize().X ,24f / Texture.GetSize().Y );
        
        Damage = Damage ?? GetNode<DamageModule>("DamageModule");
        Ammo = Ammo ?? GetNode<AmmoModule>("AmmoModule");
        FireType = FireType ?? GetNode<FireTypeModule>("FireTypeModule");
        FireRate = FireRate ?? GetNode<FireRateModule>("FireRateModule");
        Projectile = Projectile ?? GetNode<ProjectileModule>("ProjectileModule");
        
        
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

    public int[] GetAmmo() => [Ammo.AmmoRemaining, Ammo.CurrentAmmo];
    
    
    
    
}