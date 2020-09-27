using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogController : MonoBehaviour
{
    [SerializeField] private GameObject chainsaw;

    private Rigidbody2D rb;
    private Animator logAnim;

    private bool isTrigger = false;


    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        logAnim = GetComponent<Animator>();
       
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "chainsaw")
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "chainsaw" & !isTrigger)
        {
            isTrigger = true;
            logAnim.SetBool("isTrigger", isTrigger);
            Destroy(gameObject,2f);
        }
    }
    

   

   

}
