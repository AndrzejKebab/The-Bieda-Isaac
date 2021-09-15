using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    public GameObject Projectile;
    public float projectileSpeed = 200;
    public float nextFire = 0.0f;
    public float fireRate = 0.5f;
    public float lifeTime = 2.0f;

    Vector3 lastDirection;
    // Start is called before the first frame update
    void Start()
    {
        lastDirection = Vector3.down;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float yMovement = Input.GetAxisRaw("Vertical");

        Vector3 Movement = new Vector3(xMovement, yMovement, 0);

        Movement.Normalize();

        if(Movement.magnitude > 0)
        {
            transform.Translate(Movement * Time.deltaTime * speed);
            lastDirection = Movement;
        }
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            Shoot();   
            nextFire = Time.time + fireRate;
        }

    }
    void Shoot()
    {
        GameObject p = Instantiate(Projectile, transform.position, Quaternion.identity);
        p.GetComponent<Rigidbody2D>().AddForce(lastDirection * projectileSpeed);
        Destroy(p, lifeTime);
    }
}
