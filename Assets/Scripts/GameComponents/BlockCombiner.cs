using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockCombiner : MonoBehaviour
{
	public AudioSource CombineSound;
	private int _maxBlockDistance = 25;

	public bool CombineBlocks(List<Block> blockList)
	{
		for (int i = 0; i < blockList.Count - 1; i++)
		{
			for (int j = i + 1; j < blockList.Count; j++)
			{
				if (blockList[i].BlockNumber == blockList[j].BlockNumber)
				{
					float blocksDistance = Vector3.Distance(blockList[i].transform.position, blockList[j].transform.position);

					if (blocksDistance < _maxBlockDistance)
					{
						CombineSound.Play();

						Destroy(blockList[j].gameObject);
						blockList.RemoveAt(j);

						int combinedNumber = NumberManager.CombineBlockNumber(blockList[i].BlockNumber);
						var textNumber = blockList[i].gameObject.GetComponentInChildren<TextMeshProUGUI>();
						textNumber.SetText($"{combinedNumber}");

						return true;
					}
				}
			}
		}
		return false;
	}
}
