using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float normalSpeed;
    private Rigidbody2D playerRB;

    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        normalSpeed = 5;
    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxis("Vertical") * normalSpeed;
        float rotation = Input.GetAxis("Horizontal") * normalSpeed / 2;

        playerRB.velocity = transform.up * movement;
        playerRB.SetRotation(playerRB.rotation - rotation);
    }  
}