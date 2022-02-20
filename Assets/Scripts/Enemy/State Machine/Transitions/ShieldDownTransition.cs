using UnityEngine;

public class ShieldDownTransition : Transition
{
    [SerializeField] private GameObject _shield;

    private void FixedUpdate()
    {
        NeedTransit = _shield.activeSelf == false;
    }
}
