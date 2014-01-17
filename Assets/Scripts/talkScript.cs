using UnityEngine;
using System.Collections;

public class talkScript : MonoBehaviour {
	
	public string name;
	public AudioClip[] hello;
	public AudioClip[] smalltalk;
	public AudioClip[] icebreaker;
	public AudioClip[] hustle;
	public AudioSource puhuja;
	public bool playing = false;
	int currentSample = 0;
	// Use this for initialization
	void Start () {
		talkRandom();
	}
	
	public void talkRandom() {
		puhuja.clip = hello[Random.Range(0,hello.Length)];
		puhuja.Play();
		playing = true;
		currentSample = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (playing && !puhuja.isPlaying) {
			if (currentSample == 4) {
				playing = false;
				currentSample = 0;
			}
			if (currentSample == 3) {
				puhuja.clip = hustle[Random.Range(0,hustle.Length)];
				puhuja.Play();
				
				currentSample = 4;
			}
			if (currentSample == 2) {
				puhuja.clip = icebreaker[Random.Range(0,icebreaker.Length)];
				puhuja.Play();
				currentSample = 3;
			}
			if (currentSample == 1) {
				puhuja.clip = smalltalk[Random.Range(0,smalltalk.Length)];
				puhuja.Play();
				currentSample = 2;
			}

		}
	}
}
