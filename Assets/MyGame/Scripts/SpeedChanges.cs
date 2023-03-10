using System.Collections;
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

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnBooster(longMarshmallow);
        }

        for (int i = 0; i < 3; i++)
        {
            SpawnPuddle(cocoaPuddle);
        }
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
        yield return new WaitForSeconds(5);
        player.transform.localScale = new Vector3((float)0.2, (float)0.2, (float)0.2);
        playerManager.normalSpeed = 5;
    }

    private IEnumerator WaitTimePuddle()
    {
        yield return new WaitForSeconds(2);
        playerManager.normalSpeed = 5;
    }

}
