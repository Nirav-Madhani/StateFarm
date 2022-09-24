using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Platinio;

public class MainScreen : MonoBehaviour
{
    public Popup p;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("show", 1);
    }
    void show()
    {
        p.Toggle();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel(int i)
    {
        SceneManager.LoadScene(i);
    }
}
