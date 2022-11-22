using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelEnd : MonoBehaviour
{
    public GameObject canvas;
    public GameObject UI;
    public Sprite[] ranks;
    public string[] rankTimes;
    public Image displayRankImg;
    public TMP_Text displayRankTimes;

    public TMP_Text timer;
    public TMP_Text displayTimer;
    

    void Start()
    {
        displayRankTimes.text = $"S = {rankTimes[0]}\nA = {rankTimes[1]}\nB = {rankTimes[2]}";
    }

    public void endLevel() 
    {
        updateRank();
        displayTimer.text = timer.text;
        Time.timeScale = 0;
        UI.SetActive(false);
        canvas.SetActive(true);
    }

    void updateRank() 
    {
        string time = timer.text;
        if (compareTimes(time, rankTimes[0])) {displayRankImg.sprite = ranks[0];} else
        if (compareTimes(time, rankTimes[1])) {displayRankImg.sprite = ranks[1];} else
        if (compareTimes(time, rankTimes[2])) {displayRankImg.sprite = ranks[2];} else
        displayRankImg.sprite = ranks[3];
    }

    // Returns true if t1 is faster then (or equal to) t2
    private bool compareTimes(string t1, string t2) 
    {
        int min1 = int.Parse(t1.Substring(0,1));
        int min2 = int.Parse(t2.Substring(0,1));
        
        int sec1 = int.Parse(t1.Substring(2,2));
        int sec2 = int.Parse(t2.Substring(2,2));

        int mil1 = int.Parse(t1.Substring(5));
        int mil2 = int.Parse(t2.Substring(5));

        if (t1 == t2) {return true;} else
        if (min1 < min2) {return true;} else
        if (min1 <= min2 && sec1 < sec2) {return true;} else
        if (min1 <= min2 && sec1 <= sec2 && mil1 < mil2) {return true;} else
        return false;
    }
}
