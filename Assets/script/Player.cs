using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer rend;
    public float movementSpeed = 1f;



    // Start is called before the first frame update
    void Start()
    {
      Debug.Log("Start");
      rend=GetComponent<SpriteRenderer>() ;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.A))
       {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime, Space.World);
        rend.flipX = true;

       } 
       if(Input.GetKey(KeyCode.D))
       {
        transform.Translate(Vector2.right * movementSpeed * Time.deltaTime, Space.World);
        rend.flipX = false;

       } 
    }
}
