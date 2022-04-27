using UnityEngine;

public class GroundController : MonoBehaviour
{
    public GroundMover GroundMover;
    public TowerTicker TowerTicker;
    private float _maxBlockPosition = -13f;
    private float _minBlockPosition = -36f;

    public bool isTooHigh(float TopTowerBlockPosition)
    {
        if (TopTowerBlockPosition > _maxBlockPosition)
        {
            return true;
        }
        return false;
    }
    public bool isTooLow(float TopTowerBlockPosition)
    {
        if (TopTowerBlockPosition < _minBlockPosition)
        {
            return true;
        }
        return false;
    }
    public void MoveGroundDown(float TopTowerBlockPosition)
    {
        var difference = Mathf.Abs(TopTowerBlockPosition - _maxBlockPosition) + 3f;
        StartCoroutine(GroundMover.DownGround(difference));
    }
    public void MoveGroundUp(float TopTowerBlockPosition)
    {
        var difference = Mathf.Abs(TopTowerBlockPosition - _minBlockPosition) + 3f;
        StartCoroutine(GroundMover.UpGround(difference));
    }
    public void ResetGroundPosition()
    {
        GroundMover.SetStartPosition();
    }
}
