using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NumberGenerator
{
    public static int GenerateBlockNumber(List<int> BlockNumberList)
    {
        var minPower = CalculateMinPower(BlockNumberList);
        var maxPower = CalculateMaxPower(BlockNumberList);
        var randomPower = Random.Range(minPower, maxPower);
        int blockNumber = (int)Mathf.Pow(2, randomPower);
        return blockNumber;
    }
    private static int CalculateMaxPower(List<int> BlockNumberList)
    {
        int maxPower = 3;
        int maxPowerInList = FindMaxPowerOfBlocks(BlockNumberList);
        if (maxPowerInList > 5)
        {
            maxPower = maxPowerInList - 1;
        }
        return maxPower;
    }
    private static int CalculateMinPower(List<int> BlockNumberList)
    {
        int minPower = 1;
        int maxPowerInList = FindMaxPowerOfBlocks(BlockNumberList);
        if (maxPowerInList > 5)
        {
            minPower = maxPowerInList - 3;
        }
        return minPower;
    }

    public static int FindMaxPowerOfBlocks(List<int> BlockNumberList)
    {
        int maxBlockNumber = 0;
        for (int i = 0; i < BlockNumberList.Count; i++)
        {
            if (maxBlockNumber < BlockNumberList[i])
            {
                maxBlockNumber = BlockNumberList[i];
            }
        }
        int maxPower = (int)Mathf.Log(maxBlockNumber, 2);
        return maxPower;
    }

    public static int CombineBlockNumber(int blockNumber)
    {
        float numberPower = Mathf.Log(blockNumber, 2);
        int combinedNumber = (int)Mathf.Pow(2f, numberPower + 1);
        return combinedNumber;
    }
}
