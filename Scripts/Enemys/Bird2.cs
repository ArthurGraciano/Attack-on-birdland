using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird2 : MonoBehaviour
{
    void Start()
    {
        transform.localScale = new Vector2(.5f, .5f);
        Speed = 3f;
        //_sprite.sprite = Resources.Load<Sprite>("enemy");
        _animator.runtimeAnimatorController = Resources.Load
            ("Animations/Ave1Azul") as RuntimeAnimatorController;
        LifePoints = 5f;

    }

public override OnMouseDown()
    {
        base.OnMouseDown();
        LifePoints--;
    }
}
