using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Record : MonoBehaviour
{
	public TextMeshProUGUI PlaceNumber;
	public TextMeshProUGUI DateTimeRecord;
	public TextMeshProUGUI ScoreNumber;

	public void Initialize(int place, DateTime dateTime, int score)
	{
		PlaceNumber.text = place.ToString();
		DateTimeRecord.text = dateTime.ToString("dd/MM/yy hh:mm");
		ScoreNumber.text = score.ToString();
	}
}
