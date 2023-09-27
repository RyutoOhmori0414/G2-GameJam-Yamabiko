using UnityEngine;

public class StageMater : MonoBehaviour
{
    [SerializeField] Transform _startPoint;
    public Transform StartPoint => _startPoint;
    [SerializeField] Transform _endPoint;
    float _poineDifference;
    public float PointDifferrence => _poineDifference;

    void Awake()
    {
        float _start = _startPoint.transform.position.x;
        float _end = _endPoint.transform.position.x;
        _poineDifference = _end - _start;
    }
}