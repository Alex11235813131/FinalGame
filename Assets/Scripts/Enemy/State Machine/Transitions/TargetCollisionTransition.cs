using UnityEngine;

public class TargetCollisionTransition : Transition
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.TryGetComponent<Player>(out Player player);

        NeedTransit = player;
    }
}
