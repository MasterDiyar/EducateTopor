using Godot;

public class WeaponSlotData
{
    public Button Button;
    public Weapon WeaponRef;
    public PackedScene Scene;

    public WeaponSlotData(Button button, Weapon weaponRef, PackedScene scene)
    {
        Button = button;
        WeaponRef = weaponRef;
        Scene = scene;
    }
}