using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangerScript : MonoBehaviour
{
    public GameObject[] cursors;
    public bool allPlayersSelected;
    public GameObject spawner;
    public bool isSelecting = true;
    public bool isPlacing = false;
    public bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSelecting)
        {

            for (int i = 0; i < cursors.Length; i++)
            {
                if (cursors[i].activeSelf == true)
                {
                    break;
                }
                allPlayersSelected = true;
            }
            if (allPlayersSelected == true)
            {
                spawner.GetComponent<StuffSpawnerScript>().destroyRemaining();
                spawner.SetActive(false);
                allPlayersSelected = false;
            }
        }
    }
}
