using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird1 : Enemy
{
    private void Start()
    {
        transform.localScale = new Vector2(.5f, .5f);
        Speed = 2f;
        _animator.runtimeAnimatorController = Resources.Load
            ("Animations/Ave1Vermelha") as RuntimeAnimatorController;
 
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        Destroy(gameObject);
    }


}
