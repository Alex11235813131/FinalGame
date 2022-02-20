using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingTransition : Transition
{
    private void FixedUpdate()
    {
        NeedTransit = Enemy.CurrentHealth <= 0;
    }
}
