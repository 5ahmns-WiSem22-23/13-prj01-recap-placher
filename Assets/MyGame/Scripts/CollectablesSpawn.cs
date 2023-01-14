using UnityEngine;

public class CollectablesSpawn : MonoBehaviour
{

    public GameObject[] marshmallows;
    public CollectablesManager collectablesManager;

    void Start()
    {

        for (int i = 1; i < marshmallows.Length; i++)
        {
            marshmallows[i].SetActive(false);
        }

        for (int i = 0; i < marshmallows.Length; i++)
        {
            SpawnMarshmallows(marshmallows[i]);
        }
        
    }

    void Update()
    {
        if (collectablesManager.pinkMarshmallowCollected)
        {
            marshmallows[1].SetActive(true);

        }

        if (collectablesManager.blueMarshmallowCollected)
        {
            marshmallows[2].SetActive(true);
        }

        if (collectablesManager.greenMarshmallowCollected)
        {
            marshmallows[3].SetActive(true);
        }
    }

    void SpawnMarshmallows(GameObject marshmallow)
    {
       Vector2 spawnPoint = new Vector2(Random.Range(0, 20), Random.Range(0, 20));
        marshmallow.transform.position = spawnPoint;
    }
}
