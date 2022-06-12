using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class RecordData
{
	public DateTime DateTime;
	public int Score;

	private const string _key = "RecordsList";

	// public static void Serialize(List<RecordData> list)
	{
		PlayerPrefs.DeleteKey(_key);
		var json = JsonConvert.SerializeObject(list, Formatting.Indented);
		PlayerPrefs.SetString(_key, json);
	}

	// public static List<RecordData> Deserialize()
	{
		var recordsList = JsonConvert.DeserializeObject<List<RecordData>>(PlayerPrefs.GetString(_key));
		return recordsList;
	}
}
