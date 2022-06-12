using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RecordController : MonoBehaviour
{
	public Score Score;
	public Record RecordRowPrefab;
	public Transform RecordContent;

	private List<Record> _recordRowList = new List<Record>();
	private List<RecordData> _recordDataList = new List<RecordData>();
	
	// private int _listCapacity = 10;

	public event Action ClickCloseButtonEvent;

	public bool IsNewRecord()
	{
		var score = Score.GetScore();

		if (_recordDataList.Count == 0 || score > _recordDataList[_recordDataList.Count - 1].Score)
		{
			GenerateRecord(score);
			SaveRecordList();
			LoadRecordList();
			return true;
		}
		return false;
	}

	public void GenerateRecord(int score)
	{
		var record = new RecordData();
		record.Score = score;
		record.DateTime = DateTime.Now;
		_recordDataList.Add(record);
	}

	private void SaveRecordList()
	{
		var sortedRecords = _recordDataList.OrderByDescending(record => record.Score).ToList();

		if (sortedRecords.Count > _listCapacity)
		{
			for (int indexRecord = _listCapacity; _listCapacity < sortedRecords.Count; indexRecord++)
				sortedRecords.RemoveAt(indexRecord);
		}

		RecordData.Serialize(sortedRecords);
	}

	private void LoadRecordList()
	{
		_recordDataList = RecordData.Deserialize();

		if (_recordRowList.Count == 0)
		{
			CreateRecordRow();
		}

		for (int recordIndex = 0; recordIndex < _recordDataList?.Count; recordIndex++)
		{
			var recordRow = _recordRowList[recordIndex];
			recordRow.Initialize(recordIndex + 1, _recordDataList[recordIndex].DateTime, _recordDataList[recordIndex].Score);
			recordRow.gameObject.SetActive(true);
		}
	}

	private void CreateRecordRow()
	{
		for (int i = 0; i < _listCapacity; i++)
		{
			var recordRow = Instantiate(RecordRowPrefab, RecordContent);
			_recordRowList.Add(recordRow);
			_recordRowList[i].gameObject.SetActive(false);
		}
	}

	// public void Show()
	{
		this.gameObject.SetActive(true);
	}

	public void OnClickCloseButton() => ClickCloseButtonEvent?.Invoke();
}
