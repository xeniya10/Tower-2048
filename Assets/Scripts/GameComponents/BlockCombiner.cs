using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class BlockCombiner : MonoBehaviour
{
	public AudioSource CombineSound;
	private int _maxBlockDistance = 25;

	public bool TryCombineBlocks(List<Block> blockList)
	{
		for (int i = 0; i < blockList.Count - 1; i++)
		{
			for (int j = i + 1; j < blockList.Count; j++)
			{
				if (blockList[i].BlockNumber == blockList[j].BlockNumber && 
				    isBlockCollides(blockList[i], blockList[j]))
				{
					CombineSound.Play();

					// Destroy(blockList[j].gameObject);
					// blockList.RemoveAt(j);

					int combinedNumber = NumberManager.CombineBlockNumber(blockList[i].BlockNumber);
					var textNumber = blockList[i].gameObject.GetComponentInChildren<TextMeshProUGUI>();
					textNumber.SetText($"{combinedNumber}");

					return true;
				}
			}
		}
		return false;
	}

	private bool isBlockCollides(Block block1, Block block2)
	{
		return Vector3.Distance(block1.transform.position, block2.transform.position) < _maxBlockDistance;
	}

}
