using UnityEngine;

[RequireComponent(typeof (Enemy))]
public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Player Target { get; private set; }
    protected Enemy Enemy;

    public State TargetState => _targetState;

    public bool NeedTransit { get; protected set; }

    public void Init(Player target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }

    private void Start()
    {
        Enemy = GetComponent<Enemy>();
    }
}
