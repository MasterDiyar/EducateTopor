using Godot;
using System;

public partial class MouseTrack : Node2D
{
	[Export] public Node2D Target;
	public override void _Ready() =>
		 Target =Target??GetParent<Node2D>();
	public override void _Process(double delta)
	{
		Target.LookAt(GetGlobalMousePosition());
	}
}
