using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChanges : MonoBehaviour
{
    [SerializeField]
    private GameObject longMarshmallow;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBooster(GameObject booster)
    {
        Vector2 spawnPoint = new Vector2(Random.Range(-30, 30), Random.Range(-30, 30));
        Instantiate(booster, spawnPoint, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "booster")
        {
            Debug.Log("booster activated");
            Destroy(other.gameObject);
            playerManager.normalSpeed = playerManager.normalSpeed + 5;
            player.transform.localScale = new Vector3((float)0.3, (float)0.3, (float)0.3);
            StartCoroutine(WaitTime());
        }
    }

    private IEnumerator WaitTime()
    {
        Debug.Log("start coroutine");
        yield return new WaitForSeconds(5);
        player.transform.localScale = new Vector3((float)0.2, (float)0.2, (float)0.2);
        playerManager.normalSpeed = playerManager.normalSpeed - 5;
    }

}
