using System.Collections;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private float _delay;

    private Animator _animaor;
    private const string _destroy = "Destroy";

    private void Start()
    {
        _animaor = GetComponentInChildren<Animator>();
    }

    public void Deactivate()
    {
        StartCoroutine(Removing());
    }

    private IEnumerator Removing()
    {
        _animaor.SetTrigger(_destroy);
        yield return new WaitForSeconds(_delay);
        gameObject.SetActive(false);
    }
}
