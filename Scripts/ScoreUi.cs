using Godot;
using System;

public partial class ScoreUi : Label
{
	public override void _Ready()
	{
		Text = "Score: 0";

		GameManager.OnScoreChanged += UpdateScore;
	}
	
	private void UpdateScore(int currentScore)
	{
		Text = $"Score: {currentScore}";

	}

	public override void _ExitTree()
	{
		GameManager.OnScoreChanged -= UpdateScore;
	}
}
