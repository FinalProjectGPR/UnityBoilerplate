using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawnerScript : MonoBehaviour
{
    public GameObject[] stuff;

    // Start is called before the first frame update
    void Start()
    {
        spawnStuff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnStuff()
    {
        Instantiate(stuff[Random.Range(0, 1)], transform.position + new Vector3(10, 10, 0), transform.rotation);

    }
}
