using UnityEngine;

public class TowerTicker : MonoBehaviour
{
    private float _towerAngle = 0f;
    private float _towerSpeed = 0f;
    private float _stepTowerAngle = 0.005f;
    private float _stepTowerSpeed = 0.005f;

    public void Update()
    {
        float time = Time.time;
        this.transform.rotation = SwayTower(time);
    }
    private Quaternion SwayTower(float time)
    {
        Quaternion towerStartAngle = Quaternion.AngleAxis(_towerAngle, Vector3.forward);
        Quaternion towerEndAngle = Quaternion.AngleAxis(-_towerAngle, Vector3.forward);
        var rotation = Quaternion.Lerp(towerStartAngle, towerEndAngle, (Mathf.Sin(time * _towerSpeed)) / 2 + 0.5f);
        return rotation;
    }
    public void UpTickerTower()
    {
        _towerAngle += _stepTowerAngle;
        _towerSpeed += _stepTowerSpeed;
    }
    public void DownTickerTower()
    {
        _towerAngle -= _stepTowerAngle;
        _towerSpeed -= _stepTowerSpeed;
    }
}
