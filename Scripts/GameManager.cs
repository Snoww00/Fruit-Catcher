using Godot;
using System;

public partial class GameManager : Node
{
	public static event Action<int> OnScoreChanged;
	public static GameManager Instance { get; private set; }

	[Export] public  int MaxFruitsMissed = 3;
	private int _fruitsmissed = 0;
	public int _currentscore = 0;
	
	public void AddScore(int pointsToGive)
	{
	_currentscore = _currentscore + pointsToGive;
	
	OnScoreChanged?.Invoke(_currentscore);
	}

	public override void _Ready()
	{
		Instance = this;
	}
public void AddFruitmissed()
	{
		_fruitsmissed++;
		if (_fruitsmissed >= MaxFruitsMissed)
		{
			GD.Print("Game Over");
			_fruitsmissed = 0;
			// Handle game over logic here (e.g., show game over screen, reset the game)
			GetTree().ReloadCurrentScene();
		}
	}




}
