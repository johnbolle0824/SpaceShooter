using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float _speed;
    [SerializeField]
    float _startPos;
    [SerializeField]
    float _health;

    private Player _player;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _player = GameObject.Find("Player").GetComponent<Player>();

        if (_player == null)
        {
            Debug.LogError("Player is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.x <= -11.5f)
        {
            transform.position = new Vector3(_startPos, UnityEngine.Random.Range(-5f, 5f), transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.transform.GetComponent<Player>();

        _health--;

        if (other.gameObject.CompareTag("Projectile"))
        {            
            Destroy(other.gameObject);

            if (_player != null)
            {
                _player.ScoreModifier(10);
            }

            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            Destroy(this.gameObject, 0.4f);            
        }

        if (other.gameObject.CompareTag("Player"))
        {
            if (player != null)
            {
                player.Damage();
            }

            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            Destroy(this.gameObject, 0.4f);            
        }        
    }
}
