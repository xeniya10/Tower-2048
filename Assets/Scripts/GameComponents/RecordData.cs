using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class RecordData
{
	public DateTime DateTime;
	public int Score;

	private string _json;
	private const string _key = "RecordsList";

	public void Serialize(List<RecordData> list)
	{
		PlayerPrefs.DeleteKey(_key);
		_json = JsonConvert.SerializeObject(list, Formatting.Indented);
		PlayerPrefs.SetString(_key, _json);
	}

	public List<RecordData> Deserialize()
	{
		var recordsList = JsonConvert.DeserializeObject<List<RecordData>>(PlayerPrefs.GetString(_key));
		return recordsList;
	}
}
