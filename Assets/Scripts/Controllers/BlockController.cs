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
    public AudioSource ThrowingSound;

    [HideInInspector]
    public List<Block> BlockList = new List<Block>();

    [HideInInspector]
    public List<int> BlockNumberList = new List<int>();

    public void GenerateBlock()
    {
        Block block = BlockPrefab.CreateBlock(BlockPrefab, BlockTicker);
        int blockNumber = NumberGenerator.GenerateBlockNumber(BlockNumberList);
        block.SetBlockNumber(blockNumber);
        BlockTicker.gameObject.SetActive(true);
        BlockNumberList.Add(blockNumber);
        BlockList.Add(block);
    }
    public void ThrowBlock()
    {
        ThrowingSound.Play();

        var block = BlockList[BlockList.Count - 1].transform;
        block.rotation = Quaternion.Euler(0, 0, 0);

        var blockRigidbody = block.GetComponent<Rigidbody>();
        blockRigidbody.useGravity = true;
        blockRigidbody.isKinematic = false;
        blockRigidbody.velocity = new Vector3(0, -40, 0);

        block.SetParent(BlockTower);
        BlockTicker.gameObject.SetActive(false);

        if (blockRigidbody.velocity == new Vector3(0, 0, 0))
        {
            CheckNumbers();
        }

        StartCoroutine(CreateNewBlockAfterPause());
    }
    private IEnumerator CreateNewBlockAfterPause()
    {
        yield return new WaitForSeconds(1.5f);

        var blockTicker = BlockTicker.gameObject.GetComponent<BlockTicker>();
        BlockTicker.rotation = blockTicker.ResetAngleOfTicker();

        GenerateBlock();
    }
    private void CheckNumbers()
    {
        BlockCombiner.CombineBlocks(BlockList, BlockNumberList);
    }
}

