using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, ITriggerable
{
    public Sprite OpenSprite;
    public Sprite ClosedSprite;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;
    private AudioSource _audioSource;

    private void Start()
    {
        _collider = gameObject.GetComponent<Collider2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _audioSource = gameObject.GetComponent<AudioSource>();
    }


    public void Open()
    {
        _spriteRenderer.sprite = OpenSprite;
        _collider.enabled = false;
        _audioSource.Play();
    }

    public void Close()
    {
        _spriteRenderer.sprite = ClosedSprite;
        _collider.enabled = true;
        _audioSource.Play();
    }

    public void Trigger()
    {
        if (_collider.enabled) { Open(); }
        else { Close(); }
    }
}
