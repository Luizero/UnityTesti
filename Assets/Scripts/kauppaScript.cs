using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class kauppaScript : MonoBehaviour {
	
	public GameObject activeBlock;
	//public GameObject test;
	public bool kauppaEnabled = false;
	public clickScript click;
	//List<GameObject> solut;
	
	// Use this for initialization
	void Start () {
		click = GameObject.Find("block").GetComponent("clickScript") as clickScript;
	}
	
	void OnMouseDown() {
		if( kauppaEnabled == false ) {
			click.highlightcube.renderer.enabled = true;
			kauppaEnabled = true;
			this.guiText.text = "Kauppa: ON";
			
			foreach(GameObject test in GameObject.FindGameObjectsWithTag("test"))
			{
        		test.guiTexture.enabled = true;
			}

		}			
		else {
			kauppaEnabled = false;
			click.highlightcube.renderer.enabled =false;
			click.highlightcube.transform.position += new Vector3(0,0,1);
			this.guiText.text = "Kauppa: OFF";
			
			foreach(GameObject test in GameObject.FindGameObjectsWithTag("test"))
			{
			test.guiTexture.enabled = false;
			}
		}		
	}

	public void saveActiveBlock (GameObject block) {
		activeBlock = block;
	}
	void OnMouseOver () {
		this.guiText.fontSize = 17;
	}
	void OnMouseExit () {
		this.guiText.fontSize = 15;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
