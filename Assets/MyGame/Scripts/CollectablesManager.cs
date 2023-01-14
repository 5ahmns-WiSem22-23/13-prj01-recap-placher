using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectablesManager : MonoBehaviour
{
    [SerializeField]
    private CollectablesSpawn collectablesSpawn;

    private bool marshmallowOnBack;

    private int marshmallowCount;
    [SerializeField]
    private Text counter;

    public bool pinkMarshmallowCollected = false;
    public bool blueMarshmallowCollected = false;
    public bool greenMarshmallowCollected = false;
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

    void Start()
    {
        marshmallowCount = 0;
        marshmallowOnBack = false;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        pinkMarshmallow.SetActive(false);
        blueMarshmallow.SetActive(false);
        greenMarshmallow.SetActive(false);
        whiteMarshmallow.SetActive(false);
    }

    void Update()
    {
        counter.text = marshmallowCount.ToString();
    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Marshmallow_pink" && !marshmallowOnBack)
        {
            Destroy(collectablesSpawn.marshmallows[0]);
            marshmallowOnBack = true;
            pinkMarshmallowCollected = true;
            spriteRenderer.sprite = catPinkMarshmallow;
        }

        if (other.name == "Marshmallow_blue" && !marshmallowOnBack)
        {
            Destroy(collectablesSpawn.marshmallows[1]);
            marshmallowOnBack = true;
            blueMarshmallowCollected = true;
            spriteRenderer.sprite = catBlueMarshmallow;
        }


        if (other.name == "Marshmallow_green" && !marshmallowOnBack)
        {
            Destroy(collectablesSpawn.marshmallows[2]);
            marshmallowOnBack = true;
            greenMarshmallowCollected = true;
            spriteRenderer.sprite = catGreenMarshmallow;
        }

        if (other.name == "Marshmallow_white" && !marshmallowOnBack)
        {
            Destroy(collectablesSpawn.marshmallows[3]);
            marshmallowOnBack = true;
            whiteMarshmallowCollected = true;
            spriteRenderer.sprite = catWhiteMarshmallow;
        }

        if (other.name == "Hotchocolate" && marshmallowOnBack)
        {
            marshmallowOnBack = false;
            spriteRenderer.sprite = catOriginal;
            marshmallowCount ++;

            if (pinkMarshmallowCollected)
            {
                pinkMarshmallow.SetActive(true);
                pinkMarshmallowCollected = false;
            }
            if (blueMarshmallowCollected)
            {
                blueMarshmallow.SetActive(true);
                blueMarshmallowCollected = false;
            }
            if (greenMarshmallowCollected)
            {
                greenMarshmallow.SetActive(true);
                greenMarshmallowCollected = false;
            }
            if (whiteMarshmallowCollected)
            {
                whiteMarshmallow.SetActive(true);
                whiteMarshmallowCollected = false;
            }

            if (other.name == "Hotchocolate" && marshmallowCount > 3)
            {
                SceneManager.LoadScene("YouWon");
            }
        }
        
    }
}
