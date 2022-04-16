using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    public TextMeshProUGUI TextBlock;
    public void SetBlockNumber(int BlockNumber)
    {
        TextBlock.SetText($"{BlockNumber}");
    }
    public Block CreateBlock(Block BlockPrefab, Transform BlockParent)
    {
        Block block = Instantiate(BlockPrefab, BlockParent);
        var blockRigidbody = this.GetComponent<Rigidbody>();
        blockRigidbody.isKinematic = true;
        return block;
    }
}