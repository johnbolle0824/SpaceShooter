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

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.x <= -11.5f)
        {
            transform.position = new Vector3(_startPos, Random.Range(-5f, 5f), transform.position.z);
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
                // add 10 pts to player score value
                _player.ScoreModifier(10);
            }

            Destroy(gameObject);
            
        }

        if (other.gameObject.CompareTag("Player"))
        {
            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);            
        }
    }
}
