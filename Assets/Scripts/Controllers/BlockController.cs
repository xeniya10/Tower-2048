using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlockController : MonoBehaviour
{
    public Transform BlockTicker;
    public Block BlockPrefab;
    public BlockCombiner BlockCombiner;
    public TowerTicker TowerTicker;
    public AudioSource ThrowingSound;
    public GroundController GroundController;

    [HideInInspector]
    public List<Block> BlockList = new List<Block>();
    public event Action CheckNewScore;

    public void GenerateBlock()
    {
        Block block = BlockPrefab.CreateBlock(BlockPrefab, BlockTicker);
        int blockNumber = NumberGenerator.GenerateBlockNumber(BlockList);
        block.BlockNumber = blockNumber;

        BlockTicker.rotation = Quaternion.Euler(0, 0, 0);
        BlockTicker.gameObject.SetActive(true);
        BlockList.Add(block);
    }
    public void ThrowBlock()
    {
        ThrowingSound.Play();

        var block = BlockList[BlockList.Count - 1];
        block.transform.rotation = Quaternion.Euler(0, 0, 0);
        var blockRigidbody = block.transform.GetComponent<Rigidbody>();
        blockRigidbody.isKinematic = false;
        blockRigidbody.AddForce(0, -50000, 0, ForceMode.Force);
        block.transform.SetParent(TowerTicker.transform);

        block.OnTriggerEvent += CheckNumbers;
        block.OnTriggerEvent += CheckDistance;

        StartCoroutine(CreateNewBlockAfterPause());
    }
    private IEnumerator CreateNewBlockAfterPause()
    {
        yield return new WaitForSeconds(1);
        CheckNewScore?.Invoke();
        BlockTicker.gameObject.SetActive(false);
        GenerateBlock();
    }
    public void ResetBlocks()
    {
        for (int i = 0; i < TowerTicker.transform.childCount; i++)
        {
            Destroy(TowerTicker.transform.GetChild(i).gameObject);
        }

        Destroy(BlockTicker.transform.GetChild(0).gameObject);
        BlockList.Clear();
        GroundController.ResetGroundPosition();
    }
    public void CheckNumbers()
    {
        BlockCombiner.CombineBlocks(BlockList);
    }
    private void CheckDistance()
    {
        if (BlockList.Count > 2)
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
        return maxY;
    }
}