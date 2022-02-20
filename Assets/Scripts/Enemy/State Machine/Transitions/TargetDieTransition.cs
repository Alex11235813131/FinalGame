
public class TargetDieTransition : Transition
{
    private void FixedUpdate()
    {
        NeedTransit = Target.gameObject.activeSelf == false;
    }
}
