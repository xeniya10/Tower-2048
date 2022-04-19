using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public BlockController BlockController;
    public GroundController GroundController;

    private void Start()
    {
        BlockController.GenerateBlock();
    }

    public void OnTouchScreen()
    {
        BlockController.ThrowBlock();
        GroundController.MoveGroundControl();
    }
}
