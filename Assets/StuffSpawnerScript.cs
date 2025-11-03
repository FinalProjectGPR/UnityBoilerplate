using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawnerScript : MonoBehaviour
{
    public GameObject[] stuff;
    public float[,] coords = new float[5, 2] { { -2.5f, 2.5f }, { 1.75f, 1f }, { -.5f, -1f }, { 2.4f, -3.5f }, { -2.3f, -2.5f } };

    // Start is called before the first frame update
    void Start()
    {
        //coords = ;
        spawnStuff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnStuff()
    {
        for (int i = 0; i < coords.Length/2; i++)
        {
            Instantiate(stuff[Random.Range(0, stuff.Length)], transform.position + new Vector3(coords[i, 0], coords[i, 1], 0), transform.rotation);
        }
    }
}
