using System.IO;
using Godot;
using System.Text.Json;

namespace newcorrupt.game.extraUtilities;


/*
 *MoveScript work
 *
 * Movescript.Enity = this
 *     @Entity is RigidBody 
 * walk 102 100 20
 * stop 10
 * walk&attack 102 100 20 2
 * stop&attack 10 2
 * talk text.txt
 * give item.json
 * print {all, props, }
 */


public class MoveScript
{
    public RigidBody2D Entity;
    
    

    public Item ItemParser(string path)
    {
        if (File.Exists(path))
        {
            string Jsontext = File.ReadAllText(path);
            Item item = JsonSerializer.Deserialize<Item>(Jsontext);
            return item;
        }        
        //if item not exists:
        Item nullItem = new Item();
        nullItem.Name = "null";
        nullItem.Id = -1;
        nullItem.TextureRoot = "res://newcorrupt/images/items/tears.png";
        return nullItem;
    }
    
    
    

    public void TextParce(string text)
    {
        string[] lines = text.Split("\n");
        foreach (var line in lines)
        {
            string[] words = line.Split(" ");
            switch (words[0])
            {
                case "walk":
                    Vector2 newPos = new Vector2(float.Parse(words[1]), float.Parse(words[2]));
                    float time = float.Parse(words[3]);
                    Vector2 direction = newPos - Entity.Position;
                    float distance = direction.Length();
                    direction = direction.Normalized();
                    Vector2 velocity = direction * (distance / time);
                    if (Entity.GetNode("move") is WalkScript script)
                        script.MoveEntityToPosition(velocity, time);
                    break;
                case "stop":
                    break;
                case "walk&attack":
                    
                    
                    break;
            }
        }
    }
}