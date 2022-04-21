using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Block : MonoBehaviour
{
    public TextMeshProUGUI TextBlock;
    public delegate void ColliderTrigger();
    public event ColliderTrigger OnTriggerEvent;
    // TODO properties with set and get block numbers
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
    public void OnCollisionEnter(Collision collision) => OnTriggerEvent?.Invoke();
}