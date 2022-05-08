using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

public class RecordController : MonoBehaviour
{
	public Record RecordPrefab;
	public Transform RecordContent;

	private string _json;
	private List<Record> _recordsList = new List<Record>();

	public event Action OnClickCloseButtonEvent;

	public bool IsNewRecord(int score)
	{
		if (_recordsList.Count == 0 || _recordsList.Count > 0 && score > _recordsList[_recordsList.Count - 1].Score)
		{
			return true;
		}
		return false;
	}

	private void SaveRecordList()
	{
		_json = JsonConvert.SerializeObject(_recordsList);
	}

	private void LoadRecordList()
	{
		List<Record> recordsList = JsonConvert.DeserializeObject<List<Record>>(_json);
	}

	public void GenerateRecord(int score, DateTime dateTime)
	{
		var record = Instantiate(RecordPrefab, RecordContent);
		record.Score = score;
		record.DateTime = dateTime;
		_recordsList.Add(record);
		_recordsList.Sort((x, y) => x.Score.CompareTo(y.Score));
		record.Place = _recordsList.IndexOf(record) + 1;

		SaveRecordList();
	}

	public void Show()
	{
		this.gameObject.SetActive(true);
	}

	public void OnClickCloseButton() => OnClickCloseButtonEvent?.Invoke();
}
