using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private Player _target;
    private State _currentState;

    public State CurrentState => _currentState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Reset(_firstState);
    }

    private void Update()
    {
        TransitConditionChecker();
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }

    private void TransitConditionChecker()
    {
        if (_currentState == null)
            Reset(_firstState);

        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }
}
