using UnityEngine;
using TMPro;
using System;

public class Block : MonoBehaviour
{
	public TextMeshProUGUI BlockText;
	public Rigidbody BlockRigidbody;
	public event Action BlockCollisionEvent;

	private int _blockValue;

	public int BlockNumber
	{
		get => _blockValue;
		set
		{
			_blockValue = value;
			BlockText.SetText($"{_blockValue}");
		}
	}
	public Block CreateBlock(Block blockPrefab, Transform blockParent)
	{
		BlockRigidbody.useGravity = true;
		BlockRigidbody.isKinematic = true;
		Block block = Instantiate(blockPrefab, blockParent);
		return block;
	}

	public void Throw()
	{
		this.transform.rotation = Quaternion.Euler(0, 0, 0);
		BlockRigidbody.isKinematic = false;
		BlockRigidbody.AddForce(0, -50000, 0, ForceMode.Force);
	}

	public void OnCollisionEnter(Collision collision) => BlockCollisionEvent?.Invoke();
}