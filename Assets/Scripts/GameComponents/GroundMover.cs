using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    public IEnumerator MoveGroundDown()
    {
        for (float step = 0; step < 0.45f; step += 0.01f)
        {
            this.transform.position += Vector3.down * step;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public IEnumerator MoveGroundUp()
    {
        for (float step = 0; step < 0.2f; step += 0.01f)
        {
            this.transform.position += Vector3.up * step;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
