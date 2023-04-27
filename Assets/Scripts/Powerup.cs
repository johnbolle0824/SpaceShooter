using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    float _speed;

    // ID for powerups
    // 0 = tripleshot
    // 1 = speed 
    // 2 = shield

    [SerializeField]
    private int _powerID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if(transform.position.x < -11f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                switch (_powerID)
                {
                    case 0:
                        player.TripleShot();
                        break;
                    case 1:
                        player.SpeedBoost();
                        break;
                    case 2:
                        player.ShieldPower();
                        break;
                    default:
                        break;
                }
            }

            Destroy(this.gameObject);
        }
    }
}
