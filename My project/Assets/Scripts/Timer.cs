using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
	public TMP_Text timerText; 
	public bool playing;
	private float timer;

	void Start() {
		playing = true;
	}

	void Update () {
		if(playing == true){

			timer += Time.deltaTime;
			int minutes = Mathf.FloorToInt(timer / 60F);
			int seconds = Mathf.FloorToInt(timer % 60F);
			int milliseconds = Mathf.FloorToInt((timer * 100F) % 100F);
			timerText.text = minutes.ToString ("0") + ":" + seconds.ToString ("00") + "." + milliseconds.ToString("0");
		}
	}
}
