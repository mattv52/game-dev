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

	public void reset() {
		timer = 0.0f;
	} 

	void Update () {
		if(playing == true){

			timer += Time.deltaTime;
			int minutes = Mathf.FloorToInt(timer / 60F);
			int seconds = Mathf.FloorToInt(timer % 60F);
			int milliseconds = Mathf.FloorToInt((timer * 10F) % 10F); // 1 decimal milliseconds
			// int milliseconds = Mathf.FloorToInt((timer * 100F) % 100F); //2 decimal milliseconds
			timerText.text = minutes.ToString ("0") + ":" + seconds.ToString ("00") + "." + milliseconds.ToString("0");
		}
	}
}
