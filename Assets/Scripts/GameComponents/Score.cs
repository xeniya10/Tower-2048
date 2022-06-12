using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
	public TextMeshProUGUI ScoreText;

	public void ResetScore()
	{
		ScoreText.SetText("0");
	}

	// public void SetScore(List<Block> list)
	// {
		// ScoreText.text = NumberManager.FindMaxBlockNumber(list).ToString();
	// }

	public int GetScore()
	{
		int scoreNumber = Int32.Parse(ScoreText.text);
		return scoreNumber;
	}
}
