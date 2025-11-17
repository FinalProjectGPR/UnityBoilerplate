using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goPlay()
    {
        SceneManager.LoadScene("Arena");
    }

    public void goControls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void goStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
