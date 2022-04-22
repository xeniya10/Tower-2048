using UnityEngine;
using TMPro;
using System;

public class Block : MonoBehaviour
{
    public TextMeshProUGUI TextBlock;
    public delegate void ColliderTrigger();
    public event ColliderTrigger OnTriggerEvent;

    public int BlockNumber
    {
        get
        {
            int blockNumber = Int32.Parse(TextBlock.text);
            return blockNumber;
        }
        set
        {
            int blockNumber = value;
            TextBlock.SetText($"{blockNumber}");
        }
    }
    public Block CreateBlock(Block blockPrefab, Transform blockParent)
    {
        Block block = Instantiate(blockPrefab, blockParent);
        var blockRigidbody = this.GetComponent<Rigidbody>();
        blockRigidbody.useGravity = true;
        blockRigidbody.isKinematic = true;
        return block;
    }
    public void OnCollisionEnter(Collision collision) => OnTriggerEvent?.Invoke();
}