using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float jetspeed;
    public GameObject ParticleLeft;
    public GameObject ParticleRight;
    public Animator anim;
    float angle = 0f;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        //Movement 1st attempt:
        /*
        Vector2 horvelosity = new Vector2(Input.GetAxis("Horizontal"), 0f) * horspeed;
        Vector2 vervelosity = new Vector2(0f, Input.GetAxis("Vertical")) * jetspeed;




        if((horvelosity.x > 0 && rb.velocity.x < maxhorspeed) || (horvelosity.x < 0 && rb.velocity.x > -maxhorspeed))
        {
            rb.velocity += horvelosity;
        }


        if (rb.velocity.y < maxverspeed)
        {
            rb.velocity += vervelosity;
        }
        */

        //Movement 2nd attempt
        angle += Input.GetAxis("Horizontal");
        transform.rotation = Quaternion.Euler(0f,0f, -angle);

        float vervelosity = Mathf.Clamp(Input.GetAxis("Vertical"),0f,1f);

        if (vervelosity != 0f)
        {
            ParticleLeft.SetActive(true);
            ParticleRight.SetActive(true);
            anim.SetBool("fly", true);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            ParticleLeft.SetActive(true);
            ParticleRight.SetActive(false);
            anim.SetInteger("dir", -1);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            ParticleRight.SetActive(true);
            ParticleLeft.SetActive(false);
            anim.SetInteger("dir", 1);
        }
        else {
            ParticleLeft.SetActive(false);
            ParticleRight.SetActive(false);
            anim.SetInteger("dir", 0);
            anim.SetBool("fly", false);
        }

        Vector3 velositytoadd = (transform.up * vervelosity).normalized * jetspeed;
        Vector2 veltoadd = new Vector2(velositytoadd.x, velositytoadd.y);
        rb.velocity += veltoadd;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
