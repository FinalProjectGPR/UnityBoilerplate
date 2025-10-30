using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangerScript : MonoBehaviour
{
    public GameObject[] cursors;
    public bool[] cursorsActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < cursorsActive.Length; i++)
        {
            if (cursorsActive[i] == true)
            {
                break;
            }
            Debug.Log("All players have selected items!");
        }
    }
}
