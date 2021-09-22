using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;


    public Rigidbody2D rb;
    public Animator animator;
    public GameObject Projectile;
    public float projectileSpeed = 650;
    public float nextFire = 0.0f;
    public float fireRate = 0.5f;
    public float lifeTime = 2.5f;

    Vector2 movement;
    Vector3 lastDirection;


    private void Start()
    {
        movement = Vector2.down;
    }
    // Start is called before the first frame update
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 Movement = new Vector2(movement.x, movement.y);

        Movement.Normalize();

        //if (Movement.magnitude > 0)
        //{
        //    transform.Translate(Movement * Time.deltaTime * moveSpeed);
        //    movement = Movement;
        //}

        //if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        //{
        //    Shoot();
        //    nextFire = Time.time + fireRate;
        //}
    }

    //void Shoot()
    //{
    //    GameObject p = Instantiate(Projectile, transform.position, Quaternion.identity);
    //    p.GetComponent<Rigidbody2D>().AddForce(movement * projectileSpeed);
    //    Destroy(p, lifeTime);
    //}
}
