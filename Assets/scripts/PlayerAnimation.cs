using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerController _pc;
    private Rigidbody2D _rb;
    private Animator _animator;
    enum RunAnimation {Idle = 0, Down = 1, Side = 2, Up = 3 }

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
        _pc = gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        Walk();
    }

    void Walk()
    {
        RunAnimation runAnim = RunAnimation.Down;
        bool idle = false;
        var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = false;
        if (_rb.velocity.sqrMagnitude < 0.01) { idle = true; }

        var gunVector = _pc.Gun.transform.position - gameObject.transform.position;

        if (gunVector.y > 0 && Mathf.Abs(gunVector.y) > Mathf.Abs(gunVector.x)) { runAnim = RunAnimation.Up; }
        else if (gunVector.x > 0 && Mathf.Abs(gunVector.y) < Mathf.Abs(gunVector.x)) { runAnim = RunAnimation.Side;}
        else if (gunVector.x < 0 && Mathf.Abs(gunVector.y) < Mathf.Abs(gunVector.x)) { runAnim = RunAnimation.Side; spriteRenderer.flipX = true; }

        _animator.SetInteger("anim", (int)runAnim);
        _animator.SetBool("idle", idle);
        SetGunSortingOrder(runAnim);
    }

    void SetGunSortingOrder(RunAnimation runAnim)//9 = behind player, 11 = in front of player
    {
        var gunSpriteRenderer = _pc.Gun.GetComponent<SpriteRenderer>();
        switch (runAnim)
        {
            case RunAnimation.Up:
                gunSpriteRenderer.sortingOrder = 9;
                break;
            case RunAnimation.Down:
                gunSpriteRenderer.sortingOrder = 11;
                break;
            case RunAnimation.Side:
                if (gameObject.GetComponent<SpriteRenderer>().flipX) { gunSpriteRenderer.sortingOrder = 9; }
                else { gunSpriteRenderer.sortingOrder = 11; }
                break;
        }
    }
}
