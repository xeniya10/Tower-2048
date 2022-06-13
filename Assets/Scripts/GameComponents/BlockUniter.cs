using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class BlockUniter
{
    private static int _maxBlockDistance = 25;

    public static bool TryUniteBlocks(List<Block> blockList)
    {
        for (int i = 0; i < blockList.Count - 1; i++)
        {
            for (int j = i + 1; j < blockList.Count; j++)
            {
                if (blockList[i].BlockNumber == blockList[j].BlockNumber && isBlockClose(blockList[i], blockList[j]))
                {
                    blockList[j].Destroy();
                    blockList.RemoveAt(j);

                    blockList[i].BlockNumber = BlockNumberCalculator.CalculateUnitedBlockNumber(blockList[i].BlockNumber);

                    return true;
                }
            }
        }
        return false;
    }

    private static bool isBlockClose(Block block1, Block block2)
    {
        float blocksDistance = Vector3.Distance(block1.transform.position, block2.transform.position);

        if (blocksDistance < _maxBlockDistance)
            return true;
        else return false;
    }
}
