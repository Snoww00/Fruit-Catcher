using Godot;
using System;
using System.Collections.Generic;

public partial class FruitSpawner : Node2D
{
	[Export]
	public PackedScene FruitScene;

	private List<Marker2D> spawnPoints = new List<Marker2D>();

	private int _spawncount = 0;
	
	public override void _Ready()
	{
		foreach (Node child in GetChildren())
		{
			if (child is Marker2D marker)
			{
				spawnPoints.Add(marker);
			}
		}
		Timer timer = GetNode<Timer>("Timer");
		timer.Timeout += OnTimerTimeout;

	}
	
	private void OnTimerTimeout()
	{
		if (FruitScene == null || spawnPoints.Count == 0) return;

		Fruit newFruit = (Fruit)FruitScene.Instantiate();
		int randomIndex = GD.RandRange(0, spawnPoints.Count - 1);
		Marker2D chosenMarker = spawnPoints[randomIndex];
		newFruit.Position = chosenMarker.Position;
		newFruit.Speed = newFruit.Speed + (_spawncount * 10);
		_spawncount = _spawncount + 1;
		AddChild(newFruit);
	}
}
