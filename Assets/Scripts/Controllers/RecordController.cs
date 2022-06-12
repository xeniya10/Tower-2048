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
	private List<RecordData> _recordList = new List<RecordData>();
	private RecordData _recordData = new RecordData();
	private int _listCapacity = 10;

	public event Action ClickCloseButtonEvent;

	public bool IsNewRecord()
	{
		var score = Score.GetScore();

		if (_recordList.Count == 0 || score > _recordList[_recordList.Count - 1].Score)
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
		_recordList.Add(record);
	}

	private void SaveRecordList()
	{
		var sortedRecords = _recordList.OrderByDescending(record => record.Score).ToList();

		if (sortedRecords.Count > _listCapacity)
		{
			for (int indexRecord = _listCapacity; _listCapacity < sortedRecords.Count; indexRecord++)
				sortedRecords.RemoveAt(indexRecord);
		}

		_recordData.Serialize(sortedRecords);
	}

	private void LoadRecordList()
	{
		_recordList = _recordData.Deserialize();

		if (_recordRowList.Count == 0)
		{
			CreateRecordRow();
		}

		for (int recordIndex = 0; recordIndex < _recordList?.Count; recordIndex++)
		{
			var recordRow = _recordRowList[recordIndex];
			recordRow.Initialize(recordIndex + 1, _recordList[recordIndex].DateTime, _recordList[recordIndex].Score);
			recordRow.gameObject.SetActive(true);
		}
	}

	private void CreateRecordRow()
	{
		for (int recordIndex = 0; recordIndex < _listCapacity; recordIndex++)
		{
			var recordRow = Instantiate(RecordRowPrefab, RecordContent);
			_recordRowList.Add(recordRow);
			_recordRowList[recordIndex].gameObject.SetActive(false);
		}
	}

	public void Show()
	{
		this.gameObject.SetActive(true);
	}

	public void OnClickCloseButton() => ClickCloseButtonEvent?.Invoke();
}
