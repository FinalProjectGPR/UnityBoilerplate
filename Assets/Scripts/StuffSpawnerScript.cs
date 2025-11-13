using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawnerScript : MonoBehaviour
{
    public GameObject[] stuff;
    public float[,] coords = new float[5, 2] { { -2.5f, 2.5f }, { 1.75f, 1f }, { -.5f, -1f }, { 2.4f, -3.5f }, { -2.3f, -2.5f } };
    public GameObject[] stuffSpawned;

    // Start is called before the first frame update
    void Start()
    {
        PauseManager.isPaused = true;
        spawnStuff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnStuff()
    {
        stuffSpawned = new GameObject[] { null, null, null, null, null };
        for (int i = 0; i < coords.Length/2; i++)
        {
            stuffSpawned[i] = Instantiate(stuff[Random.Range(0, stuff.Length)], transform.position + new Vector3(coords[i, 0], coords[i, 1], 0), transform.rotation);
        }
    }

    public void destroyRemaining()
    {
        for(int i = 0; i < stuffSpawned.Length; i++)
        {
            if(stuffSpawned[i] != null)
            {
                Destroy(stuffSpawned[i]);
            }
        }
    }
}
