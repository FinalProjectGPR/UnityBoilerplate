using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject thingToSpawn;
    public GameObject thingCurrentlySpawned;
    public float spawnInterval;
    public float timeRemaining;
    public bool isPickedUp = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(thingCurrentlySpawned == null)
        {
            timeRemaining -= Time.deltaTime;
            if(timeRemaining <= 0)
            {
                spawnItem();
                timeRemaining = spawnInterval;
            }
        }
    }

    public void spawnItem()
    {
        thingCurrentlySpawned = Instantiate(thingToSpawn, gameObject.transform.position + new Vector3(0f, .5f, 0f), gameObject.transform.rotation);
    }
}
