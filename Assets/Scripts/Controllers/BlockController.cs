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
    public TowerTicker TowerTicker;
    public AudioSource ThrowingSound;
    public GroundController GroundController;

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

        var block = BlockList[BlockList.Count - 1];
        block.transform.rotation = Quaternion.Euler(0, 0, 0);
        SetRigidbodyOfThrowingBlock(block);
        block.transform.SetParent(BlockTower);

        block.OnTriggerEvent += CheckNumbers;
        block.OnTriggerEvent += CheckDistance;

        PrepareBeforeCreationBlock();

        StartCoroutine(CreateNewBlockAfterPause());
    }
    private IEnumerator CreateNewBlockAfterPause()
    {
        yield return new WaitForSeconds(1);
        GenerateBlock();
    }
    private void PrepareBeforeCreationBlock()
    {
        var blockTicker = BlockTicker.gameObject.GetComponent<BlockTicker>();
        BlockTicker.rotation = blockTicker.ResetAngleOfTicker();
        BlockTicker.gameObject.SetActive(false);
    }
    public void CheckNumbers()
    {
        BlockCombiner.CombineBlocks(BlockList, BlockNumberList);
    }
    private void SetRigidbodyOfThrowingBlock(Block block)
    {
        var blockRigidbody = block.transform.GetComponent<Rigidbody>();
        blockRigidbody.useGravity = true;
        blockRigidbody.isKinematic = false;
        blockRigidbody.velocity = new Vector3(0, -100, 0);
    }
    private void CheckDistance()
    {
        if (GroundController.isTooHigh(FindTopBlockTower()))
        {
            GroundController.MoveGroundDown(FindTopBlockTower());
            TowerTicker.DownTickerTower();
        }
        if (GroundController.isTooLow(FindTopBlockTower()))
        {
            GroundController.MoveGroundUp(FindTopBlockTower());
            TowerTicker.UpTickerTower();
        }
    }

    private float FindTopBlockTower()
    {
        float maxY = BlockList[0].transform.position.y;
        for (int i = 0; i < BlockList.Count - 1; i++)
        {
            if (maxY < BlockList[i].transform.position.y)
            {
                maxY = BlockList[i].transform.position.y;
            }
        }
        Debug.Log(maxY);
        return maxY;
    }
}

