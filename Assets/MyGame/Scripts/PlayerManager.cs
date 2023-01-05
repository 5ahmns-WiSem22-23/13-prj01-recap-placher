using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float normalSpeed;
    private Rigidbody2D playerRB;
    private Vector2 playerMovement;

    private bool marshmallowOnBack;

    private bool pinkMarshmallowCollected = false;
    private bool blueMarshmallowCollected = false;
    private bool greenMarshmallowCollected = false;
    private bool whiteMarshmallowCollected = false;

    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite catOriginal;
    [SerializeField]
    private Sprite catPinkMarshmallow;
    [SerializeField]
    private Sprite catBlueMarshmallow;
    [SerializeField]
    private Sprite catGreenMarshmallow;
    [SerializeField]
    private Sprite catWhiteMarshmallow;

    [SerializeField]
    private GameObject pinkMarshmallow;
    [SerializeField]
    private GameObject blueMarshmallow;
    [SerializeField]
    private GameObject greenMarshmallow;
    [SerializeField]
    private GameObject whiteMarshmallow;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();

        marshmallowOnBack = false;
        normalSpeed = 5;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        pinkMarshmallow.SetActive(false);
        blueMarshmallow.SetActive(false);
        greenMarshmallow.SetActive(false);
        whiteMarshmallow.SetActive(false);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "marshmallow_pink" && !marshmallowOnBack)
        {
            Destroy(other.gameObject);
            marshmallowOnBack = true;
            pinkMarshmallowCollected = true;
            spriteRenderer.sprite = catPinkMarshmallow;
            Debug.Log("Pink Marshmallow is here");
        }

        if (other.name == "marshmallow_blue" && !marshmallowOnBack)
        {
            Destroy(other.gameObject);
            marshmallowOnBack = true;
            blueMarshmallowCollected = true;
            spriteRenderer.sprite = catBlueMarshmallow;
            Debug.Log("Blue Marshmallow is here");
        }


        if (other.name == "marshmallow_green" && !marshmallowOnBack)
        {
            Destroy(other.gameObject);
            marshmallowOnBack = true;
            greenMarshmallowCollected = true;
            spriteRenderer.sprite = catGreenMarshmallow;
            Debug.Log("Green Marshmallow is here");
        }

        if (other.name == "marshmallow_white" && !marshmallowOnBack)
        {
            Destroy(other.gameObject);
            marshmallowOnBack = true;
            whiteMarshmallowCollected = true;
            spriteRenderer.sprite = catWhiteMarshmallow;
            Debug.Log("White Marshmallow is here");
        }

        if (other.name == "hotchocolate" && marshmallowOnBack)
        {
            marshmallowOnBack = false;
            spriteRenderer.sprite = catOriginal;

            if (pinkMarshmallowCollected)
            {
                pinkMarshmallow.SetActive(true);
            }
            if (blueMarshmallowCollected)
            {
                blueMarshmallow.SetActive(true);
            }
            if (greenMarshmallowCollected)
            {
                greenMarshmallow.SetActive(true);
            }
            if (whiteMarshmallowCollected)
            {
                whiteMarshmallow.SetActive(true);
            }

        }

    }
}