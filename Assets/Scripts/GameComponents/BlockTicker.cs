using UnityEngine;

public class BlockTicker : MonoBehaviour
{
    private float _tickerAngle = 45f;
    public void Update()
    {
        float time = Time.time;
        this.transform.rotation = SwayBlock(time);
    }
    private Quaternion SwayBlock(float time)
    {
        Quaternion tickerStartAngle = Quaternion.AngleAxis(_tickerAngle, Vector3.forward);
        Quaternion tickerEndAngle = Quaternion.AngleAxis(-_tickerAngle, Vector3.forward);
        var rotation = Quaternion.Lerp(tickerStartAngle, tickerEndAngle, (Mathf.Sin(time * 1.5f)) / 2 + 0.5f);
        return rotation;
    }
}
