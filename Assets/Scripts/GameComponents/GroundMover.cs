using System.Collections;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    public Vector3 StartGroundPosition = Vector3.zero;
    private void Start()
    {
        StartGroundPosition = this.transform.position;
    }
    public IEnumerator DownGround(float difference)
    {
        float finalGroundPosition = this.transform.position.y - difference;

        for (float step = 0; this.transform.position.y > finalGroundPosition; step += 0.01f)
        {
            this.transform.position += Vector3.down * step;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public IEnumerator UpGround(float difference)
    {
        float finalGroundPosition = this.transform.position.y + difference;

        for (float step = 0; this.transform.position.y < finalGroundPosition; step += 0.01f)
        {
            this.transform.position += Vector3.up * step;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void SetStartPosition()
    {
        this.transform.position = StartGroundPosition;
    }
}
