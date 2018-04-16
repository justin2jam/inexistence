using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprt;
    public float speed;
    public GameObject Attack;
    public AudioSource slashsound;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprt = GetComponent<SpriteRenderer>();
        Attack.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * speed);
        if (moveHorizontal > 0.05f)
        {
            anim.SetBool("walk", true);
            sprt.flipX = false;
        }
        else if(moveHorizontal < -0.05f)
        {
            anim.SetBool("walk", true);
            sprt.flipX = true;
        }     
        
        else
        {
            anim.SetBool("walk", false);
        }

        // Attack
        if (Input.GetKeyDown("z"))
        {
            anim.Play("Hero_Attack", -1, 0f);
            slashsound.Play();
            Attack.SetActive(true);
        } 
        else if (Input.GetKeyUp("z"))
        {
            Attack.SetActive(false);
        }
    }
}
