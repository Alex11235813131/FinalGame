using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionRange;

    private float _distance;

    private void FixedUpdate()
    {
        _distance = Vector2.Distance(Target.transform.position, transform.position);
        NeedTransit = _distance > _transitionRange;
    }
}
