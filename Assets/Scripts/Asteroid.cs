using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed, _rotationSpeed, _startPos, _hitPoints;

    [SerializeField]
    private GameObject explosionFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(_movementSpeed * Time.deltaTime, 0, 0), Space.World);
        if (transform.position.x <= -11.5f)
        {
            transform.position = new Vector3(_startPos, Random.Range(-5, 5), transform.position.z);
        }

        transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.transform.GetComponent<Player>();

        _hitPoints--;

        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            if (player != null)
            {
                player.Damage();
            }
        }

        if (_hitPoints < 1) 
        {
            Destroy(this.gameObject);
            Instantiate(explosionFX, transform.position, Quaternion.identity);
        }
    }
}
