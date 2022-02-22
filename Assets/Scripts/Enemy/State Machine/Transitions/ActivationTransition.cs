using UnityEngine;

public class ActivationTransition : Transition
{
    [SerializeField] BossActivator _activator;
    [SerializeField] GameObject[] _webs;

    private void OnEnable()
    {
        _activator.Reached += DeactivateWebs;
    }

    private void OnDisable()
    {
        _activator.Reached -= DeactivateWebs;
    }

    private void DeactivateWebs()
    {
        NeedTransit = true;

        foreach (var web in _webs)
        {
            web.SetActive(false);
        }
    }
}
