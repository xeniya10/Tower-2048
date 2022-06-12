using UnityEngine;
using TMPro;
using System;

public class Record : MonoBehaviour
{
	public TextMeshProUGUI PlaceText;
	public TextMeshProUGUI DateTimeText;
	public TextMeshProUGUI ScoreText;

	// public void Initialize(int place, DateTime dateTime, int score)
	{
		PlaceText.text = place.ToString();
		DateTimeText.text = dateTime.ToString("dd/MM/yy hh:mm");
		ScoreText.text = score.ToString();
	}
}
