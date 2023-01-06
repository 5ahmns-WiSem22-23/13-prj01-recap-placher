using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesSpawn : MonoBehaviour
{

    public GameObject[] marshmallows;

    public CollectablesManager collectablesManager;


    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if (collectablesManager.pinkMarshmallowCollected)
        {
            Debug.Log("blueMarshmallow visible");
            marshmallows[1].SetActive(true);

        }

        if (collectablesManager.blueMarshmallowCollected)
        {
            Debug.Log("greenMarshmallow visible");
            marshmallows[2].SetActive(true);
        }

        if (collectablesManager.greenMarshmallowCollected)
        {
            marshmallows[3].SetActive(true);
        }
    }

    void SpawnMarshmallows(GameObject marshmallow)
    {
       Vector2 spawnPoint = new Vector2(Random.Range(-30, 30), Random.Range(-30, 30));
        marshmallow.transform.position = spawnPoint;
    }
}
