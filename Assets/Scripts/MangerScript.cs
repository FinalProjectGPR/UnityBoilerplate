using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangerScript : MonoBehaviour
{
    public GameObject[] cursors;
    public GameObject[] players;
    public bool allPlayersSelected;
    public bool allPlayersDead;
    public bool allPlayersPlaced;
    public GameObject spawner;
    public static bool isSelecting = true;
    public static bool isPlacing = false;
    public static bool isPlaying = false;

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
                isSelecting = false;
                isPlacing = true;
                for(int i = 0; i < players.Length; i++)
                {
                    players[i].transform.position = new Vector2(players[i].GetComponent<PlayerMovementScript>().spawnX, players[i].GetComponent<PlayerMovementScript>().spawnY);
                    //players[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    players[i].GetComponent<PlayerMovementScript>().maxPlayerHP = 5;
                    Destroy(players[i].GetComponent<PlayerMovementScript>().objectHeld);
                }
                setAllActive(players);
                setAllActive(cursors);
                for(int i = 0; i < cursors.Length; i++)
                {
                    cursors[i].GetComponent<SelectorScript>().selectedObject.SetActive(true);
                }
            }
        }
        if (isPlacing)
        {
            for(int i = 0; i < cursors.Length; i++)
            {
                if (cursors[i].activeSelf == true)
                {
                    break;
                }
                allPlayersPlaced = true;
            }
            if (allPlayersPlaced == true)
            {
                PauseManager.isPaused = false;
                allPlayersPlaced = false;
                isPlacing = false;
                isPlaying = true;
            }
        }
        if (isPlaying)
        {
            for(int i = 0; i < players.Length; i++)
            {
                if(players[i].activeSelf == true)
                {
                    break;
                }
                allPlayersDead = true;
            }
            if (allPlayersDead)
            {
                PauseManager.isPaused = true;
                spawner.SetActive(true);
                spawner.GetComponent<StuffSpawnerScript>().spawnStuff();
                allPlayersSelected = false;
                isSelecting = true;
                isPlaying = false;
                allPlayersDead = false;
                for(int i = 0; i < cursors.Length; i++)
                {
                    cursors[i].SetActive(true);
                    cursors[i].GetComponent<SelectorScript>().hasSelected = false;
                    cursors[i].transform.position = cursors[i].GetComponent<SelectorScript>().startingCoords;
                }
            }
        }
    }

    public void setAllActive(GameObject[] objects)
    {
        for(int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(true);
        }
    }
}
