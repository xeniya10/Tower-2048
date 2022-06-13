using UnityEngine;
using TMPro;
using System;

public class Block : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _blockText;
    [SerializeField] private Rigidbody _blockRigidbody;

    private int _blockNumber;

    public event Action BlockCollisionEvent;

    public int BlockNumber
    {
        get => _blockNumber;

        set
        {
            _blockNumber = value;
            _blockText.SetText($"{_blockNumber}");
        }
    }

    public Block Create(Block blockPrefab, Transform blockParent)
    {
        _blockRigidbody.useGravity = true;
        _blockRigidbody.isKinematic = true;
        Block block = Instantiate(blockPrefab, blockParent);
        return block;
    }

    public void Destroy() => Destroy(gameObject);

    public void Drop()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _blockRigidbody.isKinematic = false;
        _blockRigidbody.AddForce(0, -50000, 0, ForceMode.Force);
    }

    public void OnCollisionEnter(Collision collision) => BlockCollisionEvent?.Invoke();
}