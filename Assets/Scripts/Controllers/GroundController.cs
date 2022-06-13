using UnityEngine;

public class GroundController : MonoBehaviour
{
	[SerializeField] private GroundMover _groundMover;

	private float _maxBlockPosition = -20f;
	private float _minBlockPosition = -40f;
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
		StartCoroutine(_groundMover.DownGround(difference));
	}

	private void MoveGroundUp(float topTowerBlockPosition)
	{
		var difference = Mathf.Abs(topTowerBlockPosition - _minBlockPosition) + _positionGap;
		StartCoroutine(_groundMover.UpGround(difference));
	}

	public void ResetGroundPosition()
	{
		_groundMover.ResetPosition();
	}
}
