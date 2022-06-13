using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class RecordData
{
	public int Score;
	public DateTime DateTime;

	private const string _key = "RecordsList";

	public void Initialize(int score, DateTime dateTime)
	{
		Score = score;
		DateTime = dateTime;
	}

	public static void Save(List<RecordData> list)
	{
		PlayerPrefs.DeleteKey(_key);
		var listJson = JsonConvert.SerializeObject(list, Formatting.Indented);
		PlayerPrefs.SetString(_key, listJson);
	}

	public static List<RecordData> Load()
	{
		var recordsList = JsonConvert.DeserializeObject<List<RecordData>>(PlayerPrefs.GetString(_key));
		return recordsList;
	}
}
