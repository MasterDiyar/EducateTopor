using Godot;
using newcorrupt.game.extraUtilities;
using System;

public partial class ItemSet : Node2D
{
    [Export] int id;
    public Item ThisItem { get; set; }
    public Weapon parent;
    public override void _Ready()
    {
        Munition munition = new();
        MoveScript script = new();
        ThisItem = script.ItemParser(munition.GetItemNameById(id));
        parent = GetParent<Weapon>();
        parent.Item = ThisItem;
    }
}
