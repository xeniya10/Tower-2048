using System.Collections.Generic;
using UnityEngine;
using System;

public class BlockController : MonoBehaviour
{
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private BlockTicker _blockTicker;
    [SerializeField] private TowerTicker _towerTicker;
    [SerializeField] private GroundController _groundController;
    [SerializeField] private AudioManager _audioManager;

    [HideInInspector] public List<Block> BlockList = new List<Block>();
    private Block _swiningBlock = null;

    public event Action UpdateScoreEvent;

    public void GenerateBlock()
    {
        if (_swiningBlock == null)
        {
            Block block = _blockPrefab.Create(_blockPrefab, _blockTicker.transform);
            block.BlockNumber = BlockNumberCalculator.GenerateBlockNumber(BlockList);
            block.BlockCollisionEvent += CheckNumbers;
            block.BlockCollisionEvent += CheckDistanceBetweenBlocks;
            block.BlockCollisionEvent += GenerateBlock;
            _swiningBlock = block;

            _blockTicker.ResetTicker();
        }
    }

    public void DropBlock()
    {
        GenerateBlock();

        _audioManager.PlayDropingSound();

        var block = _swiningBlock;
        BlockList.Add(block);
        block.Drop();
        _towerTicker.ChangeParent(block);

        _swiningBlock = null;
    }

    public void ResetBlocks()
    {
        _blockTicker.DestroyChildren();
        _towerTicker.DestroyChildren();

        _swiningBlock = null;
        BlockList.Clear();
    }

    private void CheckNumbers()
    {
        if (BlockUniter.TryUniteBlocks(BlockList))
        {
            _audioManager.PlayUnitingSound();
            CheckNumbers();
            CheckDistanceBetweenBlocks();
        }

        UpdateScoreEvent?.Invoke();
    }

    private void CheckDistanceBetweenBlocks()
    {
        if (BlockList.Count > 2)
        {
            float yMaxPos = GetTowerMaxY();

            if (_groundController.IsTooHigh(yMaxPos))
            {
                _towerTicker.DecreaseTowerSwinging();
                return;
            }

            if (_groundController.IsTooLow(yMaxPos))
            {
                _towerTicker.IncreaseTowerSwinging();
                return;
            }
        }
    }

    private float GetTowerMaxY()
    {
        float maxY = BlockList[0].transform.position.y;

        for (int i = 0; i < BlockList.Count - 1; i++)
        {
            if (maxY < BlockList[i].transform.position.y)
            {
                maxY = BlockList[i].transform.position.y;
            }
        }
        return maxY;
    }
}