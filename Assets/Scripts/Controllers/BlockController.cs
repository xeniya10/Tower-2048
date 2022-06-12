using System.Collections.Generic;
using UnityEngine;
using System;
using JetBrains.Annotations;
using UnityEditor;

public class BlockController : MonoBehaviour
{
	// private Block BlockPrefab;
	// private BlockCombiner BlockCombiner;
	// private BlockTicker BlockTicker;
	// private TowerTicker TowerTicker;
	// private GroundController GroundController;
	// private AudioSource ThrowingSound;

	private List<Block> _tickerBlockList = new List<Block>();
	
	[HideInInspector]
	public List<Block> TowerBlockList = new List<Block>();
	public event Action UpdateScore;

	private Block swingBlock = null;

	public void GenerateBlock()
	{
		if (swingBlock == null)
		{
			Block block = BlockPrefab.CreateBlock(BlockPrefab, BlockTicker.transform);
			block.BlockNumber = NumberManager.GenerateBlockNumber(TowerBlockList);
			block.BlockCollisionEvent += CheckNumbers;
			block.BlockCollisionEvent += CheckDistanceBetweenBlocks;
			block.BlockCollisionEvent += GenerateBlock;
			swingBlock = block;

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
		swingBlock = null;
		// block.transform.SetParent(TowerTicker.transform);
	}

	public void ResetBlocks()
	{
		// for (int i = 0; i < TowerTicker.transform.childCount; i++)
		// {
		// 	Destroy(TowerTicker.transform.GetChild(i).gameObject);
		// }
		//
		// for (int i = 0; i < BlockTicker.transform.childCount; i++)
		// {
		// 	Destroy(BlockTicker.transform.GetChild(i).gameObject);
		// }

		_tickerBlockList.Clear();
		TowerBlockList.Clear();

		// GroundController.ResetGroundPosition();
	}

	public void CheckNumbers()
	{
		if (BlockCombiner.TryCombineBlocks(TowerBlockList))
		{
			CheckNumbers();
			CheckDistanceBetweenBlocks();
		}

		UpdateScore?.Invoke();
	}

	private void CheckDistanceBetweenBlocks()
	{
		if (TowerBlockList.Count > 2)
		{
			var yMaxPos = GetTowerMaxY();
			
			if (GroundController.isTooHigh(yMaxPos))
			{
				TowerTicker.DownTickerTower();
				return;
			}

			if (GroundController.isTooLow(yMaxPos))
			{
				TowerTicker.UpTickerTower();
				return;
			}
		}
	}

	private float GetTowerMaxY()
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