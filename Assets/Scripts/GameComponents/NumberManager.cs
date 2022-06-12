using System.Collections.Generic;
using UnityEngine;

public static class NumberManager
{
	public static int GenerateBlockNumber(List<Block> blockList)
	{
		var minPower = CalculateMinPower(blockList);
		var maxPower = CalculateMaxPower(blockList);
		var randomPower = Random.Range(minPower, maxPower);
		int blockNumber = (int)Mathf.Pow(2, randomPower);
		return blockNumber;
	}

	private static int CalculateMaxPower(List<Block> blockList)
	{
		int maxPower = 3;
		int maxPowerInList = FindMaxBlockPower(blockList);
		if (maxPowerInList > 5)
		{
			maxPower = maxPowerInList - 1;
		}
		return maxPower;
	}

	private static int CalculateMinPower(List<Block> blockList)
	{
		int minPower = 1;
		int maxPowerInList = FindMaxBlockPower(blockList);
		if (maxPowerInList > 5)
		{
			minPower = maxPowerInList - 5;
		}
		return minPower;
	}

	public static int FindMaxBlockPower(List<Block> blockList)
	{
		int maxBlockNumber = FindMaxBlockNumber(blockList);
		int maxPower = (int)Mathf.Log(maxBlockNumber, 2);
		return maxPower;
	}

	public static int FindMaxBlockNumber(List<Block> blockList)
	{
		int maxBlockNumber = 0;
		for (int i = 0; i < blockList.Count; i++)
		{
			if (maxBlockNumber < blockList[i].BlockNumber)
			{
				maxBlockNumber = blockList[i].BlockNumber;
			}
		}
		return maxBlockNumber;
	}

	public static int CombineBlockNumber(int blockNumber)
	{
		float numberPower = Mathf.Log(blockNumber, 2);
		int combinedNumber = (int)Mathf.Pow(2f, numberPower + 1);
		return combinedNumber;
	}
}