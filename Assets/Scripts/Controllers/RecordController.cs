using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RecordController : MonoBehaviour
{
	public Score Score;
	public Record RecordPrefab;
	public Transform RecordContent;

	private List<Record> _recordRowList = new List<Record>();
	private List<RecordData> _recordList = new List<RecordData>();
	private List<RecordData> _deserializedRecordList = new List<RecordData>();
	private RecordData _recordData = new RecordData();
	private int _listCapacity = 10;

	int i = 0;

	public event Action OnClickCloseButtonEvent;

	public bool IsNewRecord(int score)
	{
		// var score = Score.GetScore();
		i++;
		Debug.Log(i);
		if (_recordList.Count == 0 || score > _deserializedRecordList[_deserializedRecordList.Count - 1].Score)
		{
			GenerateRecord(score);
			return true;
		}
		return false;
	}

	private void LoadRecordList()
	{
		_deserializedRecordList = _recordData.Deserialize();

		if (_recordRowList.Count == 0)
		{
			CreateRecordRow();
		}

		// DisableRecordRow();


		for (int recordIndex = 0; recordIndex < _deserializedRecordList?.Count; recordIndex++)
		{
			var recordRow = _recordRowList[recordIndex];
			recordRow.Initialize(recordIndex + 1, _deserializedRecordList[recordIndex].DateTime, _deserializedRecordList[recordIndex].Score);
			recordRow.gameObject.SetActive(true);
		}
	}

	private void CreateRecordRow()
	{
		for (int recordIndex = 0; recordIndex < _listCapacity; recordIndex++)
		{
			var recordRow = Instantiate(RecordPrefab, RecordContent);
			_recordRowList.Add(recordRow);
			_recordRowList[recordIndex].gameObject.SetActive(false);
		}
	}

	private void DisableRecordRow()
	{
		for (int recordIndex = 0; recordIndex < _listCapacity; recordIndex++)
		{
			_recordRowList[recordIndex].gameObject.SetActive(false);
		}
	}

	public void GenerateRecord(int score)
	{
		var record = new RecordData();
		record.Score = score;
		record.DateTime = DateTime.Now;
		_recordList.Add(record);
		Debug.Log(_recordList.Count);
		var sortedRecords = _recordList.OrderByDescending(record => record.Score).ToList();

		if (sortedRecords.Count > _listCapacity)
		{
			for (int indexRecord = _listCapacity; _listCapacity < sortedRecords.Count; indexRecord++)
				sortedRecords.RemoveAt(indexRecord);
		}

		_recordData.Serialize(sortedRecords);
		LoadRecordList();
	}

	public void Show()
	{
		this.gameObject.SetActive(true);
	}

	public void OnClickCloseButton() => OnClickCloseButtonEvent?.Invoke();
}
