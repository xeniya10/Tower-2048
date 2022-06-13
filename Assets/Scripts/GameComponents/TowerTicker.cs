using UnityEngine;

public class TowerTicker : MonoBehaviour
{
	private float _swingingAngle = 0f;
	private float _swingingSpeed = 0f;
	private float _stepSwingingAngle = 0.005f;
	private float _stepSwingingSpeed = 0.005f;

	private void Update()
	{
		float time = Time.time;
		SwayTower(time);
	}

	private void SwayTower(float time)
	{
		Quaternion towerStartAngle = Quaternion.AngleAxis(_swingingAngle, Vector3.forward);
		Quaternion towerEndAngle = Quaternion.AngleAxis(-_swingingAngle, Vector3.forward);
		transform.rotation = Quaternion.Lerp(towerStartAngle, towerEndAngle, (Mathf.Sin(time * _swingingSpeed)) / 2 + 0.5f);
	}

	public void IncreaseTowerSwinging()
	{
		_swingingAngle += _stepSwingingAngle;
		_swingingSpeed += _stepSwingingSpeed;
	}

	public void DecreaseTowerSwinging()
	{
		_swingingAngle -= _stepSwingingAngle;
		_swingingSpeed -= _stepSwingingSpeed;
	}

	public void ChangeParent(Block block)
	{
		block.transform.SetParent(transform);
	}

	public void DestroyChildren()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			Destroy(transform.GetChild(i).gameObject);
		}
	}
}
