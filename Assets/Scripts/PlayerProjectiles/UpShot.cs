using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpShot : MonoBehaviour
{
    [SerializeField] float speed;

    Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 upShotAngle = new Vector3(1, 0.3f, 0);

        transform.Translate(upShotAngle * speed * Time.deltaTime);

        DestroyProjectile();
    }

    void DestroyProjectile()
    {
        if (transform.position.x > 10.5f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(gameObject);
        }
    }
}
