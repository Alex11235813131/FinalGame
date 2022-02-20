using UnityEngine;

public class ActivationTransition : Transition
{
    [SerializeField] BossActivator _activator;
    [SerializeField] GameObject[] _webs;

    private void OnEnable()
    {
        _activator.Reached += OnBossActivate;
    }

    private void OnDisable()
    {
        _activator.Reached -= OnBossActivate;
    }

    private void OnBossActivate()
    {
        NeedTransit = true;

        foreach (var web in _webs)
        {
            web.SetActive(false);
        }
    }
}
