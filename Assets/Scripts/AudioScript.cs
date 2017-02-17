﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioScript : MonoBehaviour {
	Dictionary<int,bool> lockedAudioTracks = new Dictionary<int,bool> ();
	Dictionary<int,float> lockedAudioTracksDuration = new Dictionary<int,float> ();
	List<AudioSource> audioSources = new List<AudioSource>();
	public string rootAudioDirectory;
	public int totalLanes;
	public int currentLane;
	public float lockDownDuration;
	
	void Start () {
		for (int x = 0; x < totalLanes; x++) {
			AudioSource audioSource = gameObject.AddComponent<AudioSource> ();
			audioSources.Add (audioSource);
			string path = rootAudioDirectory + "/" + (x + 1);
			AudioClip clip = Resources.Load<AudioClip> (path);
			audioSource.clip = clip;
			audioSource.volume = 0;
			audioSource.Play ();
			lockedAudioTracks [x] = false;
			lockedAudioTracksDuration [x] = 0.0f;
		}
	}

	void Update(){
		float deltaTime = Time.deltaTime;
		for (int x = 0; x < totalLanes; x++) {
			if (lockedAudioTracks [x]) {
				lockedAudioTracksDuration [x] -= deltaTime;
			}
					
				
		}
	}

	public void setCurrentLane(int lane){
		Debug.Log ("On lane : " + lane);
		if (!lockedAudioTracks [currentLane])
			audioSources [currentLane].volume = 0;
		currentLane = lane;
		audioSources [lane].volume = 100;
	}

	public void lockDownLane(int lane){
		lockedAudioTracks[lane] = true;
		lockedAudioTracksDuration [lane] = lockDownDuration;
	}
}