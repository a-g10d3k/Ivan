using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public GameObject Gun;
    private Rigidbody2D _rb;
    public Vector2? OverrideControls;

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Walk();
        Aim();
    }

    void Walk()
    {
        var direction = OverrideControls == null ? new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) : (Vector2)OverrideControls;
        _rb.velocity = direction.normalized * Speed;
    }

    void Aim()
    {
        var mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = (mousePos - (Vector2)gameObject.transform.position).normalized;
        if (OverrideControls != null) { Gun.SetActive(false); }
        else { Gun.SetActive(true); }
        Gun.transform.rotation = Quaternion.LookRotation(-Vector3.forward, direction);
        Gun.transform.position = (Vector2)gameObject.transform.position + 0.5f * direction + (Vector2)(-0.1f*Gun.transform.right);
    }

    void PlayStepSound()
    {
        gameObject.GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
        gameObject.GetComponent<AudioSource>().Play();
    }


}
