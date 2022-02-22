using UnityEngine;

public class TargetCollisionTransition : Transition
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        NeedTransit = collision.collider.TryGetComponent<Player>(out Player player);
    }
}
