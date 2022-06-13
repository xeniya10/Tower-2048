using UnityEngine;

public class BlockTicker : MonoBehaviour
{
    private float _tickerAngle = 45f;

    public void Update()
    {
        float time = Time.time;
        SwayBlock(time);
    }

    private void SwayBlock(float time)
    {
        Quaternion tickerStartAngle = Quaternion.AngleAxis(_tickerAngle, Vector3.forward);
        Quaternion tickerEndAngle = Quaternion.AngleAxis(-_tickerAngle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(tickerStartAngle, tickerEndAngle, (Mathf.Sin(time * 1.5f)) / 2 + 0.5f);
    }

    public void ResetTicker() => transform.rotation = Quaternion.Euler(0, 0, 0);

    public void DestroyChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
