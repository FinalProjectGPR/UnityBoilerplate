using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangerScript : MonoBehaviour
{
    public GameObject[] cursors;
    public bool allPlayersSelected;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < cursors.Length; i++)
        {
            if (cursors[i].activeSelf == true)
            {
                break;
            }
            allPlayersSelected = true;
        }
        if (allPlayersSelected == true)
        {
            Debug.Log("All players have selected items!");
            allPlayersSelected = false;
        }
    }
}
