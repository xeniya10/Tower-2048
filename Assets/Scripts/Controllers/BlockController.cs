using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public static BlockController Instance { get; private set; }
    public Transform BlockTicker;
    public Transform BlockTower;
    public Block BlockPrefab;
    public BlockCombiner BlockCombiner;

    [HideInInspector]
    public List<Block> BlockList = new List<Block>();

    [HideInInspector]
    public List<int> BlockNumberList = new List<int>();

    public Block GenerateBlock()
    {
        Block block = BlockPrefab.CreateBlock(BlockPrefab, BlockTicker);
        int blockNumber = NumberGenerator.GenerateBlockNumber();
        block.SetBlockNumber(blockNumber);
        BlockNumberList.Add(blockNumber);
        BlockList.Add(block);
        return block;
    }

    public void Update()
    {
        BlockCombiner.CombineBlocks(BlockList, BlockNumberList);
    }
}

