using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RecordController : MonoBehaviour
{
    [SerializeField] private RecordRow _recordRowPrefab;
    [SerializeField] private Transform _recordContent;

    private List<RecordRow> _recordRowList = new List<RecordRow>();
    private List<RecordData> _recordDataList = new List<RecordData>();

    private int _recordListCapacity = 10;

    public bool IsNewRecord()
    {
        var score = Score.Number;

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
        record.Initialize(score, DateTime.Now);
        _recordDataList.Add(record);
    }

    private void SaveRecordList()
    {
        var sortedRecords = _recordDataList.OrderByDescending(record => record.Score).ToList();

        if (sortedRecords.Count > _recordListCapacity)
        {
            for (int i = _recordListCapacity; _recordListCapacity < sortedRecords.Count; i++)
                sortedRecords.RemoveAt(i);
        }

        RecordData.Save(sortedRecords);
    }

    private void LoadRecordList()
    {
        _recordDataList = RecordData.Load();

        if (_recordRowList.Count == 0)
        {
            GenerateRecordRow();
        }

        for (int i = 0; i < _recordDataList?.Count; i++)
        {
            var place = i + 1;
            var recordRow = _recordRowList[i];
            recordRow.Initialize(place, _recordDataList[i]);
            recordRow.Show();
        }
    }

    private void GenerateRecordRow()
    {
        for (int i = 0; i < _recordListCapacity; i++)
        {
            var recordRow = Instantiate(_recordRowPrefab, _recordContent);
            recordRow.Hide();
            _recordRowList.Add(recordRow);
        }
    }
}
