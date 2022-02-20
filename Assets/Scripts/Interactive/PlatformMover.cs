using UnityEngine;
using DG.Tweening;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private int _duration;

    private void Start()
    {
        transform.DOMoveY(_targetPoint.position.y, _duration).SetLoops(-1, LoopType.Yoyo);
    }
}
