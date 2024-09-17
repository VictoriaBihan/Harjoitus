using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float jumpForce = 2f;
    SpriteRenderer rend;
    Animator anim;
    public float timer;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
      Debug.Log("Start");
      rend=GetComponent<SpriteRenderer>();
      anim=GetComponent<Animator>();
      rb = GetComponent<Rigidbody2D>();
    }

        // Update is called once per frame
    void Update()
    {
      anim.SetBool("moving", false);
      if(Input.GetKey(KeyCode.A))
      {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime, Space.World);
        rend.flipX = true;
        anim.SetBool("moving", true);
      } 
      if(Input.GetKey(KeyCode.D))
      {
        transform.Translate(Vector2.right * movementSpeed * Time.deltaTime, Space.World);
        rend.flipX = false;
        anim.SetBool("moving", true); 
      }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            timer = 0;

        }
        else
        {
            timer += Time.deltaTime;
        }
        anim.SetFloat("Dance_timer", timer);

        bool grounded = false;
        LayerMask LayerMask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, LayerMask);
        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.yellow);

        if(hit)
        {
            grounded = true;
            Debug.Log("Ground found");
        }

        if(Input.GetKeyDown(KeyCode.W) && grounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }
}