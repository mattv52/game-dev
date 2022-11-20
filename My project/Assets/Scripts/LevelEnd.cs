using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public GameObject canvas;

    void Start()
    {
        // canvas.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H)){
            print("H");
            canvas.SetActive(true);
        }
    }
}
