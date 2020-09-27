using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float padding = 0.5f;
    [SerializeField] private GameObject[] logs;
    [SerializeField] private GameObject sparkleVFX;
    [SerializeField] private Transform chainsawTransform;

    public GameObject player;

    private float xMin;
    private float xMax;
    private float screenWidth;
    private float xPos;
    BoxCollider2D bc;
    public CameraShake cameraShake;

    void Start()
    {
        screenWidth = Screen.width;
        bc = GetComponent<BoxCollider2D>();
        SetUpMoveBoundries();
    }

    private void SetUpMoveBoundries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }


    // Update is called once per frame
    void Update()
    {
        TouchMove();
    }

    


    void TouchMove()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            double halfScreen = screenWidth / 2.0f;
            xPos = chainsawTransform.position.x;

            //Check if it is left or right?
            if (touchPosition.x < halfScreen)
            { 
                xPos -= moveSpeed * Time.deltaTime;
            }
            else if (touchPosition.x > halfScreen)
            {
                xPos += moveSpeed * Time.deltaTime;
            }
            xPos = Mathf.Clamp(xPos,xMin,xMax);
            chainsawTransform.position = new Vector3(xPos,chainsawTransform.position.y,chainsawTransform.position.z);
        }
    }

    


    /*
     // for pc users 


     private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        transform.position = new Vector2(newXPos, transform.position.y);
    }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Log")
        {
            GameObject sparkles = Instantiate(sparkleVFX, transform.position, transform.rotation);
            Destroy(sparkles, 2f);
        }
       
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Log")
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Find("Camera").SendMessage("DoShake");
            Debug.Log("The camera trigger has hit");
        }
    }



  

}
