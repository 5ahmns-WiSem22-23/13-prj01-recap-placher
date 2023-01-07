using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChanges : MonoBehaviour
{
    [SerializeField]
    private GameObject longMarshmallow;

    [SerializeField]
    private GameObject cocoaPuddle;

    [SerializeField]
    private PlayerManager playerManager;

    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnBooster(longMarshmallow);
        }

        for (int i = 0; i < 3; i++)
        {
            SpawnBooster(cocoaPuddle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBooster(GameObject booster)
    {
        Vector2 spawnPoint = new Vector2(Random.Range(0, 20), Random.Range(0, 20));
        Instantiate(booster, spawnPoint, Quaternion.identity);
    }

    void SpawnPuddle(GameObject puddle)
    {
        Vector2 spawnPoint = new Vector2(Random.Range(0, 20), Random.Range(0, 20));
        Instantiate(puddle, spawnPoint, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "booster")
        {
            Debug.Log("booster activated");
            Destroy(other.gameObject);
            playerManager.normalSpeed = playerManager.normalSpeed + 5;
            player.transform.localScale = new Vector3((float)0.3, (float)0.3, (float)0.3);
            StartCoroutine(WaitTimeBooster());
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "puddle")
        {
            playerManager.normalSpeed = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "puddle")
        {
            StartCoroutine(WaitTimePuddle());
        }
    }

    private IEnumerator WaitTimeBooster()
    {
        Debug.Log("start coroutine");
        yield return new WaitForSeconds(5);
        player.transform.localScale = new Vector3((float)0.2, (float)0.2, (float)0.2);
        playerManager.normalSpeed = playerManager.normalSpeed - 5;
    }

    private IEnumerator WaitTimePuddle()
    {
        yield return new WaitForSeconds(2);
        playerManager.normalSpeed = 5;
    }

}
