
public class HealthDownTransition : Transition
{
    private bool _isShieldWasActivated = false;

    private void FixedUpdate()
    {
        if (_isShieldWasActivated == true)
            return;

        if(Enemy.CurrentHealth <= Enemy.MaxHealth / 2)
        {
            NeedTransit = true;
            _isShieldWasActivated = true;
        }
    }
}
