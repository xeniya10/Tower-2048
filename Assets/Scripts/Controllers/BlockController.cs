using System.Collections.Generic;
using UnityEngine;
using System;

public class BlockController : MonoBehaviour
{
	public Block BlockPrefab;
	public BlockCombiner BlockCombiner;
	public BlockTicker BlockTicker;
	public TowerTicker TowerTicker;
	public GroundController GroundController;
	public AudioSource ThrowingSound;

	[HideInInspector]
	private List<Block> _tickerBlockList = new List<Block>();
	public List<Block> TowerBlockList = new List<Block>();
	public event Action CheckNewScore;

	public void GenerateBlock()
	{
		if (_tickerBlockList.Count == 0)
		{
			Block block = BlockPrefab.CreateBlock(BlockPrefab, BlockTicker.transform);
			block.BlockNumber = NumberManager.GenerateBlockNumber(TowerBlockList);
			block.BlockCollisionEvent += CheckNumbers;
			block.BlockCollisionEvent += CheckDistance;
			block.BlockCollisionEvent += GenerateBlock;
			_tickerBlockList.Add(block);

			BlockTicker.ResetTicker();
		}
	}

	public void ThrowBlock()
	{
		ThrowingSound.Play();

		if (_tickerBlockList.Count == 0)
		{
			GenerateBlock();
		}

		var block = _tickerBlockList[0];
		TowerBlockList.Add(block);
		_tickerBlockList.Clear();
		block.PrepareThrowingBlock();

		block.transform.SetParent(TowerTicker.transform);
	}

	public void ResetBlocks()
	{
		for (int i = 0; i < TowerTicker.transform.childCount; i++)
		{
			Destroy(TowerTicker.transform.GetChild(i).gameObject);
		}

		for (int i = 0; i < BlockTicker.transform.childCount; i++)
		{
			Destroy(BlockTicker.transform.GetChild(i).gameObject);
		}

		_tickerBlockList.Clear();
		TowerBlockList.Clear();

		GroundController.ResetGroundPosition();
	}

	public void CheckNumbers()
	{
		if (BlockCombiner.CombineBlocks(TowerBlockList))
		{
			CheckNumbers();
			CheckDistance();
		}

		CheckNewScore?.Invoke();
	}

	private void CheckDistance()
	{
		if (TowerBlockList.Count > 2)
		{
			if (GroundController.isTooHigh(FindTopBlockTower()))
			{
				TowerTicker.DownTickerTower();
			}

			if (GroundController.isTooLow(FindTopBlockTower()))
			{
				TowerTicker.UpTickerTower();
			}
		}
	}

	private float FindTopBlockTower()
	{
		float maxY = TowerBlockList[0].transform.position.y;

		for (int i = 0; i < TowerBlockList.Count - 1; i++)
		{
			if (maxY < TowerBlockList[i].transform.position.y)
			{
				maxY = TowerBlockList[i].transform.position.y;
			}
		}
		return maxY;
	}
}