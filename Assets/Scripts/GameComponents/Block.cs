using UnityEngine;
using TMPro;
using System;

public class Block : MonoBehaviour
{
	public TextMeshProUGUI BlockText;
	public Rigidbody BlockRigidbody;
	public event Action BlockCollisionEvent;

	public int BlockNumber
	{
		get
		{
			int blockNumber = Int32.Parse(BlockText.text);
			return blockNumber;
		}
		set
		{
			int blockNumber = value;
			BlockText.SetText($"{blockNumber}");
		}
	}
	public Block CreateBlock(Block blockPrefab, Transform blockParent)
	{
		BlockRigidbody.useGravity = true;
		BlockRigidbody.isKinematic = true;
		Block block = Instantiate(blockPrefab, blockParent);
		return block;
	}

	public void PrepareThrowingBlock()
	{
		this.transform.rotation = Quaternion.Euler(0, 0, 0);
		BlockRigidbody.isKinematic = false;
		BlockRigidbody.AddForce(0, -50000, 0, ForceMode.Force);
	}

	public void OnCollisionEnter(Collision collision) => BlockCollisionEvent?.Invoke();
}