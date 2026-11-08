using Godot;
using System;

public partial class GameManager : Node
{
	public static event Action<int> OnScoreChanged;
	
	public int _currentscore = 0;
	
	public void AddScore(int pointsToGive)
	{
	_currentscore = _currentscore + pointsToGive;
	
	OnScoreChanged?.Invoke(_currentscore);
	}
}
