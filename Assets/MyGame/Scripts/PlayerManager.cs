using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float normalSpeed;
    private float rotateSpeed;
    private Rigidbody2D playerRB;
    private Vector2 playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();


        normalSpeed = 5;
        rotateSpeed = 30;

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        playerMovement = new Vector2(horizontalMovement, verticalMovement).normalized;
    }

    private void FixedUpdate()
    {
        playerRB.velocity = new Vector2(playerMovement.x, playerMovement.y) * normalSpeed;
        
    }


   
}