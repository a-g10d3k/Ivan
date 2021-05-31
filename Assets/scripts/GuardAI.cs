using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAI : MonoBehaviour
{
    public float Speed;
    public GameObject Gun;
    public Vector2 Direction;
    public LayerMask LayerMask;
    private Rigidbody2D _rb;
    private GameObject _player;
    private bool _lineOfSight;
    private Vector2 _aimDirection;
    private Gun _gun;

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        RaycastPlayer();
        Walk();
        Aim();
    }

    void RaycastPlayer()
    {
        var direction = (_player.transform.position - transform.position).normalized;
        var ray = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, LayerMask);
        if (ray.transform.CompareTag("Player"))
        {
            _lineOfSight = true;
            _aimDirection = direction;
        }
        else
        {
            _lineOfSight = false;
        }
    }

    void Walk()
    {
        if (Physics2D.Raycast((Vector2)transform.position + Direction*0.5f, Direction, 0.1f, LayerMask))
        {
            Direction = -Direction;
        }
        _rb.velocity = Direction.normalized * Speed;
    }

    void Aim()
    {
        
        if (_lineOfSight)
        {
            Gun.transform.rotation = Quaternion.LookRotation(-Vector3.forward, _aimDirection);
            Gun.transform.position = (Vector2)gameObject.transform.position + 0.5f * _aimDirection + (Vector2)(-0.1f * Gun.transform.right);
            Gun.GetComponent<GuardGunController>().Shoot = true;
            Gun.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            Gun.GetComponent<GuardGunController>().Shoot = false;
            Gun.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
