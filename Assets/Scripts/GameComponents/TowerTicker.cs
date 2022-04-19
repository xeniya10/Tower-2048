using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTicker : MonoBehaviour
{
    [HideInInspector]
    public float TowerAngle = 0f;
    [HideInInspector]
    public float TowerSpeed = 0f;

    public void Update()
    {
        float time = Time.time;
        this.transform.rotation = SwayTower(time);
    }
    private Quaternion SwayTower(float time)
    {
        Quaternion towerStartAngle = Quaternion.AngleAxis(TowerAngle, Vector3.forward);
        Quaternion towerEndAngle = Quaternion.AngleAxis(-TowerAngle, Vector3.forward);
        var rotation = Quaternion.Lerp(towerStartAngle, towerEndAngle, (Mathf.Sin(time * TowerSpeed)) / 2 + 0.5f);
        return rotation;
    }
}
