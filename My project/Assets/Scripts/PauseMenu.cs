using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void pause()
    {
        Time.timeScale = 0;
    }

    public void play()
    {
        Time.timeScale = 1;
    }
}
