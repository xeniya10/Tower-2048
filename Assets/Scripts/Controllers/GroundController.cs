using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public BlockController BlockController;
    public GroundMover GroundMover;
    public TowerTicker TowerTicker;
    public void MoveGroundControl()
    {
        var blocks = BlockController.BlockList;

        if (blocks.Count > 2 && Vector3.Distance(blocks[blocks.Count - 1].transform.position, blocks[blocks.Count - 2].transform.position) < 18f)
        {
            StartCoroutine(GroundMover.MoveGroundDown());
            TowerTicker.TowerAngle += 0.06f;
            TowerTicker.TowerSpeed += 0.03f;
        }

        if (blocks.Count > 10 && Vector3.Distance(blocks[blocks.Count - 1].transform.position, blocks[blocks.Count - 2].transform.position) > 35f)
        {
            StartCoroutine(GroundMover.MoveGroundUp());
        }
    }
}
