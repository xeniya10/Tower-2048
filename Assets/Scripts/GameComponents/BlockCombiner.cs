using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockCombiner : MonoBehaviour
{
    public AudioSource CombineSound;

    public void CombineBlocks(List<Block> BlockList, List<int> BlockNumberList)
    {
        for (int i = 0; i < BlockNumberList.Count - 1; i++)
        {
            for (int j = i + 1; j < BlockNumberList.Count; j++)
            {
                if (BlockNumberList[i] == BlockNumberList[j])
                {
                    float blocksDistance = Vector3.Distance(BlockList[i].transform.position, BlockList[j].transform.position);
                    if (blocksDistance < 7.6f)
                    {
                        CombineSound.Play();

                        Destroy(BlockList[j].gameObject);
                        BlockList.RemoveAt(j);
                        BlockNumberList.RemoveAt(j);

                        int combinedNumber = NumberGenerator.CombineBlockNumber(BlockNumberList[i]);
                        var textNumber = BlockList[i].gameObject.GetComponentInChildren<TextMeshProUGUI>();
                        textNumber.SetText($"{combinedNumber}");

                        BlockNumberList.RemoveAt(i);
                        BlockNumberList.Insert(i, combinedNumber);
                    }
                }
            }

        }
    }
}
