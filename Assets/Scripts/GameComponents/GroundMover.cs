using System.Collections;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
	private Vector3 _startGroundPosition;

	private void Start()
	{
		_startGroundPosition = transform.position;
	}

	public IEnumerator DownGround(float diffBlocksPosition)
	{
		float finalGroundPosition = transform.position.y - diffBlocksPosition;

		for (float step = 0; transform.position.y > finalGroundPosition; step += 0.01f)
		{
			transform.position += Vector3.down * step;
			yield return new WaitForSeconds(0.01f);
		}
	}

	public IEnumerator UpGround(float diffBlocksPosition)
	{
		float finalGroundPosition = transform.position.y + diffBlocksPosition;

		for (float step = 0; transform.position.y < finalGroundPosition; step += 0.01f)
		{
			transform.position += Vector3.up * step;
			yield return new WaitForSeconds(0.01f);
		}
	}

	public void ResetPosition()
	{
		transform.position = _startGroundPosition;
	}
}
