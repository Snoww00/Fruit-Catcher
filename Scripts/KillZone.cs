using Godot;
using System;

public partial class KillZone : Area2D
{
	public override void _Ready()
	{
		AreaEntered += OnAreaEntered;
	}
	private void OnAreaEntered(Area2D area)
	{
			if (area is Fruit)
		{
			GD.Print("Fruit missed!");
			GameManager.Instance.AddFruitmissed();
			area.QueueFree();
		}
	}
}
