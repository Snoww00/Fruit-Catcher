using Godot;
using System;



public partial class Fruit : Area2D
{

	[Export]
	public float Speed = 500.0f;
	public override void _Ready()
	{
		Sprite2D Fruitsprite = GetNode<Sprite2D>("Fruit");	

		int randomframe = GD.RandRange(0,12);
		
		Fruitsprite.Frame = randomframe;
	}

	
	public override void _Process(double delta)
	{
		Position += new Vector2(0, Speed * (float)delta);
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body is Basket)
		{
			QueueFree();
		}
	}
}
