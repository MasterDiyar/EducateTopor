using System.Text.Json;
using Godot;

namespace newcorrupt.game.extraUtilities;

public class JsonTwoDot
{
    public void SaveInventory(PlayerIntertface.Inventory inventory)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true // делает JSON читаемым
        };

        string json = JsonSerializer.Serialize(inventory, options);
        string path = "res://game/player/data/inventory.json";

        using var file = FileAccess.Open(path, FileAccess.ModeFlags.Write);
        file.StoreString(json);
        file.Close();
    }

    public void GetFromStatic()
    {
        var lalka =JsonSerializer.Deserialize<PlayerIntertface.Inventory>(FileAccess.Open("res://game/player/data/StaticInventory.json", FileAccess.ModeFlags.Read).GetAsText());
        SaveInventory(lalka);
    }
}