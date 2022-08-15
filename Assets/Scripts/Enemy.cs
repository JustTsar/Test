using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthBar;
    [SerializeField] private float _health;

    private bool _isDead;

    public bool IsDead
    {
        get
        {
            return _isDead = true;
        }
        set
        {
            _isDead = false;
        }
    }
    private void Start()
    {
        _healthBar.text = _health.ToString();
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Bullet bullet))
        {
            _health -= 1;
            _healthBar.text = _health.ToString();
            Destroy(bullet);
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
