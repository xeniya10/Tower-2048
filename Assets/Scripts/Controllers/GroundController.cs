using UnityEngine;

public class GroundController : MonoBehaviour
{
	public GroundMover GroundMover;

	private float _maxBlockPosition = -13f;
	private float _minBlockPosition = -36f;
	private float _positionGap = 3f;

	public bool isTooHigh(float topTowerBlockPosition)
	{
		if (topTowerBlockPosition > _maxBlockPosition)
		{
			MoveGroundDown(topTowerBlockPosition);
			return true;
		}
		return false;
	}
	public bool isTooLow(float topTowerBlockPosition)
	{
		if (topTowerBlockPosition < _minBlockPosition)
		{
			MoveGroundUp(topTowerBlockPosition);
			return true;
		}
		return false;
	}
	private void MoveGroundDown(float topTowerBlockPosition)
	{
		var difference = Mathf.Abs(topTowerBlockPosition - _maxBlockPosition) + _positionGap;
		StartCoroutine(GroundMover.DownGround(difference));
	}
	private void MoveGroundUp(float topTowerBlockPosition)
	{
		var difference = Mathf.Abs(topTowerBlockPosition - _minBlockPosition) + _positionGap;
		StartCoroutine(GroundMover.UpGround(difference));
	}
	public void ResetGroundPosition()
	{
		GroundMover.ResetPosition();
	}
}
