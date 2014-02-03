using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class kauppaScript : MonoBehaviour {
	
	public GameObject activeBlock;
	public bool kauppaEnabled = false;
	public clickScript click;
	
	// Use this for initialization
	void Start () {
		click = GameObject.Find("block").GetComponent("clickScript") as clickScript;
	}
	
	void OnMouseDown() {
		
		if( kauppaEnabled == false ) {
			click.highlightcube.renderer.enabled = true;
			kauppaEnabled = true;
			GetComponent<TextMesh>().text = "Kauppa: ON";
			
			foreach(GameObject kauppaSolu in GameObject.FindGameObjectsWithTag("kauppaSolu"))
			{
        		kauppaSolu.renderer.enabled = true;
			}

		}			
		else {
			kauppaEnabled = false;
			click.highlightcube.renderer.enabled =false;
			click.highlightcube.transform.position += new Vector3(0,0,1);
			GetComponent<TextMesh>().text = "Kauppa: OFF";
			
			foreach(GameObject kauppaSolu in GameObject.FindGameObjectsWithTag("kauppaSolu"))
			{
				kauppaSolu.renderer.enabled = false;
			}
		}		
	}

	public void saveActiveBlock (GameObject block) {
		activeBlock = block;
	}
	public GameObject getActiveBlock() {
		return activeBlock;	
	}
	void OnMouseEnter () {
		//this.guiText.fontSize = 17;
		GetComponent<TextMesh>().characterSize += 0.02f;
	}
	void OnMouseExit () {
		//this.guiText.fontSize = 15;
		GetComponent<TextMesh>().characterSize -= 0.02f;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
