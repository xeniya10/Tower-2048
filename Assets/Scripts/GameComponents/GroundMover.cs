using System.Collections;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
	private Vector3 _startGroundPosition = Vector3.zero;
	private void Start()
	{
		_startGroundPosition = this.transform.position;
	}
	public IEnumerator DownGround(float diffBlocksPosition)
	{
		float finalGroundPosition = this.transform.position.y - diffBlocksPosition;

		for (float step = 0; this.transform.position.y > finalGroundPosition; step += 0.01f)
		{
			this.transform.position += Vector3.down * step;
			yield return new WaitForSeconds(0.01f);
		}
	}

	public IEnumerator UpGround(float diffBlocksPosition)
	{
		float finalGroundPosition = this.transform.position.y + diffBlocksPosition;

		for (float step = 0; this.transform.position.y < finalGroundPosition; step += 0.01f)
		{
			this.transform.position += Vector3.up * step;
			yield return new WaitForSeconds(0.01f);
		}
	}

	public void SetStartPosition()
	{
		this.transform.position = _startGroundPosition;
	}
}
