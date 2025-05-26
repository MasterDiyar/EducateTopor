using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 80.0f;
	private Weapon _weapon;
	private Node2D _weaponSlot;
	public override void _Ready()
	{
		GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("move");
		_weaponSlot = GetNode("WeaponSlot") as Node2D;
		_weapon = _weaponSlot.GetNode<Weapon>("weapon");

	}

	public override void _PhysicsProcess(double delta)
	{
		Attack();
		
		
		Vector2 velocity = Velocity;
		
		Vector2 direction = Input.GetVector("a", "d", "w", "s");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
	public void EquipWeapon(PackedScene weaponScene)
    {
        // удалить старое оружие
        if (_weapon != null)
        {
            _weapon.QueueFree();
            _weapon = null;
        }

        var newWeaponNode = weaponScene.Instantiate<Weapon>();
        _weaponSlot.AddChild(newWeaponNode);
        _weapon = newWeaponNode;
    }

	//В качестве временного решения движение игрока и смена оружия будет находится в главном скрипте
	//Потенциальное перемещение кода будет когда код будет совсем не читабельным

	private void Attack(bool type = false)
	{
		if (Input.IsActionPressed("attack"))
			_weapon.Fire();
	}
}
