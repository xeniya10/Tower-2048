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

	public int Score
	{
		get
		{
			var scoreNumber = Int32.Parse(ScoreNumber.text);
			return scoreNumber;
		}
		set
		{
			int scoreNumber = value;
			ScoreNumber.SetText($"{scoreNumber}");
		}
	}

	public DateTime DateTime
	{
		get
		{
			var dateTime = DateTime.Parse(DateTimeRecord.text);
			return dateTime;
		}
		set
		{
			DateTime dateTime = value;
			DateTimeRecord.SetText(dateTime.ToString("dd/MM/yy hh:mm"));
		}
	}

	public int Place
	{
		get
		{
			var placeNumber = Int32.Parse(PlaceNumber.text);
			return placeNumber;
		}
		set
		{
			int placeNumber = value;
			PlaceNumber.SetText($"{placeNumber}");
		}
	}
}
